using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystem.Models
{
    [Display(Name = "Benutzer")]
    public partial class UsrUser 
    {
        [Key]
        public Guid UsrId { get; set; }
        [Display(Name ="Benutzername")]
        [Required(ErrorMessage = "Benutzernamen angeben")]
        public string UsrUserName { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Passwort angeben")]
        [Display(Name = "Passwort")]
        public string UsrPassword { get; set; } = null!;

    }
}
