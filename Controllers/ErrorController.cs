using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using nackademin24_umbraco.Business.ViewModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace nackademin24_umbraco.Controllers
{
    public class ErrorController : RenderController
    {
        private readonly IUmbracoContextAccessor _contextAccessor;
        public ErrorController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _contextAccessor = umbracoContextAccessor;
        }

        public override IActionResult Index()
        {
            if (CurrentPage is Error errorPage)
            {
                var model = new ErrorPageViewModel(errorPage, _contextAccessor);

                return View("error", model);
            }

            return NotFound();
        }
    }
}
