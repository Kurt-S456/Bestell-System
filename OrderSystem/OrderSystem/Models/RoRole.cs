using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Models
{
    [Display(Name = "Rolle")]
    public class RoRole
    {
        public RoRole()
        {
            PerPersons = new HashSet<PerPerson>();
        }
        [Key]
        public Guid RoId { get; set; }
        [Display(Name = "Bezeichnung")]
        public string RoName { get; set; } = null!;
        [Display(Name = "Benutzer")]
        public ICollection<PerPerson> PerPersons { get; set; }
        [Display(Name = "Admin")]
        public bool isAdmin { get; set; }
        [Display(Name = "Personal")]
        public bool isStaff { get; set; }
    }
}
