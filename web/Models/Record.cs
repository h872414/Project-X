using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DicomLoaderWeb.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        [Required]
        [ForeignKey("ID")]
        public virtual User User { get; set; }

        [Required]
        public String PatientName { get; set; }

        [Required]
        public String Image{get; set;}

        [Required]
        public String Description { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }
        }
}
