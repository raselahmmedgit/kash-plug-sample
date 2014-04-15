using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RnD.KashPlugSample.ViewModels
{
    public class SaleOrIncomeCategoryViewModel : BaseViewModel
    {
        [Key]
        public int SaleOrIncomeCategoryId { get; set; }
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "Product/Good Category Name is required")]
        [MaxLength(200)]
        public string SaleOrIncomeCategoryName { get; set; }
    }
}