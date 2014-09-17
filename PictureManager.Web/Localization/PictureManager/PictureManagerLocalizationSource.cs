using System.Web;
using Abp.Localization.Sources.Xml;

namespace PictureManager.Web.Localization.PictureManager
{
    public class PictureManagerLocalizationSource : XmlLocalizationSource
    {
        public PictureManagerLocalizationSource()
            : base("PictureManager", HttpContext.Current.Server.MapPath("/Localization/PictureManager"))
        {
        }
    }
}