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
    public class SaleOrIncomeController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        #region Action

        //
        // GET: /SaleOrIncome/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaleOrIncomeRead(KendoUiGridParam request)
        {
            var saleOrIncomeViewModels = GetSaleOrIncomeDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<SaleOrIncomeViewModel>(saleOrIncomeViewModels, request);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /SaleOrIncome/Details/By ID

        public ActionResult Details(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var saleOrIncome = _db.SaleOrIncomes.Find(id);
                if (saleOrIncome != null)
                {
                    var viewModel = new SaleOrIncomeViewModel() { SaleOrIncomeId = saleOrIncome.SaleOrIncomeId, UnitPrice = saleOrIncome.UnitPrice, Quantity = saleOrIncome.Quantity, ProcessCostRate = saleOrIncome.ProcessCostRate, ExtraCostAmount = saleOrIncome.ExtraCostAmount, CreateDate = saleOrIncome.CreateDate, Remarks = saleOrIncome.Remarks, AccountId = saleOrIncome.AccountId, AccountName = saleOrIncome.Account != null ? saleOrIncome.Account.AccountName : "", SaleOrIncomeCategoryId = saleOrIncome.SaleOrIncomeCategoryId, SaleOrIncomeCategoryName = saleOrIncome.SaleOrIncomeCategory != null ? saleOrIncome.SaleOrIncomeCategory.SaleOrIncomeCategoryName : "" };

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
        // GET: /SaleOrIncome/Add

        public ActionResult Add()
        {
            var viewModel = new SaleOrIncomeViewModel();

            var accountList = SelectListItemExtension.PopulateDropdownList(_db.Accounts.ToList<Account>(), "AccountId", "AccountName").ToList();
            var saleOrIncomeCategoryList = SelectListItemExtension.PopulateDropdownList(_db.SaleOrIncomeCategories.ToList<SaleOrIncomeCategory>(), "SaleOrIncomeCategoryId", "SaleOrIncomeCategoryName").ToList();

            viewModel.SaleOrIncomeCategoryId = 0;
            viewModel.UnitPrice = 0;
            viewModel.Quantity = 1;
            viewModel.CreateDate = DateTime.Now;
            viewModel.ddlAccounts = accountList;
            viewModel.ddlSaleOrIncomeCategories = saleOrIncomeCategoryList;

            //return View();
            return PartialView("_AddOrEdit", viewModel);
        }

        //
        // GET: /SaleOrIncome/Edit/By ID

        public ActionResult Edit(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var saleOrIncome = _db.SaleOrIncomes.Find(id);
                if (saleOrIncome != null)
                {
                    var accountList = SelectListItemExtension.PopulateDropdownList(_db.Accounts.ToList<Account>(), "AccountId", "AccountName", isEdit: true, selectedValue: saleOrIncome.AccountId.ToString()).ToList();
                    var saleOrIncomeCategoryList = SelectListItemExtension.PopulateDropdownList(_db.SaleOrIncomeCategories.ToList<SaleOrIncomeCategory>(), "SaleOrIncomeCategoryId", "SaleOrIncomeCategoryName", isEdit: true, selectedValue: saleOrIncome.SaleOrIncomeCategoryId.ToString()).ToList();

                    var viewModel = new SaleOrIncomeViewModel() { SaleOrIncomeId = saleOrIncome.SaleOrIncomeId, UnitPrice = saleOrIncome.UnitPrice, Quantity = saleOrIncome.Quantity, ProcessCostRate = saleOrIncome.ProcessCostRate, ExtraCostAmount = saleOrIncome.ExtraCostAmount, CreateDate = saleOrIncome.CreateDate, Remarks = saleOrIncome.Remarks, AccountId = saleOrIncome.AccountId, AccountName = saleOrIncome.Account != null ? saleOrIncome.Account.AccountName : "", ddlAccounts = accountList, SaleOrIncomeCategoryId = saleOrIncome.SaleOrIncomeCategoryId, SaleOrIncomeCategoryName = saleOrIncome.SaleOrIncomeCategory != null ? saleOrIncome.SaleOrIncomeCategory.SaleOrIncomeCategoryName : "", ddlSaleOrIncomeCategories = saleOrIncomeCategoryList };

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
        // POST: /SaleOrIncome/Save

        [HttpPost]
        public ActionResult Save(SaleOrIncomeViewModel saleOrIncomeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (saleOrIncomeViewModel.SaleOrIncomeId == 0 && saleOrIncomeViewModel.ActionName == "Add")
                    {
                        var model = new SaleOrIncome() { SaleOrIncomeId = saleOrIncomeViewModel.SaleOrIncomeId, UnitPrice = saleOrIncomeViewModel.UnitPrice, Quantity = saleOrIncomeViewModel.Quantity, ProcessCostRate = saleOrIncomeViewModel.ProcessCostRate, ExtraCostAmount = saleOrIncomeViewModel.ExtraCostAmount, CreateDate = saleOrIncomeViewModel.CreateDate, Remarks = saleOrIncomeViewModel.Remarks, AccountId = saleOrIncomeViewModel.AccountId, SaleOrIncomeCategoryId = saleOrIncomeViewModel.SaleOrIncomeCategoryId };
                        _db.SaleOrIncomes.Add(model);
                    }
                    else if (saleOrIncomeViewModel.ActionName == "Edit") //edit
                    {
                        SaleOrIncome saleOrIncome = _db.SaleOrIncomes.Find(saleOrIncomeViewModel.SaleOrIncomeId);

                        if (saleOrIncome != null)
                        {

                            saleOrIncome.SaleOrIncomeId = saleOrIncomeViewModel.SaleOrIncomeId;
                            saleOrIncome.UnitPrice = saleOrIncomeViewModel.UnitPrice;
                            saleOrIncome.Quantity = saleOrIncomeViewModel.Quantity;
                            saleOrIncome.ProcessCostRate = saleOrIncomeViewModel.ProcessCostRate;
                            saleOrIncome.ExtraCostAmount = saleOrIncomeViewModel.ExtraCostAmount;
                            saleOrIncome.CreateDate = saleOrIncomeViewModel.CreateDate;
                            saleOrIncome.Remarks = saleOrIncomeViewModel.Remarks;
                            saleOrIncome.AccountId = saleOrIncomeViewModel.AccountId;
                            saleOrIncome.SaleOrIncomeCategoryId = saleOrIncomeViewModel.SaleOrIncomeCategoryId;
                            _db.Entry(saleOrIncome).State = EntityState.Modified;

                        }
                        else
                        {
                            return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.FalseString, MessageType.warning.ToString(), ExceptionHelper.ExceptionMessageForNullObject()));
                        }
                    }


                    _db.SaveChanges();

                    //return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), "Saved Successfully."));
                    return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, saleOrIncomeViewModel.ActionName, MessageType.success.ToString(), "Saved Successfully."));

                }

                return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), ExceptionHelper.ModelStateErrorFormat(ModelState)));
            }
            catch (Exception ex)
            {
                return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), ExceptionHelper.ExceptionMessageFormat(ex)));
            }
        }

        //
        // POST: /SaleOrIncome/Delete/By ID
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                SaleOrIncome saleOrIncome = _db.SaleOrIncomes.Find(id);
                if (saleOrIncome != null)
                {
                    _db.SaleOrIncomes.Remove(saleOrIncome);
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

        private List<SaleOrIncomeViewModel> GetSaleOrIncomeDataList()
        {
            var dataList = _db.SaleOrIncomes.ToList().Select(c => new SaleOrIncome { SaleOrIncomeId = c.SaleOrIncomeId, UnitPrice = c.UnitPrice, Quantity = c.Quantity, ProcessCostRate = c.ProcessCostRate, ExtraCostAmount = c.ExtraCostAmount, CreateDate = c.CreateDate, Remarks = c.Remarks, AccountId = c.AccountId, Account = c.Account, SaleOrIncomeCategoryId = c.SaleOrIncomeCategoryId, SaleOrIncomeCategory = c.SaleOrIncomeCategory });

            var viewModels = dataList.Select(
                md => new SaleOrIncomeViewModel
                {
                    SaleOrIncomeId = md.SaleOrIncomeId,
                    UnitPrice = md.UnitPrice,
                    Quantity = md.Quantity,
                    ProcessCostRate = md.ProcessCostRate,
                    ExtraCostAmount = md.ExtraCostAmount,
                    CreateDate = md.CreateDate,
                    Remarks = md.Remarks,
                    AccountId = md.AccountId,
                    AccountName = md.Account != null ? md.Account.AccountName : "",
                    SaleOrIncomeCategoryId = md.SaleOrIncomeCategoryId,
                    SaleOrIncomeCategoryName = md.SaleOrIncomeCategory != null ? md.SaleOrIncomeCategory.SaleOrIncomeCategoryName : "",

                    ActionLink = KendoUiHelper.KendoUIGridActionLinkGenerate(md.SaleOrIncomeId.ToString())
                }).OrderBy(o => o.CreateDate).ToList();

            return viewModels;
        }

        #endregion
    }
}
