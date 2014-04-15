using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KashPlugSample.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "Account Name is required")]
        [MaxLength(200)]
        public string AccountName { get; set; }
    }
}