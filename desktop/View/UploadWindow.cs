using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DicomLoader.Controller;

namespace DicomLoader.View
{
    public partial class UploadWindow : Form
    {
        String DicomImage = "data:image/png;base64, ";
        readonly IWebController Controller = new WebController();
        readonly String UserEmail;
        public UploadWindow(String Email)
        {
            InitializeComponent();
            this.UserEmail = Email;
            
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using var Result = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if(Result.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] imageArray = File.ReadAllBytes(Result.FileName);
                    DicomImage += Convert.ToBase64String(imageArray);
                }catch(Exception exception)
                {
                    Debug.WriteLine(exception.ToString());
                    const string message = "Hiba történt a file beolvasása közben";
                    const string caption = "Olvasási hiba";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
        }

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            String PatientName = NameInput.Text.Trim();
            String Description = DescriptionInput.Text.Trim();
            DateTime RecordDate = DateInput.Value;
            if(DicomImage != "data:image/png;base64, ")
            {
               Task<bool> UploadResult = Controller.Upload(UserEmail,PatientName, DicomImage,Description, RecordDate);
                if(await UploadResult)
                {
                    const string message = "Sikeresen felöltötte a file-t";
                    const string caption = "Sikeres művelet";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    const string message = "Hiba a feltöltés közben";
                    const string caption = "Kapcsolat hiba";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DicomImage = "data:image/png;base64, ";

            }
            
        }
    }
}
