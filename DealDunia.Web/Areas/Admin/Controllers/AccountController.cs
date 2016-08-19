using DealDunia.Web.Areas.Admin.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace DealDunia.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool result = FormsAuthentication.Authenticate(model.UserName, model.Password);
                if (result)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
