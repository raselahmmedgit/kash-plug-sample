using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KashPlugSample.Models
{
    public class CostsOrExpenseCategory
    {
        [Key]
        public int CostsOrExpenseCategoryId { get; set; }
        [DisplayName("Costs/Expenses Category Name")]
        [Required(ErrorMessage = "Costs/Expenses Category Name is required")]
        [MaxLength(200)]
        public string CostsOrExpenseCategoryName { get; set; }
    }
}