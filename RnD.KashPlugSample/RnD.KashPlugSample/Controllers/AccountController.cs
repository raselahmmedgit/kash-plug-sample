using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Models;
using System.Data;

namespace RnD.KashPlugSample.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        #region CRUD Action For Custom PopUp

        //
        // GET: /Account/Details/By ID

        public ActionResult Details(int id)
        {
            Account account = _db.Accounts.Find(id);
            //return View(account);
            return PartialView("_Details", account);
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            //return View();
            return PartialView("_Create");
        }

        //
        // GET: /Account/Add

        public ActionResult Add()
        {
            //return View();
            return PartialView("_Add");
        }

        //
        // POST: /Account/Add

        [HttpPost]
        public ActionResult Add(Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Accounts.Add(account);
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(account);
                //return PartialView("_Add", account);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /Account/Edit/By ID

        public ActionResult Edit(int id)
        {
            Account account = _db.Accounts.Find(id);

            //return View(account);
            return PartialView("_Edit", account);
        }

        //
        // POST: /Account/Edit/By ID

        [HttpPost]
        public ActionResult Edit(Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(account).State = EntityState.Modified;
                    _db.SaveChanges();

                    //return RedirectToAction("Index");
                    return Content(Boolean.TrueString);
                }

                //return View(account);
                //return PartialView("_Edit", account);
                return Content("Please review your form.");
            }
            catch (Exception ex)
            {
                return Content("Error Occured!");
            }
        }

        //
        // GET: /Account/Delete/By ID

        public ActionResult Delete(int id)
        {
            Account account = _db.Accounts.Find(id);

            //return View(account);
            return PartialView("_Delete", account);
        }

        //
        // POST: /Account/Delete/By ID

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Account account = _db.Accounts.Find(id);
                if (account != null)
                {
                    _db.Accounts.Remove(account);
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
