using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Models;
using System.Data;

namespace RnD.KashPlugSample.Controllers
{
    public class SaleOrIncomeCategoryController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /SaleOrIncomeCategory/

        public ActionResult Index()
        {
            return View();
        }

        #region CRUD Action For Custom PopUp

        //
        // GET: /SaleOrIncomeCategory/Details/By ID

        public ActionResult Details(int id)
        {
            SaleOrIncomeCategory saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(id);
            //return View(saleOrIncomeCategory);
            return PartialView("_Details", saleOrIncomeCategory);
        }

        //
        // GET: /SaleOrIncomeCategory/Create

        public ActionResult Create()
        {
            //return View();
            return PartialView("_Create");
        }

        //
        // GET: /SaleOrIncomeCategory/Add

        public ActionResult Add()
        {
            //return View();
            return PartialView("_Add");
        }

        //
        // POST: /SaleOrIncomeCategory/Add

        [HttpPost]
        public ActionResult Add(SaleOrIncomeCategory saleOrIncomeCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.SaleOrIncomeCategories.Add(saleOrIncomeCategory);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(saleOrIncomeCategory);
                //return PartialView("_Add", saleOrIncomeCategory);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /SaleOrIncomeCategory/Edit/By ID

        public ActionResult Edit(int id)
        {
            SaleOrIncomeCategory saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(id);

            //return View(saleOrIncomeCategory);
            return PartialView("_Edit", saleOrIncomeCategory);
        }

        //
        // POST: /SaleOrIncomeCategory/Edit/By ID

        [HttpPost]
        public ActionResult Edit(SaleOrIncomeCategory saleOrIncomeCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(saleOrIncomeCategory).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(saleOrIncomeCategory);
                //return PartialView("_Edit", saleOrIncomeCategory);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /SaleOrIncomeCategory/Delete/By ID

        public ActionResult Delete(int id)
        {
            SaleOrIncomeCategory saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(id);

            //return View(saleOrIncomeCategory);
            return PartialView("_Delete", saleOrIncomeCategory);
        }

        //
        // POST: /SaleOrIncomeCategory/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SaleOrIncomeCategory saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(id);
                if (saleOrIncomeCategory != null)
                {
                    _db.SaleOrIncomeCategories.Remove(saleOrIncomeCategory);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
