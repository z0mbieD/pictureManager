using System.Web.Mvc;

namespace PictureManager.Web.Controllers
{
    public class HomeController : PictureManagerControllerBase
    {
        public ActionResult Index()
        { 
            return View();
        }
	}
}