using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KashPlugSample.Models
{
    public class AppSettings
    {
        [Key]
        public int AppSettingsId { get; set; }
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}