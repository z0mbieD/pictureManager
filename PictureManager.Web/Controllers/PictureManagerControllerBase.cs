using Abp.Web.Mvc.Controllers;

namespace PictureManager.Web.Controllers
{
    public abstract class PictureManagerControllerBase : AbpController
    {
        protected PictureManagerControllerBase()
        {
            LocalizationSourceName = "PictureManager";
        }
    }
}