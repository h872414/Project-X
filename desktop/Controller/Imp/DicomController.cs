
using Dicom.Imaging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace DicomLoader.Controller
{
    public class DicomController : IDicomController
    {

        public Bitmap ImportDicomFile(string path)
        {
            ImageManager.SetImplementation(WPFImageManager.Instance);
            DicomImage image = null;
            WriteableBitmap renderImage = null;
            try
            {
                image = new DicomImage(path);
                renderImage = image.RenderImage().As<WriteableBitmap>();
            }catch(Dicom.DicomException exception)
            {
                Debug.WriteLine(exception.ToString());
                const string message = "Nem megfelelő fájlformátum. Kérem válasszon ki megfelelő kiterjesztésű fájlt!";
                const string caption = "Hibás input";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            using (MemoryStream outStream = new MemoryStream())
            {         
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)renderImage));
                enc.Save(outStream);
                Bitmap bmp = new Bitmap(outStream);
                return bmp;
            }
            return null;

        }

        public async Task<IEnumerable<Bitmap>> ImportDicomDir(string[] pathArray)
        {
            var maps = new List<Bitmap>();
            DicomImage image = null;
            WriteableBitmap renderImage = null;
            ImageManager.SetImplementation(WPFImageManager.Instance);
            try
            {
                foreach (var path in pathArray)
                {
                    image = new DicomImage(path);
                    renderImage = image.RenderImage().As<WriteableBitmap>();
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
            }catch(Dicom.DicomException exception)
            {
                Debug.WriteLine(exception.ToString());
                const string message = "Nem megfelelő fájlformátum. Kérem válasszon ki megfelelő kiterjesztésű fájlt!";
                const string caption = "Hibás input";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public bool ExportDir(string path, IEnumerable<Bitmap> images)
        {
            foreach (var image in images.Select((value, index) => new { value, index }))
            {
               
                try
                {
                    var bmp = new Bitmap(image.value);
                    bmp.Save(path + image.index + ".jpg", ImageFormat.Jpeg);
                }
                catch(ArgumentNullException exception)
                {
                    Debug.WriteLine(exception.ToString());
                    string message = "Nem várt hiba az exportálás során, kérjük ellenőrizze a beállításokat.";
                    const string caption = "Sikertelen mentés";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (NullReferenceException exception)
                {
                    Debug.WriteLine(exception.ToString());
                    string message = "Az exportáláshoz előszőr olvasson be egy dicom filet.";
                    const string caption = "Sikertelen mentés";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }

        public bool ExportFile(string path, Bitmap image)
        {
            try 
            {
                var bmp = new Bitmap(image);
                bmp.Save(path + ".jpg", ImageFormat.Jpeg);
            }
            catch (NullReferenceException exception)
            {
                Debug.WriteLine(exception.ToString());
                string message = "Az exportáláshoz előszőr olvasson be egy dicom filet.";
                const string caption = "Sikertelen mentés";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (ArgumentNullException exception)
            {
                Debug.WriteLine(exception.ToString());
                string message = "Nem várt hiba az exportálás során, kérjük ellenőrizze a beállításokat.";
                const string caption = "Sikertelen mentés";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return false;
        }
    }
}
