using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public class Cust
    {
        [DisplayName("Müşteri No")]
        public Guid ID { get; set; }

        [DisplayName("Müşteri Adı")]
        [Required(ErrorMessage = "Zorunludur")]
        public string Name { get; set; }

        [DisplayName("Müşteri Borcu")]
        [DisplayFormat(DataFormatString = "{0:c}")]  
        //[RegularExpression(@"(^(?!0*\.0+$)\d*(?:\.\d+)?$)", ErrorMessage = "Geçerli yazım formatı 12.75 ")]
        public decimal Debt { get; set; }

        [DisplayName("Aktif / Pasif")]        
        public bool Disabled { get; set; }

        [DisplayName("Müşteri Açılış")]
        public DateTimeOffset? OpeningDate { get; set; }
    }
}