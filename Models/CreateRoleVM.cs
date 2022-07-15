using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class CreateRole
    {
        [Required(ErrorMessage= "Role Name requer")]
        public string RoleName{ get; set; }
    }
}
