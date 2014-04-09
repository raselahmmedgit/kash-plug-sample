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

        #region Action

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
                    return PartialView("_Details", viewModel);
                }

                errorViewModel = ExceptionHelper.ExceptionErrorMessageForNullObject();
            }
            catch (Exception ex)
            {
                errorViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            }

            return PartialView("_ErrorPopup", errorViewModel);
        }

        //
        // GET: /Account/Add

        public ActionResult Add()
        {
            //return View();
            return PartialView("_AddOrEdit");
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
                    return PartialView("_AddOrEdit", viewModel);
                }

                errorViewModel = ExceptionHelper.ExceptionErrorMessageForNullObject();
            }
            catch (Exception ex)
            {
                errorViewModel = ExceptionHelper.ExceptionErrorMessageFormat(ex);
            }

            return PartialView("_ErrorPopup", errorViewModel);
        }

        //
        // POST: /Account/Save

        [HttpPost]
        public ActionResult Save(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Account() { AccountId = accountViewModel.AccountId, AccountName = accountViewModel.AccountName };

                    if (model.AccountId == 0)
                    {
                        _db.Accounts.Add(model);
                    }
                    else
                    {
                        _db.Entry(model).State = EntityState.Modified;
                    }

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
        // POST: /Account/Delete/By ID
        [HttpPost]
        public ActionResult Delete(int id)
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

        #region Method

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        private List<AccountViewModel> GetAccountDataList()
        {
            var dataList = _db.Accounts.ToList().Select(c => new Account { AccountId = c.AccountId, AccountName = c.AccountName });

            var viewModels = dataList.Select(
                md => new AccountViewModel
                {
                    AccountId = md.AccountId,
                    AccountName = md.AccountName,

                    ActionLink = KendoUiHelper.KendoUIGridActionLinkGenerate(md.AccountId.ToString())
                }).OrderBy(o => o.AccountName).ToList();

            return viewModels;
        }

        #endregion
    }
}
