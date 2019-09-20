using System;
using System.IO;
using LS.Document.API.Config;
using LS.Document.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using Infrastructure.Document;
using Microsoft.EntityFrameworkCore;
using LS.Identity.Security;
using Shared.Core.EF;
using MediatR;
using LS.Document.Business.Core;
using Shared.Core.DI;
using Shared.Core.Web.Swagger;
using Shared.Core.EF.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Shared.Core.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LS.Document.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiConfig>(Configuration.GetSection("Api"));

            services.AddMvcCore(c =>
            {
                c.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddApiExplorer()
            .AddJsonFormatters()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                //o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });

            var connectionString = Configuration.GetConnectionString("DocumentDataContext");
            services.AddDbContextPool<DocumentDataContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.CommandTimeout(120).EnableRetryOnFailure();
                    sqlServerOptionsAction.MigrationsHistoryTable("MigrationHistory", "Doc");
                });
            });
            services.Configure<DocumentConnectionConfiguration>(c => c.ConnectionString = connectionString);

            services.AddAuthorization(c => c.AddPolicy("Profile", p => p.Requirements.Add(new ProfileRequirement())));

            services.AddSwaggerGenFx("Document Api");

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    b => b.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            AddServices(services);
            ConfigureAuthService(services);
            services.AddMvc();

            services.AddSingleton<IDataSeeder<DocumentDataContext>, DocumentDataSeeder>();

            services.AddMediatR(typeof(ApplicationModule).Assembly);

            services.AddOptions();

            return IoC.Instance.BuildContainerAsServiceProvider(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();

            app.UseSwagger();
            app.UseSwaggerUIFx(typeof(Startup).Namespace);

            app.CreateDatabase<DocumentDataContext>(Configuration, env.IsProduction());
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddTransient<IPrincipalContext, PrincipalContext>();
            services.AddTransient<IAuthorizationHandler, ProfileAuthorizationHandler>();
        }

        private void ConfigureAuthService(IServiceCollection services)
        {
            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var identityUrl = Configuration.GetValue<string>("Api:IdentityUrl");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "Document.API";
            });
        }
    }
}
