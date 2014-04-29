using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Helpers;
using RnD.KashPlugSample.ViewModels;
using RnD.KashPlugSample.Models;

namespace RnD.KashPlugSample.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        public ActionResult Index()
        {
            return View();
        }

        //LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        //Register
        public ActionResult Register()
        {
            return View();
        }

        //ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }


        public JsonResult DashboardGridRead(KendoUiGridParam request)
        {
            var accountViewModels = GetDashboardGridDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<DashboardGridViewModel>(accountViewModels, request);

            return Json(models, JsonRequestBehavior.AllowGet);
        }


        #region Methods


        private List<DashboardGridViewModel> GetDashboardGridDataList()
        {
            var inDataList = _db.SaleOrIncomes.ToList().Select(inData => new DashboardGridViewModel { SaleOrIncomeId = inData.SaleOrIncomeId, Title = inData.SaleOrIncomeCategory != null ? inData.SaleOrIncomeCategory.SaleOrIncomeCategoryName : "", CreateDate = inData.CreateDate, InAmount = Math.Ceiling(inData.UnitPrice * inData.Quantity) });

            var outDataList = _db.CostOrExpenses.ToList().Select(outData => new DashboardGridViewModel { CostOrExpenseId = outData.CostOrExpenseId, Title = outData.CostOrExpenseCategory != null ? outData.CostOrExpenseCategory.CostOrExpenseCategoryName : "", CreateDate = outData.CreateDate, OutAmount = Math.Ceiling(outData.Amount) });

            var dashboardGridViewModelList = new List<DashboardGridViewModel>();

            dashboardGridViewModelList.AddRange(inDataList);
            dashboardGridViewModelList.AddRange(outDataList);

            var viewModels = dashboardGridViewModelList.Select(
                md => new DashboardGridViewModel
                {
                    SaleOrIncomeId = md.SaleOrIncomeId,
                    CostOrExpenseId = md.CostOrExpenseId,

                    Title = md.Title,

                    InAmount = md.InAmount,
                    OutAmount = md.OutAmount,
                    BalanceAmount = Math.Ceiling(md.InAmount - md.OutAmount),
                    CreateDate = md.CreateDate

                }).OrderBy(o => o.CreateDate).ToList();

            return viewModels;
        }


        #endregion
    }
}
