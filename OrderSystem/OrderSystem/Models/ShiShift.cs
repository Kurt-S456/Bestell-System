using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    [Display(Name = "Schicht")]
    public partial class ShiShift
    {
        public ShiShift()
        {
            Staff = new HashSet<PerShi>();
            Orders = new HashSet<OrdOrder>();
        }
        [Key]
        public Guid ShiId { get; set; }
        [Display(Name = "Bezeichnung")]
        public string ShiTitel { get; set; } = null!;
        [Display(Name = "Anfang")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiStartDateTime { get; set; }
        [Display(Name = "Ende")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ShiEndDateTime { get; set; }
        
        public Guid ShiStaId { get; set; }
        [Display(Name = "Station")]
        public StaStation? ShiSta { get; set; }
        [Display(Name = "Personal")]
        public ICollection<PerShi> Staff { get; set; }
        [Display(Name = "Bestellungen")]
        public ICollection<OrdOrder> Orders { get; set; }
    }
}
