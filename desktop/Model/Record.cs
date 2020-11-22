using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomLoader.Model
{
    class Record
    {
       public int RecordId { get; set; }

        public String Email { get; set; }

        public String PatientName { get; set; }

        public String Image { get; set; }

        public String Description { get; set; }

        public DateTime RecordDate { get; set; }
    }
}

