using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DicomLoaderWeb.Models
{
    public class User
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Password { get; set; }

     public string Salt { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    [ForeignKey("RoleID")]
    public UserRole Role { get; set; }

    [Required]
    [ForeignKey("StatusID")]
    public UserStatus Status { get; set; }

    public DateTime RegDate { get; set; }
}

}

