using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RnD.KashPlugSample.Models
{
    public class CostOrExpense
    {
        [Key]
        public int CostOrExpenseId { get; set; }

        [DisplayName("Amount")]
        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Amount could not less then 1.")]
        public decimal Amount { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Select Account.")]
        [Range(1, long.MaxValue, ErrorMessage = "Select Account.")]
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Required(ErrorMessage = "Select Cost/Expense Category.")]
        [Range(1, long.MaxValue, ErrorMessage = "Select Cost/Expense Category.")]
        public int CostOrExpenseCategoryId { get; set; }
        [ForeignKey("CostOrExpenseCategoryId")]
        public virtual CostOrExpenseCategory CostOrExpenseCategory { get; set; }
    }
}