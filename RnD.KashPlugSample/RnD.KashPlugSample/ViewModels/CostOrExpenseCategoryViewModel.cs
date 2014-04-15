using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KashPlugSample.ViewModels
{
    public class CostOrExpenseCategoryViewModel : BaseViewModel
    {
        [Key]
        public int CostOrExpenseCategoryId { get; set; }
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "Cost/Expense Category Name is required")]
        [MaxLength(200)]
        public string CostOrExpenseCategoryName { get; set; }
    }
}