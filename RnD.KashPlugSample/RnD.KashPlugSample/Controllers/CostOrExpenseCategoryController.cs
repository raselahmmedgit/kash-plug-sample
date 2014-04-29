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
    public class CostOrExpenseCategoryController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        #region Action

        //
        // GET: /CostOrExpenseCategory/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CostOrExpenseCategoryRead(KendoUiGridParam request)
        {
            var costOrExpenseCategoryViewModels = GetCostOrExpenseCategoryDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<CostOrExpenseCategoryViewModel>(costOrExpenseCategoryViewModels, request);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /CostOrExpenseCategory/Details/By ID

        public ActionResult Details(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var costOrExpenseCategory = _db.CostOrExpenseCategories.Find(id);
                if (costOrExpenseCategory != null)
                {
                    var viewModel = new CostOrExpenseCategoryViewModel() { CostOrExpenseCategoryId = costOrExpenseCategory.CostOrExpenseCategoryId, CostOrExpenseCategoryName = costOrExpenseCategory.CostOrExpenseCategoryName };
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
        // GET: /CostOrExpenseCategory/Add

        public ActionResult Add()
        {
            var viewModel = new CostOrExpenseCategoryViewModel() { CostOrExpenseCategoryId = 0 };
            //return View();
            return PartialView("_AddOrEdit", viewModel);
        }

        //
        // GET: /CostOrExpenseCategory/Edit/By ID

        public ActionResult Edit(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var costOrExpenseCategory = _db.CostOrExpenseCategories.Find(id);
                if (costOrExpenseCategory != null)
                {
                    var viewModel = new CostOrExpenseCategoryViewModel() { CostOrExpenseCategoryId = costOrExpenseCategory.CostOrExpenseCategoryId, CostOrExpenseCategoryName = costOrExpenseCategory.CostOrExpenseCategoryName };
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
        // POST: /CostOrExpenseCategory/Save

        [HttpPost]
        public ActionResult Save(CostOrExpenseCategoryViewModel costOrExpenseCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (costOrExpenseCategoryViewModel.CostOrExpenseCategoryId == 0 && costOrExpenseCategoryViewModel.ActionName == "Add")
                    {
                        var model = new CostOrExpenseCategory() { CostOrExpenseCategoryId = costOrExpenseCategoryViewModel.CostOrExpenseCategoryId, CostOrExpenseCategoryName = costOrExpenseCategoryViewModel.CostOrExpenseCategoryName };
                        _db.CostOrExpenseCategories.Add(model);
                    }
                    else if (costOrExpenseCategoryViewModel.ActionName == "Edit") //edit
                    {
                        CostOrExpenseCategory costOrExpenseCategory = _db.CostOrExpenseCategories.Find(costOrExpenseCategoryViewModel.CostOrExpenseCategoryId);

                        if (costOrExpenseCategory != null)
                        {

                            costOrExpenseCategory.CostOrExpenseCategoryId = costOrExpenseCategoryViewModel.CostOrExpenseCategoryId;
                            costOrExpenseCategory.CostOrExpenseCategoryName = costOrExpenseCategoryViewModel.CostOrExpenseCategoryName;
                            _db.Entry(costOrExpenseCategory).State = EntityState.Modified;

                        }
                        else
                        {
                            return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.FalseString, MessageType.warning.ToString(), ExceptionHelper.ExceptionMessageForNullObject()));
                        }
                    }


                    _db.SaveChanges();

                    //return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), "Saved Successfully."));
                    return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, costOrExpenseCategoryViewModel.ActionName, MessageType.success.ToString(), "Saved Successfully."));

                }

                return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), ExceptionHelper.ModelStateErrorFormat(ModelState)));
            }
            catch (Exception ex)
            {
                return Content(KendoUiHelper.GetKendoUiWindowAjaxSuccessMethod(Boolean.TrueString, MessageType.success.ToString(), ExceptionHelper.ExceptionMessageFormat(ex)));
            }
        }

        //
        // POST: /CostOrExpenseCategory/Delete/By ID
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                CostOrExpenseCategory costOrExpenseCategory = _db.CostOrExpenseCategories.Find(id);
                if (costOrExpenseCategory != null)
                {
                    _db.CostOrExpenseCategories.Remove(costOrExpenseCategory);
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

        private List<CostOrExpenseCategoryViewModel> GetCostOrExpenseCategoryDataList()
        {
            var dataList = _db.CostOrExpenseCategories.ToList().Select(c => new CostOrExpenseCategory { CostOrExpenseCategoryId = c.CostOrExpenseCategoryId, CostOrExpenseCategoryName = c.CostOrExpenseCategoryName });

            var viewModels = dataList.Select(
                md => new CostOrExpenseCategoryViewModel
                {
                    CostOrExpenseCategoryId = md.CostOrExpenseCategoryId,
                    CostOrExpenseCategoryName = md.CostOrExpenseCategoryName,

                    ActionLink = KendoUiHelper.KendoUIGridActionLinkGenerate(md.CostOrExpenseCategoryId.ToString())
                }).OrderBy(o => o.CostOrExpenseCategoryName).ToList();

            return viewModels;
        }

        #endregion

    }
}
