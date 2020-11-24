
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
        /// <summary>
        /// Import single dicom file and loads to view
        /// </summary>
        /// <param name="path">path to dicom file</param>
        /// <returns>
        ///     Returns a Bitmap which contains the imported picture from the dicom file;
        ///     Return null if some exeption occured during excecution        
        /// </returns>
        public Bitmap ImportDicomFile(string path)
        {
            ImageManager.SetImplementation(WPFImageManager.Instance);
            DicomImage Image = null;
            WriteableBitmap RenderImage = null;
            try
            {
                Image = new DicomImage(path);
                RenderImage = Image.RenderImage().As<WriteableBitmap>();
            }catch(Dicom.DicomException exception)
            {
                Debug.WriteLine(exception.ToString());
                const string message = "Nem megfelelő fájlformátum. Kérem válasszon ki megfelelő kiterjesztésű fájlt!";
                const string caption = "Hibás input";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            using MemoryStream outStream = new MemoryStream();
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create((BitmapSource)RenderImage));
            enc.Save(outStream);
            Bitmap bmp = new Bitmap(outStream);
            return bmp;
        }

        /// <summary>
        /// Import multiple dicom files from a folder
        /// </summary>
        /// <param name="pathArray">path of the imported pictures</param>
        /// <returns>
        ///     Returns a Task<Bitmap> which contains a IEnumerable list of the imported pictures from the dicom files
        ///     Return null if some exeption occured during excecution    
        /// </returns>
        public async Task<IEnumerable<Bitmap>> ImportDicomDir(string[] pathArray)
        {
            var maps = new List<Bitmap>();
            DicomImage Image = null;
            WriteableBitmap RenderImage = null;
            ImageManager.SetImplementation(WPFImageManager.Instance);

            maps = await Task<IEnumerable<Bitmap>>.Run(() => {
                try
                {
                    foreach (var path in pathArray)
                    {
                        Image = new DicomImage(path);
                        RenderImage = Image.RenderImage().As<WriteableBitmap>();
                        using MemoryStream outStream = new MemoryStream();
                        BitmapEncoder enc = new BmpBitmapEncoder();
                        enc.Frames.Add(BitmapFrame.Create((BitmapSource)RenderImage));
                        enc.Save(outStream);
                        Bitmap bmp = new Bitmap(outStream);
                        maps.Add(bmp);
                    }
                    return maps;
                }
                catch (Dicom.DicomException exception)
                {
                    Debug.WriteLine(exception.ToString());
                    const string message = "Nem megfelelő fájlformátum. Kérem válasszon ki megfelelő kiterjesztésű fájlt!";
                    const string caption = "Hibás input";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            });
            return maps;
        }

        /// <summary>
        /// Export multiple dicom files to a folder
        /// </summary>
        /// <param name="path">Export path</param>
        /// <param name="images">Bitmaps of the imported pictures</param>
        /// <returns>
        ///     True - export completed
        ///     False - if some exeption occured during excecution    
        /// </returns>
        public bool ExportDir(string path, IEnumerable<Bitmap> images)
        {
            foreach (var image in images.Select((value, index) => new { value, index }))
            {    
                try
                {
                    var bmp = new Bitmap(image.value);
                    bmp.Save(path + image.index + ".jpg", ImageFormat.Jpeg);
                    return true;
                }
                catch(ArgumentNullException exception)
                {
                    Debug.WriteLine(exception.ToString());
                    string message = "Nem várt hiba az exportálás során, kérjük ellenőrizze a beállításokat.";
                    const string caption = "Sikertelen mentés";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException exception)
                {
                    Debug.WriteLine(exception.ToString());
                    string message = "Az exportáláshoz előszőr olvasson be egy dicom filet.";
                    const string caption = "Sikertelen mentés";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);  
                }
            }
            return false;
        }

        /// <summary>
        /// Export single dicom files to a folder
        /// </summary>
        /// <param name="path"></param>
        /// <param name="image"></param>
        /// <returns></returns>
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
            }
            catch (ArgumentNullException exception)
            {
                Debug.WriteLine(exception.ToString());
                string message = "Nem várt hiba az exportálás során, kérjük ellenőrizze a beállításokat.";
                const string caption = "Sikertelen mentés";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }
    }
}
