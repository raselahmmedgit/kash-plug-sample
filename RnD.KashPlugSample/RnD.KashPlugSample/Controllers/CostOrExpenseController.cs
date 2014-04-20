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
    public class CostOrExpenseController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        #region Action

        //
        // GET: /CostOrExpense/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CostOrExpenseRead(KendoUiGridParam request)
        {
            var costOrExpenseViewModels = GetCostOrExpenseDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<CostOrExpenseViewModel>(costOrExpenseViewModels, request);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /CostOrExpense/Details/By ID

        public ActionResult Details(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var costOrExpense = _db.CostOrExpenses.Find(id);
                if (costOrExpense != null)
                {
                    var viewModel = new CostOrExpenseViewModel() { CostOrExpenseId = costOrExpense.CostOrExpenseId, Amount = costOrExpense.Amount, CreateDate = costOrExpense.CreateDate, Remarks = costOrExpense.Remarks, AccountId = costOrExpense.AccountId, AccountName = costOrExpense.Account != null ? costOrExpense.Account.AccountName : "", CostOrExpenseCategoryId = costOrExpense.CostOrExpenseCategoryId, CostOrExpenseCategoryName = costOrExpense.CostOrExpenseCategory != null ? costOrExpense.CostOrExpenseCategory.CostOrExpenseCategoryName : "" };
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
        // GET: /CostOrExpense/Add

        public ActionResult Add()
        {
            var viewModel = new CostOrExpenseViewModel();

            var accountList = SelectListItemExtension.PopulateDropdownList(_db.Accounts.ToList<Account>(), "AccountId", "AccountName").ToList();
            var costOrExpenseCategoryList = SelectListItemExtension.PopulateDropdownList(_db.CostOrExpenseCategories.ToList<CostOrExpenseCategory>(), "CostOrExpenseCategoryId", "CostOrExpenseCategoryName").ToList();

            viewModel.CostOrExpenseCategoryId = 0;
            viewModel.CreateDate = DateTime.Now;
            viewModel.ddlAccounts = accountList;
            viewModel.ddlCostOrExpenseCategories = costOrExpenseCategoryList;

            //return View();
            return PartialView("_AddOrEdit", viewModel);
        }

        //
        // GET: /CostOrExpense/Edit/By ID

        public ActionResult Edit(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var costOrExpense = _db.CostOrExpenses.Find(id);
                if (costOrExpense != null)
                {
                    var accountList = SelectListItemExtension.PopulateDropdownList(_db.Accounts.ToList<Account>(), "AccountId", "AccountName", isEdit: true, selectedValue: costOrExpense.AccountId.ToString()).ToList();
                    var costOrExpenseCategoryList = SelectListItemExtension.PopulateDropdownList(_db.CostOrExpenseCategories.ToList<CostOrExpenseCategory>(), "CostOrExpenseCategoryId", "CostOrExpenseCategoryName", isEdit: true, selectedValue: costOrExpense.CostOrExpenseCategoryId.ToString()).ToList();

                    var viewModel = new CostOrExpenseViewModel() { CostOrExpenseId = costOrExpense.CostOrExpenseId, Amount = costOrExpense.Amount, CreateDate = costOrExpense.CreateDate, Remarks = costOrExpense.Remarks, AccountId = costOrExpense.AccountId, AccountName = costOrExpense.Account != null ? costOrExpense.Account.AccountName : "", ddlAccounts = accountList, CostOrExpenseCategoryId = costOrExpense.CostOrExpenseCategoryId, CostOrExpenseCategoryName = costOrExpense.CostOrExpenseCategory != null ? costOrExpense.CostOrExpenseCategory.CostOrExpenseCategoryName : "", ddlCostOrExpenseCategories = costOrExpenseCategoryList };

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
        // POST: /CostOrExpense/Save

        [HttpPost]
        public ActionResult Save(CostOrExpenseViewModel costOrExpenseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (costOrExpenseViewModel.CostOrExpenseId == 0)
                    {
                        var model = new CostOrExpense() { CostOrExpenseId = costOrExpenseViewModel.CostOrExpenseId, Amount = costOrExpenseViewModel.Amount, CreateDate = costOrExpenseViewModel.CreateDate, Remarks = costOrExpenseViewModel.Remarks, AccountId = costOrExpenseViewModel.AccountId, CostOrExpenseCategoryId = costOrExpenseViewModel.CostOrExpenseCategoryId };
                        _db.CostOrExpenses.Add(model);
                    }
                    else //edit
                    {
                        CostOrExpense costOrExpense = _db.CostOrExpenses.Find(costOrExpenseViewModel.CostOrExpenseId);

                        if (costOrExpense != null)
                        {

                            costOrExpense.CostOrExpenseId = costOrExpenseViewModel.CostOrExpenseId;
                            costOrExpense.Amount = costOrExpenseViewModel.Amount;
                            costOrExpense.CreateDate = costOrExpenseViewModel.CreateDate;
                            costOrExpense.Remarks = costOrExpenseViewModel.Remarks;
                            costOrExpense.AccountId = costOrExpenseViewModel.AccountId;
                            costOrExpense.CostOrExpenseCategoryId = costOrExpenseViewModel.CostOrExpenseCategoryId;
                            _db.Entry(costOrExpense).State = EntityState.Modified;

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
        // POST: /CostOrExpense/Delete/By ID
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                CostOrExpense costOrExpense = _db.CostOrExpenses.Find(id);
                if (costOrExpense != null)
                {
                    _db.CostOrExpenses.Remove(costOrExpense);
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

        private List<CostOrExpenseViewModel> GetCostOrExpenseDataList()
        {
            var dataList = _db.CostOrExpenses.ToList().Select(c => new CostOrExpense { CostOrExpenseId = c.CostOrExpenseId, Amount = c.Amount, CreateDate = c.CreateDate, Remarks = c.Remarks, AccountId = c.AccountId, CostOrExpenseCategoryId = c.CostOrExpenseCategoryId });

            var viewModels = dataList.Select(
                md => new CostOrExpenseViewModel
                {
                    CostOrExpenseId = md.CostOrExpenseId,
                    Amount = md.Amount,
                    CreateDate = md.CreateDate,
                    Remarks = md.Remarks,
                    AccountId = md.AccountId,
                    AccountName = md.Account != null ? md.Account.AccountName : "",
                    CostOrExpenseCategoryId = md.CostOrExpenseCategoryId,
                    CostOrExpenseCategoryName = md.CostOrExpenseCategory != null ? md.CostOrExpenseCategory.CostOrExpenseCategoryName : "",

                    ActionLink = KendoUiHelper.KendoUIGridActionLinkGenerate(md.CostOrExpenseId.ToString())
                }).OrderBy(o => o.CreateDate).ToList();

            return viewModels;
        }

        #endregion
    }
}
