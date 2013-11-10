using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RnD.KashPlugSample.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        [Key]
        public int AccountId { get; set; }
        [DisplayName("Account Name")]
        [Required(ErrorMessage = "Account Name is required")]
        [MaxLength(200)]
        public string AccountName { get; set; }
    }
}