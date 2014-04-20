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

        public JsonResult AccountRead(KendoUiGridParam request)
        {
            var accountViewModels = GetAccountDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<AccountViewModel>(accountViewModels, request);

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
            var viewModel = new AccountViewModel() { AccountId = 0 };
            //return View();
            return PartialView("_AddOrEdit", viewModel);
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
                    //add
                    if (accountViewModel.AccountId == 0)
                    {
                        var model = new Account() { AccountId = accountViewModel.AccountId, AccountName = accountViewModel.AccountName };
                        _db.Accounts.Add(model);
                    }
                    else //edit
                    {
                        Account account = _db.Accounts.Find(accountViewModel.AccountId);

                        if (account != null)
                        {

                            account.AccountId = accountViewModel.AccountId;
                            account.AccountName = accountViewModel.AccountName;
                            _db.Entry(account).State = EntityState.Modified;

                        }
                        else
                        {
                            return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.FalseString, MessageType.warning.ToString(), ExceptionHelper.ExceptionMessageForNullObject()));
                        }

                    }

                    _db.SaveChanges();

                    return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), "Saved Successfully."));
                }

                return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), ExceptionHelper.ModelStateErrorFormat(ModelState)));
            }
            catch (Exception ex)
            {
                return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), ExceptionHelper.ExceptionMessageFormat(ex)));
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

                    return Json(new { status = Boolean.FalseString, messageType = MessageType.success.ToString(), messageText = "Deleted Successfully." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { status = Boolean.FalseString, messageType = MessageType.warning.ToString(), messageText = ExceptionHelper.ExceptionMessageForNullObject() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { status = Boolean.FalseString, messageType = MessageType.danger.ToString(), messageText = ExceptionHelper.ExceptionMessageFormat(ex) }, JsonRequestBehavior.AllowGet);
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
