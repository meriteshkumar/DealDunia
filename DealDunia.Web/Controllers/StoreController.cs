﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DealDunia.Domain.Abstract;
using DealDunia.Domain.Concrete;
using DealDunia.Domain.Entities;
using DealDunia.Infrastructure.Utility;

namespace DealDunia.Web.Controllers
{
    public class StoreController : Controller
    {
        IRepository<Store, StoreValues> repository = null;
        public StoreController()
        {
            this.repository = new StoreRepository();
        }    

        public ActionResult Stores()
        {
            var stores = repository.Get(new StoreValues { StoreName = string.Empty, StoreCategoryName = string.Empty });
            return View(stores);
        }

        public ActionResult Store(string store)
        {
            IRepository<Store, StoreValues> repository = new StoreRepository();            
            var selectedStore = repository.Get(new StoreValues { StoreName = store, StoreCategoryName = string.Empty });
            return View(selectedStore);
        }
    }
}
