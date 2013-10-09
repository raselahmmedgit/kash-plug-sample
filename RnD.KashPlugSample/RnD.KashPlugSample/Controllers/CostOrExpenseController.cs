using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Models;
using System.Data;

namespace RnD.KashPlugSample.Controllers
{
    public class CostOrExpenseController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /CostOrExpense/

        public ActionResult Index()
        {
            return View();
        }

        #region CRUD Action For Custom PopUp

        //
        // GET: /CostOrExpense/Details/By ID

        public ActionResult Details(int id)
        {
            CostOrExpense costOrExpense = _db.CostOrExpenses.Find(id);
            //return View(costOrExpense);
            return PartialView("_Details", costOrExpense);
        }

        //
        // GET: /CostOrExpense/Create

        public ActionResult Create()
        {
            //return View();
            return PartialView("_Create");
        }

        //
        // GET: /CostOrExpense/Add

        public ActionResult Add()
        {
            //return View();
            return PartialView("_Add");
        }

        //
        // POST: /CostOrExpense/Add

        [HttpPost]
        public ActionResult Add(CostOrExpense costOrExpense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.CostOrExpenses.Add(costOrExpense);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(costOrExpense);
                //return PartialView("_Add", costOrExpense);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /CostOrExpense/Edit/By ID

        public ActionResult Edit(int id)
        {
            CostOrExpense costOrExpense = _db.CostOrExpenses.Find(id);

            //return View(costOrExpense);
            return PartialView("_Edit", costOrExpense);
        }

        //
        // POST: /CostOrExpense/Edit/By ID

        [HttpPost]
        public ActionResult Edit(CostOrExpense costOrExpense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(costOrExpense).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(costOrExpense);
                //return PartialView("_Edit", costOrExpense);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /CostOrExpense/Delete/By ID

        public ActionResult Delete(int id)
        {
            CostOrExpense costOrExpense = _db.CostOrExpenses.Find(id);

            //return View(costOrExpense);
            return PartialView("_Delete", costOrExpense);
        }

        //
        // POST: /CostOrExpense/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CostOrExpense costOrExpense = _db.CostOrExpenses.Find(id);
                if (costOrExpense != null)
                {
                    _db.CostOrExpenses.Remove(costOrExpense);
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
