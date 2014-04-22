using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.ViewModels;

namespace RnD.KashPlugSample.Controllers
{
    public class ChartController : Controller
    {
        //
        // GET: /Chart/

        #region Morris Charts

        [HttpPost]
        public JsonResult MorrisBar()
        {
            var model = GetMorrisBarData();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MorrisDonut()
        {
            var model = GetMorrisDonutData();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        private MorrisBarViewModel GetMorrisBarData()
        {
            var morrisBarViewModel = new MorrisBarViewModel();



            return morrisBarViewModel;
        }

        private MorrisDonutViewModel GetMorrisDonutData()
        {
            var morrisDonutViewModel = new MorrisDonutViewModel();

            var morrisDonutDataViewModelList = new List<MorrisDonutDataViewModel>();

            var morrisDonutDataViewModel1 = new MorrisDonutDataViewModel { label = "Download Sales", value = 12 };

            var morrisDonutDataViewModel2 = new MorrisDonutDataViewModel { label = "In-Store Sales", value = 30 };

            var morrisDonutDataViewModel3 = new MorrisDonutDataViewModel { label = "Mail-Order Sales", value = 20 };

            morrisDonutDataViewModelList.Add(morrisDonutDataViewModel1);
            morrisDonutDataViewModelList.Add(morrisDonutDataViewModel2);
            morrisDonutDataViewModelList.Add(morrisDonutDataViewModel3);

            morrisDonutViewModel.data = morrisDonutDataViewModelList.ToArray();

            return morrisDonutViewModel;
        }

        #endregion

        #region Flot Charts

        [HttpPost]
        public JsonResult FlotBar()
        {
            var model = GetFlotBarData();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FlotPie()
        {
            var model = GetFlotPieData();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        private FlotBarViewModel GetFlotBarData()
        {
            var flotBarViewModel = new FlotBarViewModel();

            var flotBarDataViewModelList = new List<FlotBarDataViewModel>();

            var flotBarDataViewModel1 = new FlotBarDataViewModel { label = "January", value = 12 };

            var flotBarDataViewModel2 = new FlotBarDataViewModel { label = "February", value = 30 };

            var flotBarDataViewModel3 = new FlotBarDataViewModel { label = "March", value = 20 };

            var flotBarDataViewModel4 = new FlotBarDataViewModel { label = "April", value = 20 };

            var flotBarDataViewModel5 = new FlotBarDataViewModel { label = "May", value = 14 };

            var flotBarDataViewModel6 = new FlotBarDataViewModel { label = "June", value = 8 };

            var flotBarDataViewModel7 = new FlotBarDataViewModel { label = "July", value = 40 };

            flotBarDataViewModelList.Add(flotBarDataViewModel1);
            flotBarDataViewModelList.Add(flotBarDataViewModel2);
            flotBarDataViewModelList.Add(flotBarDataViewModel3);
            flotBarDataViewModelList.Add(flotBarDataViewModel4);
            flotBarDataViewModelList.Add(flotBarDataViewModel5);
            flotBarDataViewModelList.Add(flotBarDataViewModel6);
            flotBarDataViewModelList.Add(flotBarDataViewModel7);


            flotBarViewModel.data = flotBarDataViewModelList.ToArray();

            return flotBarViewModel;
        }

        private FlotPieViewModel GetFlotPieData()
        {
            var flotDonutViewModel = new FlotPieViewModel();

            var flotPieDataViewModelList = new List<FlotPieDataViewModel>();

            var flotPieDataViewModel1 = new FlotPieDataViewModel { label = "Download Sales", data = 12 };

            var flotPieDataViewModel2 = new FlotPieDataViewModel { label = "In-Store Sales", data = 30 };

            var flotPieDataViewModel3 = new FlotPieDataViewModel { label = "Mail-Order Sales", data = 20 };

            flotPieDataViewModelList.Add(flotPieDataViewModel1);
            flotPieDataViewModelList.Add(flotPieDataViewModel2);
            flotPieDataViewModelList.Add(flotPieDataViewModel3);

            flotDonutViewModel.data = flotPieDataViewModelList.ToArray();

            return flotDonutViewModel;
        }

        #endregion
    }
}
