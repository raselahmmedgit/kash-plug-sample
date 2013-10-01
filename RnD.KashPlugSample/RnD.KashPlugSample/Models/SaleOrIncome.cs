using System;
using System.Collections.Generic;
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

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Required(ErrorMessage = "Select Product/Goods Category.")]
        public int SaleOrIncomeCategoryId { get; set; }
        [ForeignKey("SaleOrIncomeCategoryId")]
        public virtual SaleOrIncomeCategory SaleOrIncomeCategory { get; set; }
    }
}