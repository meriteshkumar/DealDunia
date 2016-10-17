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
#pragma warning disable CS0618 // 'FormsAuthentication.Authenticate(string, string)' is obsolete: 'The recommended alternative is to use the Membership APIs, such as Membership.ValidateUser. For more information, see http://go.microsoft.com/fwlink/?LinkId=252463.'
                bool result = FormsAuthentication.Authenticate(model.UserName, model.Password);
#pragma warning restore CS0618 // 'FormsAuthentication.Authenticate(string, string)' is obsolete: 'The recommended alternative is to use the Membership APIs, such as Membership.ValidateUser. For more information, see http://go.microsoft.com/fwlink/?LinkId=252463.'
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
