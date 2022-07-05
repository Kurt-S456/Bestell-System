
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    [Display(Name = "Bestellung")]
    public partial class OrdOrder
    {
        public OrdOrder()
        {
            ProProducts = new HashSet<ProOrd>();
        }
        [Key]
        public Guid OrdId { get; set; }
        [Display(Name = "Bestellzeit")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime OrdTimeStamp { get; set; }
        [Display(Name = "Produkte")]
        public ICollection<ProOrd> ProProducts { get; set; }
        [Display(Name = "Benutzer")]
        public UsrUser UsrUser { get; set; } = null!;
        [Display(Name = "Status")]
        public OStOrderStatus OStStatus { get; set; } = null!;
    }
}
