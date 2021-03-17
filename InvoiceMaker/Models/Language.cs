using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMaker.Models
{
    public class Language
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }
    }
}
