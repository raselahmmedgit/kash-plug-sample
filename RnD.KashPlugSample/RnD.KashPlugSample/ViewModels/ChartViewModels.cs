using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.KashPlugSample.ViewModels
{
    public class MorrisBarViewModel
    {
        public string xkey { get; set; }
        public string[] ykeys { get; set; }
        public string[] labels { get; set; }
        public MorrisBarDataViewModel[] data { get; set; }
    }

    public class MorrisBarDataViewModel
    {
        public string xkeyValue { get; set; }
        public decimal[] Values { get; set; }
    }

    public class MorrisDonutViewModel
    {
        public MorrisDonutDataViewModel[] data { get; set; }
    }

    public class MorrisDonutDataViewModel
    {
        public string label { get; set; }
        public decimal value { get; set; }
    }

    public class FlotBarViewModel
    {
        public FlotBarDataViewModel[] data { get; set; }
    }

    public class FlotBarDataViewModel
    {
        public string label { get; set; }
        public decimal value { get; set; }
    }

    public class FlotPieViewModel
    {
        public FlotPieDataViewModel[] data { get; set; }
    }

    public class FlotPieDataViewModel
    {
        public string label { get; set; }
        public decimal data { get; set; }
    }
}