using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    [Display(Name = "Station")]
    public partial class StaStation
    {
        public StaStation()
        {
            ShiShifts = new HashSet<ShiShift>();
            ProProducts = new HashSet<ProProduct>();    
        }
        [Key]
        public Guid StaId { get; set; }
        [Display(Name = "Bezeichnung")]
        public string StaName { get; set; } = null!;
        [Display(Name = "Beschreibung")]
        public string? StaDescription { get; set; }
        [Display(Name = "Veranstalltung")]
        public Guid StaEveId { get; set; }
        [Display(Name = "Veranstalltung")]
        public EveEvent StaEve { get; set; } = null!;
        [Display(Name = "Schichten")]
        public ICollection<ShiShift> ShiShifts { get; set; }
        [Display(Name = "Menu")]
        public ICollection<ProProduct> ProProducts  { get; set; }
    }
}
