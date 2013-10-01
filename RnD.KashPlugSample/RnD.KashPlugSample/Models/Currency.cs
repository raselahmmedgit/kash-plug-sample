using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KashPlugSample.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        [DisplayName("Currency Name")]
        [Required(ErrorMessage = "Currency Name is required")]
        [MaxLength(200)]
        public string CurrencyName { get; set; }
    }
}