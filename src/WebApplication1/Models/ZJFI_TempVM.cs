using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ZJFI_TempVM
    {
        [Display(Name ="사이트")]
        [Required(ErrorMessage = "*")]
        public string site_ref { get; set; }
        public string Desc { get; set; }
        public string Test { get; set; }
    }
}
