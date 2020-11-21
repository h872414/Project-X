using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DicomLoaderWeb.Models
{
    public enum UserRole
    {
        ADMIN,
        USER
    }
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public UserRole UserRole { get; set; }

        public String RoleName { get; set; }
    }
}
