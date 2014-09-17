using Abp.Web.Mvc.Views;

namespace PictureManager.Web.Views
{
    public abstract class PictureManagerWebViewPageBase : PictureManagerWebViewPageBase<dynamic>
    {

    }

    public abstract class PictureManagerWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected PictureManagerWebViewPageBase()
        {
            LocalizationSourceName = "PictureManager";
        }
    }
}