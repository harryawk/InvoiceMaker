using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InvoiceMaker.Models
{
    public class Invoice
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        [IgnoreDataMember]
        public int To { get; set; }
        [ForeignKey("To")]
        public virtual Company Company { get; set; }

        public string DiscountName { get; set; }
        public double DiscountAmount { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public DateTime InvoiceDue { get; set; }

        [Required]
        [IgnoreDataMember]
        public int PurchaseOrderID { get; set; }
        [ForeignKey("PurchaseOrderID")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [Required]
        [IgnoreDataMember]
        public int LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public virtual Language Language { get; set; }
        
        [Required]
        [IgnoreDataMember]
        public int CurrencyID { get; set; }
        [ForeignKey("CurrencyID")]
        public virtual Currency Currency { get; set; }


    }
}
