using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    [Display(Name = "Veranstaltung")]
    public partial class EveEvent
    {
        public EveEvent()
        {
            StaStations = new HashSet<StaStation>();
        }
        [Key]
        public Guid EveId { get; set; }
        [Display(Name = "Name")]
        public string EveName { get; set; } = null!;
        [Display(Name = "Startdatum")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EveStartDate { get; set; }
        [Display(Name = "Enddatum")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EveEndDate { get; set; }
        [Display(Name = "Stationen")]
        public ICollection<StaStation> StaStations { get; set; }
    }
}
