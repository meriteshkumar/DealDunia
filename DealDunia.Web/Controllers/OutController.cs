using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;

namespace DealDunia.Web.Controllers
{
    public class OutController : Controller
    {
        //
        // GET: /Out/
        ICommonRepository repository = null;

        public OutController()
        {
            this.repository = new CommonRepository();
        }

        //public void Out()
        //{

        //}

        public ActionResult Out(string source, int id=0)
        {
          string url = string.Empty;
          url = repository.GetOutURL(source, id);
          return Redirect(url);
        }

    }
}
