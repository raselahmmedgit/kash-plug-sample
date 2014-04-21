using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace RnD.KashPlugSample.ViewModels
{
    public class CostOrExpenseViewModel : BaseViewModel
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

        [DisplayName("Account")]
        [Required(ErrorMessage = "Select Account.")]
        [Range(1, long.MaxValue, ErrorMessage = "Select Account.")]
        public int AccountId { get; set; }
        [DisplayName("Account Name")]
        public string AccountName { get; set; }
        [ForeignKey("AccountId")]
        public virtual AccountViewModel AccountViewModel { get; set; }
        public List<SelectListItem> ddlAccounts { get; set; }

        [DisplayName("Cost/Expense")]
        [Required(ErrorMessage = "Select Cost/Expense Category.")]
        [Range(1, long.MaxValue, ErrorMessage = "Select Cost/Expense Category.")]
        public int CostOrExpenseCategoryId { get; set; }
        [DisplayName("Cost/Expense Category Name")]
        public string CostOrExpenseCategoryName { get; set; }
        [ForeignKey("CostOrExpenseCategoryId")]
        public virtual CostOrExpenseCategoryViewModel CostOrExpenseCategoryViewModel { get; set; }
        public List<SelectListItem> ddlCostOrExpenseCategories { get; set; }
    }
}