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
    public class AppSettingController : Controller
    {
        private AppDbContext _db = new AppDbContext();

        #region Action

        //
        // GET: /AppSetting/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AppSettingRead(KendoUiGridParam request)
        {
            var appSettingsViewModels = GetAppSettingDataList().AsQueryable();
            var models = KendoUiHelper.ParseGridData<AppSettingsViewModel>(appSettingsViewModels, request);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /AppSetting/Details/By ID

        public ActionResult Details(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var appSettings = _db.AppSettings.Find(id);
                if (appSettings != null)
                {
                    var viewModel = new AppSettingsViewModel() { AppSettingsId = appSettings.AppSettingsId, Name = appSettings.Name };
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
        // GET: /AppSetting/Add

        public ActionResult Add()
        {
            var viewModel = new AppSettingsViewModel() { AppSettingsId = 0 };
            //return View();
            return PartialView("_AddOrEdit", viewModel);
        }

        //
        // GET: /AppSetting/Edit/By ID

        public ActionResult Edit(int id)
        {
            var errorViewModel = new ErrorViewModel();

            try
            {
                var appSetting = _db.AppSettings.Find(id);
                if (appSetting != null)
                {
                    var viewModel = new AppSettingsViewModel() { AppSettingsId = appSetting.AppSettingsId, Name = appSetting.Name };
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
        // POST: /AppSetting/Save

        [HttpPost]
        public ActionResult Save(AppSettingsViewModel appSettingsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (appSettingsViewModel.AppSettingsId == 0)
                    {
                        var model = new AppSettings() { AppSettingsId = appSettingsViewModel.AppSettingsId, Name = appSettingsViewModel.Name };
                        _db.AppSettings.Add(model);
                    }
                    else //edit
                    {
                        AppSettings appSettings = _db.AppSettings.Find(appSettingsViewModel.AppSettingsId);

                        if (appSettings != null)
                        {

                            appSettings.AppSettingsId = appSettingsViewModel.AppSettingsId;
                            appSettings.Name = appSettingsViewModel.Name;
                            _db.Entry(appSettings).State = EntityState.Modified;

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
        // POST: /AppSetting/Delete/By ID
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                AppSettings appSettings = _db.AppSettings.Find(id);
                if (appSettings != null)
                {
                    _db.AppSettings.Remove(appSettings);
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

        private List<AppSettingsViewModel> GetAppSettingDataList()
        {
            var dataList = _db.AppSettings.ToList().Select(c => new AppSettings { AppSettingsId = c.AppSettingsId, Name = c.Name });

            var viewModels = dataList.Select(
                md => new AppSettingsViewModel
                {
                    AppSettingsId = md.AppSettingsId,
                    Name = md.Name,

                    ActionLink = KendoUiHelper.KendoUIGridActionLinkGenerate(md.AppSettingsId.ToString())
                }).OrderBy(o => o.Name).ToList();

            return viewModels;
        }

        #endregion

    }
}
