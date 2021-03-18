using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMaker.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int No { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
