using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystem.Models
{
    [Display(Name = "Person")]
    public class PerPerson
    {
        public PerPerson()
        {
            Orders = new HashSet<OrdOrder>();
            Shifts = new HashSet<PerShi>();
        }

        [Key]
        public Guid PerId { get; set; }

        [Display(Name = "Vorname")]
        public string? PerFirstName { get; set; }

        [Display(Name = "Nachname")]
        public string? PerLastName { get; set; }

        [NotMapped]
        public string? FullName
        {
            get
            {
                return PerFirstName+ " " + PerLastName;
            }
        }

        [Required]
        [Display(Name = "Code")]
        public string PerCode { get; set; } = null!;
        public virtual ICollection<PerShi> Shifts { get; set; }

        [Display(Name = "Bestellungen")]
        public virtual ICollection<OrdOrder> Orders { get; set; }
    }
}
