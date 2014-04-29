using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace RnD.KashPlugSample.ViewModels
{
    public class DashboardGridViewModel
    {
        public int SaleOrIncomeId { get; set; }

        public int CostOrExpenseId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Credit")]
        public decimal InAmount { get; set; }

        [DisplayName("Debit")]
        public decimal OutAmount { get; set; }

        [DisplayName("Balance")]
        public decimal BalanceAmount { get; set; }

        [DisplayName("Total")]
        public decimal TotalAmount { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
    }
}