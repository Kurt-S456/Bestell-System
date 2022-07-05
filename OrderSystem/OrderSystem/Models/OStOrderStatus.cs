using System;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    [Display(Name = "Bestellungsstatus")]
    public partial class OStOrderStatus
    {
        [Key]
        public Guid OStId { get; set; }
        [Display(Name = "Bezeichung")]
        public string OStTitle { get; set; } = null!;
        [Display(Name = "Farbe")]
        public string OStColor { get; set; } = null!;
        [Display(Name = "Abgeschlossen")]
        public bool OStIsComplete { get; set; }
    }
}
