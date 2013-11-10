using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RnD.KashPlugSample.ViewModels
{
    public class BaseViewModel
    {
        [NotMapped]
        public virtual string ActionLink { get; set; }

        [NotMapped]
        public virtual bool HasCreate { get; set; }

        [NotMapped]
        public virtual bool HasUpdate { get; set; }

        [NotMapped]
        public virtual bool HasDelete { get; set; }
    }
}