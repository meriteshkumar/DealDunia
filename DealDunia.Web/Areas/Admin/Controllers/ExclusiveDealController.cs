﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDunia.Web.Areas.Admin.Controllers
{
    public class ExclusiveDealController : Controller
    {
        public ActionResult Index()
        {
            EComEntities context = new EComEntities();

            return View(context.ExcDeals);
        }

        public ActionResult _EditExcDeal(int id)
        {
            EComEntities context = new EComEntities();

            var viewModel = context.ExcDeals.Where(e => e.ExcDealId == id).First();

            return PartialView("_EditExcDeal", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(DealDunia.Web.Areas.ExcDeal model, string storeName, HttpPostedFileBase Image1 = null)
        {
            if (ModelState.IsValid)
            {
                var folderPath = string.Format("~/Images/Stores/{0}/", storeName);
                var ImagePath = string.Format("Stores/{0}/{1}", storeName, System.IO.Path.GetFileName(model.Image));

                if (Image1 != null)
                {
                    var path = System.IO.Path.Combine(Server.MapPath(folderPath), System.IO.Path.GetFileName(model.Image));
                    Image1.SaveAs(path);
                }

                EComEntities context = new EComEntities();

                var execDeal = context.ExcDeals.Single(s => s.ExcDealId == model.ExcDealId);
                execDeal.StoreId = model.StoreId;
                execDeal.CategoryId = model.CategoryId;
                execDeal.StoreCategoryId = model.StoreCategoryId;
                execDeal.Title = model.Title;
                execDeal.Description = model.Description;
                execDeal.Image = ImagePath;
                execDeal.Logo = model.Logo;
                execDeal.URL = model.URL;
                execDeal.IsFeatured = model.IsFeatured;
                execDeal.Active = model.Active;
                execDeal.StartDate = model.StartDate;
                execDeal.EndDate = model.EndDate;

                context.SaveChanges();

                TempData["Message"] = "Record updated";

                return RedirectToAction("Index");
            }
            else
            {
                return PartialView("_EditExcDeal", model);
            }
        }

        public PartialViewResult _StoreCategoryDropDown(string controlName)
        {
            EComEntities context = new EComEntities();

            var storeCategories = context.StoreCategories.Where(s => s.Active == true).OrderBy(d => d.DisplayOrder).ToList();
            ViewBag.ControlName = controlName;

            return PartialView(storeCategories);
        }

        public PartialViewResult _StoreDropDown(string controlName)
        {
            EComEntities context = new EComEntities();

            var stores = context.Stores.Where(s => s.Active == true).OrderBy(d => d.DisplayOrder).ToList();
            ViewBag.ControlName = controlName;

            return PartialView(stores);
        }
    }
}