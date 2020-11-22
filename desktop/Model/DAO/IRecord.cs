using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomLoader.Model.DAO
{
    interface IRecord
    {
        public Task<Record> AddRecord(Record Record);
        public Task<IList<Record>> ListRecord();
        public Task<Record> DeleteRecord(Record Record);
        
    }
}
