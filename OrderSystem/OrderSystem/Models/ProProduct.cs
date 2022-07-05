using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystem.Models
{
    public partial class ProProduct
    {
        public ProProduct()
        {
            StaStations = new HashSet<StaStation>();
            OrdOrders = new HashSet<ProOrd>();    
        }
        [Key]
        public Guid ProId { get; set; }
        [Display(Name = "Bezeichnung")]
        public string ProName { get; set; } = null!;
        [Display(Name = "Beschreibung")]
        public string? ProDescription { get; set; }
        [Display(Name = "Farbe")]
        public string ProColor { get; set; } = null!;
        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Verkaufspreis")]
        public decimal ProPrice { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Einkaufspreis")]
        public decimal ProPriceBuy { get; set; }

        [Display(Name = "Staionen")]
        public ICollection<StaStation> StaStations { get; set; }
        [Display(Name = "Bestellungen")]
        public ICollection<ProOrd> OrdOrders { get; set; }
    }
}
