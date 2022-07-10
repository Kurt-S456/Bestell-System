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
            Persons = new HashSet<PerShi>();
        }
        [Key]
        public Guid RoId { get; set; }
        [Display(Name = "Bezeichnung")]
        public string RoName { get; set; } = null!;
        [Display(Name = "Benutzer")]
        public ICollection<PerShi> Persons { get; set; }
        [Display(Name = "Admin")]
        public bool isAdmin { get; set; }
        [Display(Name = "Personal")]
        public bool isStaff { get; set; }
    }
}
