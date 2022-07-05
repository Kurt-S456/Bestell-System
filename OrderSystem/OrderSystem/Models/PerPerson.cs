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
            OrdOrders = new HashSet<OrdOrder>();
            ShiShifts = new HashSet<ShiShift>();
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
        public virtual ICollection<ShiShift> ShiShifts { get; set; }

        [Display(Name = "Bestellungen")]
        public virtual ICollection<OrdOrder> OrdOrders { get; set; }

        
        public Guid UsrUserId { get; set; }
        [Display(Name = "Benutzer")]
        public UsrUser? UsrUser { get; set; }

        [Required]
        public Guid RoRoleId { get; set; }

        [Display(Name = "Funktion")]
        public RoRole? RoRole { get; set; }
    }
}
