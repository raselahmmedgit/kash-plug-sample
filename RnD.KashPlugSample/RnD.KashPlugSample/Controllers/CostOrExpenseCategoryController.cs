using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Models;
using System.Data;

namespace RnD.KashPlugSample.Controllers
{
    public class CostOrExpenseCategoryController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /CostOrExpenseCategory/

        public ActionResult Index()
        {
            return View();
        }

        #region CRUD Action For Custom PopUp

        //
        // GET: /CostOrExpenseCategory/Details/By ID

        public ActionResult Details(int id)
        {
            CostOrExpenseCategory costOrExpenseCategory = _db.CostOrExpenseCategories.Find(id);
            //return View(costOrExpenseCategory);
            return PartialView("_Details", costOrExpenseCategory);
        }

        //
        // GET: /CostOrExpenseCategory/Create

        public ActionResult Create()
        {
            //return View();
            return PartialView("_Create");
        }

        //
        // GET: /CostOrExpenseCategory/Add

        public ActionResult Add()
        {
            //return View();
            return PartialView("_Add");
        }

        //
        // POST: /CostOrExpenseCategory/Add

        [HttpPost]
        public ActionResult Add(CostOrExpenseCategory costOrExpenseCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.CostOrExpenseCategories.Add(costOrExpenseCategory);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(costOrExpenseCategory);
                //return PartialView("_Add", costOrExpenseCategory);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /CostOrExpenseCategory/Edit/By ID

        public ActionResult Edit(int id)
        {
            CostOrExpenseCategory costOrExpenseCategory = _db.CostOrExpenseCategories.Find(id);

            //return View(costOrExpenseCategory);
            return PartialView("_Edit", costOrExpenseCategory);
        }

        //
        // POST: /CostOrExpenseCategory/Edit/By ID

        [HttpPost]
        public ActionResult Edit(CostOrExpenseCategory costOrExpenseCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(costOrExpenseCategory).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(costOrExpenseCategory);
                //return PartialView("_Edit", costOrExpenseCategory);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /CostOrExpenseCategory/Delete/By ID

        public ActionResult Delete(int id)
        {
            CostOrExpenseCategory costOrExpenseCategory = _db.CostOrExpenseCategories.Find(id);

            //return View(costOrExpenseCategory);
            return PartialView("_Delete", costOrExpenseCategory);
        }

        //
        // POST: /CostOrExpenseCategory/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CostOrExpenseCategory costOrExpenseCategory = _db.CostOrExpenseCategories.Find(id);
                if (costOrExpenseCategory != null)
                {
                    _db.CostOrExpenseCategories.Remove(costOrExpenseCategory);
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
