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
    public class SaleOrIncomeCategoryController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        #region Action

        //
        // GET: /SaleOrIncomeCategory/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaleOrIncomeCategoryRead(KendoUiGridParam request)
        {
            var saleOrIncomeCategoryViewModels = GetSaleOrIncomeCategoryDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<SaleOrIncomeCategoryViewModel>(saleOrIncomeCategoryViewModels, request);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /SaleOrIncomeCategory/Details/By ID

        public ActionResult Details(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(id);
                if (saleOrIncomeCategory != null)
                {
                    var viewModel = new SaleOrIncomeCategoryViewModel() { SaleOrIncomeCategoryId = saleOrIncomeCategory.SaleOrIncomeCategoryId, SaleOrIncomeCategoryName = saleOrIncomeCategory.SaleOrIncomeCategoryName };
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
        // GET: /SaleOrIncomeCategory/Add

        public ActionResult Add()
        {
            var viewModel = new SaleOrIncomeCategoryViewModel() { SaleOrIncomeCategoryId = 0 };
            //return View();
            return PartialView("_AddOrEdit", viewModel);
        }

        //
        // GET: /SaleOrIncomeCategory/Edit/By ID

        public ActionResult Edit(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(id);
                if (saleOrIncomeCategory != null)
                {
                    var viewModel = new SaleOrIncomeCategoryViewModel() { SaleOrIncomeCategoryId = saleOrIncomeCategory.SaleOrIncomeCategoryId, SaleOrIncomeCategoryName = saleOrIncomeCategory.SaleOrIncomeCategoryName };
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
        // POST: /SaleOrIncomeCategory/Save

        [HttpPost]
        public ActionResult Save(SaleOrIncomeCategoryViewModel saleOrIncomeCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (saleOrIncomeCategoryViewModel.SaleOrIncomeCategoryId == 0)
                    {
                        var model = new SaleOrIncomeCategory() { SaleOrIncomeCategoryId = saleOrIncomeCategoryViewModel.SaleOrIncomeCategoryId, SaleOrIncomeCategoryName = saleOrIncomeCategoryViewModel.SaleOrIncomeCategoryName };
                        _db.SaleOrIncomeCategories.Add(model);
                    }
                    else //edit
                    {
                        SaleOrIncomeCategory saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(saleOrIncomeCategoryViewModel.SaleOrIncomeCategoryId);

                        if (saleOrIncomeCategory != null)
                        {

                            saleOrIncomeCategory.SaleOrIncomeCategoryId = saleOrIncomeCategoryViewModel.SaleOrIncomeCategoryId;
                            saleOrIncomeCategory.SaleOrIncomeCategoryName = saleOrIncomeCategoryViewModel.SaleOrIncomeCategoryName;
                            _db.Entry(saleOrIncomeCategory).State = EntityState.Modified;

                        }

                        return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.FalseString, MessageType.warn.ToString(), ExceptionHelper.ExceptionMessageForNullObject()));

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
        // POST: /SaleOrIncomeCategory/Delete/By ID
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                SaleOrIncomeCategory saleOrIncomeCategory = _db.SaleOrIncomeCategories.Find(id);
                if (saleOrIncomeCategory != null)
                {
                    _db.SaleOrIncomeCategories.Remove(saleOrIncomeCategory);
                    _db.SaveChanges();

                    return Json(new { status = Boolean.FalseString, messageType = MessageType.success.ToString(), messageText = "Deleted Successfully." }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { status = Boolean.FalseString, messageType = MessageType.warn.ToString(), messageText = ExceptionHelper.ExceptionMessageForNullObject() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { status = Boolean.FalseString, messageType = MessageType.error.ToString(), messageText = ExceptionHelper.ExceptionMessageFormat(ex) }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Method

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        private List<SaleOrIncomeCategoryViewModel> GetSaleOrIncomeCategoryDataList()
        {
            var dataList = _db.SaleOrIncomeCategories.ToList().Select(c => new SaleOrIncomeCategory { SaleOrIncomeCategoryId = c.SaleOrIncomeCategoryId, SaleOrIncomeCategoryName = c.SaleOrIncomeCategoryName });

            var viewModels = dataList.Select(
                md => new SaleOrIncomeCategoryViewModel
                {
                    SaleOrIncomeCategoryId = md.SaleOrIncomeCategoryId,
                    SaleOrIncomeCategoryName = md.SaleOrIncomeCategoryName,

                    ActionLink = KendoUiHelper.KendoUIGridActionLinkGenerate(md.SaleOrIncomeCategoryId.ToString())
                }).OrderBy(o => o.SaleOrIncomeCategoryName).ToList();

            return viewModels;
        }

        #endregion
    }
}
