using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RnD.KashPlugSample.Models
{
    public class CostsOrExpense
    {
        [Key]
        public int CostsOrExpenseId { get; set; }

        [DisplayName("Amount")]
        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Required(ErrorMessage = "Select Costs/Expenses Category.")]
        public int CostsOrExpenseCategoryId { get; set; }
        [ForeignKey("CostsOrExpenseCategoryId")]
        public virtual CostsOrExpenseCategory CostsOrExpenseCategory { get; set; }
    }
}