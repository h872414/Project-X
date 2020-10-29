using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomLoader.Controller
{
    interface IDicomController
    {
        Bitmap ImportDicomFile(string path);
        Task<IEnumerable<Bitmap>> ImportDicomDir(string[] path);
        bool ExportDir(string path, IEnumerable<Bitmap> images);
        bool ExportFile(string path, Bitmap image);
          
    }
}
