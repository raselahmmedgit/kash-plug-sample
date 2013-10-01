using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KashPlugSample.Models
{
    public class SaleOrIncomeCategory
    {
        [Key]
        public int SaleOrIncomeCategoryId { get; set; }
        [DisplayName("Product/Goods Category Name")]
        [Required(ErrorMessage = "Product/Goods Category Name is required")]
        [MaxLength(200)]
        public string SaleOrIncomeCategoryName { get; set; }
    }
}