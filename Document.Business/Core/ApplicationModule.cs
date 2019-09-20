using Autofac;
using LS.Document.Business.Contracts;
using LS.Document.Business.Implementations;
using LS.Document.Business.Validations;
using FluentValidation;
using Infrastructure.Document;
using MediatR;
using Shared.Core.EF.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LS.Document.Business.Core
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DocumentConnectionConfiguration>().As<IDocumentConnectionConfiguration>()
                .SingleInstance();
            builder.RegisterType<CompressedFileStorageConverter>().As<IFileStorageConverter>()
                .InstancePerLifetimeScope();

            var asm = AppDomain.CurrentDomain.GetAssemblies()
                .Where(c => c.ManifestModule.Name.StartsWith("LS.")).ToArray();
            builder.RegisterAssemblyTypes(asm)
                .AsClosedTypesOf(typeof(ISqlQuery<>)).AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ApplicationModule).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(AbstractValidator<>)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ValidationPipeline<,>)).As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();
        }
    }
}
