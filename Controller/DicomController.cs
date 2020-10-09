
using Dicom.Imaging;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DicomLoader.Controller
{
    public class DicomController : IDicomController
    {
        /// <summary>
        /// Read a single DICOM file and load it into a Bitmap
        /// </summary>
        /// <param name="path">DICOM file path</param>
        /// <returns>DICOM image in Btimap</returns>
        public Bitmap ImportDicomFile(string path)
        {
            ImageManager.SetImplementation(WPFImageManager.Instance);
            var image = new DicomImage(path);
            var renderImage = image.RenderImage().As<WriteableBitmap>();
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)renderImage));
                enc.Save(outStream);
                Bitmap bmp = new Bitmap(outStream);
                return bmp;
            }
        }
        /// <summary>
        /// Read multiple DICOM file from a directory async
        /// </summary>
        /// <param name="pathArray">Directory path</param>
        /// <returns></returns>
        public async Task<IEnumerable<Bitmap>> ImportDicomDir(string[] pathArray)
        {
            var maps = new List<Bitmap>();
            ImageManager.SetImplementation(WPFImageManager.Instance);
            foreach (var path in pathArray)
            {
                var image = new DicomImage(path);
                var renderImage = image.RenderImage().As<WriteableBitmap>();
                using (MemoryStream outStream = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create((BitmapSource)renderImage));
                    enc.Save(outStream);
                    Bitmap bmp = new Bitmap(outStream);
                    maps.Add(bmp);
                }
            }
            return maps;
        }
        /// <summary>
        /// Export the all image stored in the memory
        /// </summary>
        /// <param name="path">output directory</param>
        /// <param name="images">Bitmap images in memory</param>
        /// <returns></returns>
        public bool ExportDir(string path, IEnumerable<Bitmap> images)
        {
            foreach (var image in images.Select((value, index) => new { value, index }))
            {
                var bmp = new Bitmap(image.value);
                bmp.Save(path + image.index +".jpg" , ImageFormat.Jpeg);
            }
            return true;
        }
        /// <summary>
        /// Export single DICOM image from memory
        /// </summary>
        /// <param name="path">output directory</param>
        /// <param name="image">Bitmap image in memory</param>
        /// <returns></returns>
        public bool ExportFile(string path, Bitmap image)
        {
            var bmp = new Bitmap(image);
            bmp.Save(path + ".jpg", ImageFormat.Jpeg);
            return false;
        }
    }
}
