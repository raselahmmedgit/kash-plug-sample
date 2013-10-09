using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Models;
using System.Data;

namespace RnD.KashPlugSample.Controllers
{
    public class CurrencyController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /Currency/

        public ActionResult Index()
        {
            return View();
        }

        #region CRUD Action For Custom PopUp

        //
        // GET: /Currency/Details/By ID

        public ActionResult Details(int id)
        {
            Currency currency = _db.Currencies.Find(id);
            //return View(currency);
            return PartialView("_Details", currency);
        }

        //
        // GET: /Currency/Create

        public ActionResult Create()
        {
            //return View();
            return PartialView("_Create");
        }

        //
        // GET: /Currency/Add

        public ActionResult Add()
        {
            //return View();
            return PartialView("_Add");
        }

        //
        // POST: /Currency/Add

        [HttpPost]
        public ActionResult Add(Currency currency)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Currencies.Add(currency);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(currency);
                //return PartialView("_Add", currency);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /Currency/Edit/By ID

        public ActionResult Edit(int id)
        {
            Currency currency = _db.Currencies.Find(id);

            //return View(currency);
            return PartialView("_Edit", currency);
        }

        //
        // POST: /Currency/Edit/By ID

        [HttpPost]
        public ActionResult Edit(Currency currency)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(currency).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(currency);
                //return PartialView("_Edit", currency);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /Currency/Delete/By ID

        public ActionResult Delete(int id)
        {
            Currency currency = _db.Currencies.Find(id);

            //return View(currency);
            return PartialView("_Delete", currency);
        }

        //
        // POST: /Currency/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Currency currency = _db.Currencies.Find(id);
                if (currency != null)
                {
                    _db.Currencies.Remove(currency);
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
