using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Helpers;
using RnD.KashPlugSample.Models;
using System.Data;
using RnD.KashPlugSample.ViewModels;

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

        public JsonResult AccountRead()
        {
            var models = GetAccountDataList();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        #region CRUD Action For Custom PopUp

        //
        // GET: /Account/Details/By ID

        public ActionResult Details(int id)
        {
            var errorViewModel = new ErrorViewModel();
            try
            {
                var account = _db.Accounts.Find(id);
                if (account != null)
                {
                    var viewModel = new AccountViewModel() { AccountId = account.AccountId, AccountName = account.AccountName };
                    //return View(account);
                    return PartialView("_Details", viewModel);
                }
                errorViewModel.ErrorMessage = "Requested object could not found.";
            }
            catch (Exception ex)
            {
                errorViewModel.ErrorMessage = ExceptionHelper.ExceptionMessageFormat(ex);
            }

            return PartialView("_Error", errorViewModel);
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
        public ActionResult Add(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Account() { AccountId = accountViewModel.AccountId, AccountName = accountViewModel.AccountName };

                    _db.Accounts.Add(model);
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                return Content(ExceptionHelper.ExceptionMessageFormat(ex));
            }
        }

        //
        // GET: /Account/Edit/By ID

        public ActionResult Edit(int id)
        {
            var errorViewModel = new ErrorViewModel();
            try
            {
                var account = _db.Accounts.Find(id);
                if (account != null)
                {
                    var viewModel = new AccountViewModel() { AccountId = account.AccountId, AccountName = account.AccountName };
                    return PartialView("_Edit", viewModel);
                }
                errorViewModel.ErrorMessage = "Requested object could not found.";
            }
            catch (Exception ex)
            {
                errorViewModel.ErrorMessage = ExceptionHelper.ExceptionMessageFormat(ex);
            }

            return PartialView("_Error", errorViewModel);
        }

        //
        // POST: /Account/Edit/By ID

        [HttpPost]
        public ActionResult Edit(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Account() { AccountId = accountViewModel.AccountId, AccountName = accountViewModel.AccountName };

                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();

                    return Content(Boolean.TrueString);
                }

                return Content(ExceptionHelper.ModelStateErrorFormat(ModelState));
            }
            catch (Exception ex)
            {
                return Content(ExceptionHelper.ExceptionMessageFormat(ex));
            }

        }

        //
        // GET: /Account/Delete/By ID

        public ActionResult Delete(int id)
        {
            var errorViewModel = new ErrorViewModel();
            try
            {
                var account = _db.Accounts.Find(id);
                if (account != null)
                {
                    var viewModel = new AccountViewModel() { AccountId = account.AccountId, AccountName = account.AccountName };
                    return PartialView("_Delete", viewModel);
                }
                errorViewModel.ErrorMessage = "Requested object could not found.";
            }
            catch (Exception ex)
            {
                errorViewModel.ErrorMessage = ExceptionHelper.ExceptionMessageFormat(ex);
            }

            return PartialView("_Error", errorViewModel);
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

                    return Content(Boolean.TrueString);
                }

                return Content("Requested object could not found.");
            }
            catch (Exception ex)
            {
                return Content(ExceptionHelper.ExceptionMessageFormat(ex));
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        #region Method

        private List<Account> GetAccountDataList()
        {
            var viewModels = _db.Accounts.ToList().Select(c => new Account { AccountId = c.AccountId, AccountName = c.AccountName });

            return viewModels.ToList();
        }

        #endregion
    }
}
