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
    public class SaleOrIncomeViewModel : BaseViewModel
    {
        [Key]
        public int SaleOrIncomeId { get; set; }

        [DisplayName("Unit Price")]
        [Required(ErrorMessage = "Unit Price is required.")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [DisplayName("Processing Cost Rate")]
        public decimal ProcessCostRate { get; set; }

        [DisplayName("Extra Cost Amount")]
        public decimal ExtraCostAmount { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [DisplayName("Account")]
        [Required(ErrorMessage = "Select Account.")]
        public int AccountId { get; set; }
        [DisplayName("Account Name")]
        public string AccountName { get; set; }
        [ForeignKey("AccountId")]
        public virtual AccountViewModel AccountViewModel { get; set; }
        public List<SelectListItem> ddlAccounts { get; set; }

        [DisplayName("Product/Goods")]
        [Required(ErrorMessage = "Select Product/Goods Category.")]
        public int SaleOrIncomeCategoryId { get; set; }
        [DisplayName("Product/Goods Category Name")]
        public string SaleOrIncomeCategoryName { get; set; }
        [ForeignKey("SaleOrIncomeCategoryId")]
        public virtual SaleOrIncomeCategoryViewModel SaleOrIncomeCategoryViewModel { get; set; }
        public List<SelectListItem> ddlSaleOrIncomeCategories { get; set; }
    }
}