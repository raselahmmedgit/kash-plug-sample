using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KashPlugSample.Models
{
    public class SaleOrIncome
    {
        [Key]
        public int SaleOrIncomeId { get; set; }

        [DisplayName("Unit Price")]
        [Required(ErrorMessage = "Unit Price is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Unit Price could not less then 1.")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Quantity could not less then 1.")]
        public int Quantity { get; set; }

        [DisplayName("Processing Cost")]
        public decimal ProcessCostRate { get; set; }

        [DisplayName("Extra Cost Amount")]
        public decimal ExtraCostAmount { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Select Account.")]
        [Range(1, long.MaxValue, ErrorMessage = "Select Account.")]
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Required(ErrorMessage = "Select Product/Goods Category.")]
        [Range(1, long.MaxValue, ErrorMessage = "Select Product/Goods Category.")]
        public int SaleOrIncomeCategoryId { get; set; }
        [ForeignKey("SaleOrIncomeCategoryId")]
        public virtual SaleOrIncomeCategory SaleOrIncomeCategory { get; set; }
    }
}