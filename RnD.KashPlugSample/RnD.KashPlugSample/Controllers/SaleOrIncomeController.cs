using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Models;
using System.Data;

namespace RnD.KashPlugSample.Controllers
{
    public class SaleOrIncomeController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /SaleOrIncome/

        public ActionResult Index()
        {
            return View();
        }

        #region CRUD Action For Custom PopUp

        //
        // GET: /SaleOrIncome/Details/By ID

        public ActionResult Details(int id)
        {
            SaleOrIncome saleOrIncome = _db.SaleOrIncomes.Find(id);
            //return View(saleOrIncome);
            return PartialView("_Details", saleOrIncome);
        }

        //
        // GET: /SaleOrIncome/Create

        public ActionResult Create()
        {
            //return View();
            return PartialView("_Create");
        }

        //
        // GET: /SaleOrIncome/Add

        public ActionResult Add()
        {
            //return View();
            return PartialView("_Add");
        }

        //
        // POST: /SaleOrIncome/Add

        [HttpPost]
        public ActionResult Add(SaleOrIncome saleOrIncome)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.SaleOrIncomes.Add(saleOrIncome);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(saleOrIncome);
                //return PartialView("_Add", saleOrIncome);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /SaleOrIncome/Edit/By ID

        public ActionResult Edit(int id)
        {
            SaleOrIncome saleOrIncome = _db.SaleOrIncomes.Find(id);

            //return View(saleOrIncome);
            return PartialView("_Edit", saleOrIncome);
        }

        //
        // POST: /SaleOrIncome/Edit/By ID

        [HttpPost]
        public ActionResult Edit(SaleOrIncome saleOrIncome)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(saleOrIncome).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(saleOrIncome);
                //return PartialView("_Edit", saleOrIncome);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /SaleOrIncome/Delete/By ID

        public ActionResult Delete(int id)
        {
            SaleOrIncome saleOrIncome = _db.SaleOrIncomes.Find(id);

            //return View(saleOrIncome);
            return PartialView("_Delete", saleOrIncome);
        }

        //
        // POST: /SaleOrIncome/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SaleOrIncome saleOrIncome = _db.SaleOrIncomes.Find(id);
                if (saleOrIncome != null)
                {
                    _db.SaleOrIncomes.Remove(saleOrIncome);
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
