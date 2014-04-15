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
    public class CurrencyController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        #region Action

        //
        // GET: /Currency/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CurrencyRead(KendoUiGridParam request)
        {
            var currencyViewModels = GetCurrencyDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<CurrencyViewModel>(currencyViewModels, request);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Currency/Details/By ID

        public ActionResult Details(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var currency = _db.Currencies.Find(id);
                if (currency != null)
                {
                    var viewModel = new CurrencyViewModel() { CurrencyId = currency.CurrencyId, CurrencyName = currency.CurrencyName };
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
        // GET: /Currency/Add

        public ActionResult Add()
        {
            var viewModel = new CurrencyViewModel() { CurrencyId = 0 };
            //return View();
            return PartialView("_AddOrEdit", viewModel);
        }

        //
        // GET: /Currency/Edit/By ID

        public ActionResult Edit(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var currency = _db.Currencies.Find(id);
                if (currency != null)
                {
                    var viewModel = new CurrencyViewModel() { CurrencyId = currency.CurrencyId, CurrencyName = currency.CurrencyName };
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
        // POST: /Currency/Save

        [HttpPost]
        public ActionResult Save(CurrencyViewModel currencyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (currencyViewModel.CurrencyId == 0)
                    {
                        var model = new Currency() { CurrencyId = currencyViewModel.CurrencyId, CurrencyName = currencyViewModel.CurrencyName };
                        _db.Currencies.Add(model);
                    }
                    else //edit
                    {
                        Currency currency = _db.Currencies.Find(currencyViewModel.CurrencyId);

                        if (currency != null)
                        {

                            currency.CurrencyId = currencyViewModel.CurrencyId;
                            currency.CurrencyName = currencyViewModel.CurrencyName;
                            _db.Entry(currency).State = EntityState.Modified;

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
        // POST: /Currency/Delete/By ID
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Currency currency = _db.Currencies.Find(id);
                if (currency != null)
                {
                    _db.Currencies.Remove(currency);
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

        private List<CurrencyViewModel> GetCurrencyDataList()
        {
            var dataList = _db.Currencies.ToList().Select(c => new Currency { CurrencyId = c.CurrencyId, CurrencyName = c.CurrencyName });

            var viewModels = dataList.Select(
                md => new CurrencyViewModel
                {
                    CurrencyId = md.CurrencyId,
                    CurrencyName = md.CurrencyName,

                    ActionLink = KendoUiHelper.KendoUIGridActionLinkGenerate(md.CurrencyId.ToString())
                }).OrderBy(o => o.CurrencyName).ToList();

            return viewModels;
        }

        #endregion
    }
}
