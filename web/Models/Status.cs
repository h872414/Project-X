using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DicomLoaderWeb.Models
{
    public enum UserStatus
    {
        ACTIVE,
        DISABLED
    }
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        [Required]
        public UserStatus UserStatus { get; set; }

        public String StatusName { get; set; }
    }
}
