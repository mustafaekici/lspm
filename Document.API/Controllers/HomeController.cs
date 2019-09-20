using LS.Document.API.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LS.Document.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiConfig _apiConfig;

        public HomeController(IOptionsSnapshot<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        public ActionResult Index()
        {
            //Redirect to Swagger UI if enabled by config
            if (_apiConfig.SwaggerUiEnabled)
                return new RedirectResult("~/swagger");
            else
                return View("Index");
        }
    }
}
