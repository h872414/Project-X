using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DicomLoader.Controller;
using DicomLoader.Model;

namespace DicomLoader.View
{

    public partial class MainWindow : Form
    {
        readonly IDicomController controller;
        readonly static IWebController WController = new WebController();
        IEnumerable<Bitmap> images;
        Bitmap singlePicture;
        int currentImage = 0;
        bool multipleImageEnable = false;
        String UserEmail;

        public MainWindow(String email)
        {
            InitializeComponent();
            ReSet();
            this.controller = new DicomController();
            this.UserEmail = email;
            init();
        }

        private static void init()
        {
            Task.Run(async () => {
                var RecordsStored = await WebController.CheckLocalDB();
                foreach(var Record in RecordsStored)
                {
                    String PatientName = Record.PatientName;
                    String Description = Record.Description;
                    String UserEmail = Record.Email;
                    String DicomImage = Record.Image;
                    DateTime RecordDate = Record.RecordDate;

                    if(await WController.Upload(UserEmail, PatientName, DicomImage, Description, RecordDate)) {
                        await WebController.DeleteRecord(Record);
                    }

                }

            });
        }

        private async void ImportDirBtnClick(object sender, EventArgs e)
        {         
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = Directory.GetCurrentDirectory();
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    var task = controller.ImportDicomDir(files);
                    images = await task;
                    multipleImageEnable = true;

                    if(images != null)
                    {
                        pictureBox.Image = images.ElementAt(currentImage);
                        inputDirPathLabel.Text = Path.GetFileName(Path.GetDirectoryName(files[0]));
                        imageCountLabeld.Text = images.Count().ToString() + " / " + currentImage.ToString();
                        ReSet();
                        string message = images.Count().ToString() + " fájl olvasása sikeres";
                        const string caption = "Sikeres beolvasás";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }

        }

        private void ImportFileBtnClick(object sender, EventArgs e)
        {
            multipleImageEnable = false;
            using var result = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "dicom files (*.dcm)|*.dcm|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (result.ShowDialog() == DialogResult.OK)
            {
                singlePicture = controller.ImportDicomFile(result.FileName);
                if (singlePicture != null)
                {
                    inputPathLabel.Text = Path.GetFileName(result.FileName);
                    pictureBox.Image = singlePicture;
                    ReSet();
                }
                else
                {
                    const string message = "Nem várt hiba a beolvasás közben. Kérem ellenőrizze a beolvasandó fájlt!";
                    const string caption = "Hibás olvasás";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            // var result = openFileDialog1.ShowDialog();

        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            if (multipleImageEnable && currentImage > 0)
            {
                pictureBox.Image = images.ElementAt(currentImage);
                currentImage--;
                imageCountLabeld.Text = images.Count().ToString() + " / " + currentImage.ToString();
            }
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            if (multipleImageEnable && images.Count() > currentImage)
            {
                pictureBox.Image = images.ElementAt(currentImage);
                currentImage++;
                imageCountLabeld.Text = images.Count().ToString() + " / " + currentImage.ToString();
            }
        }

        private void SetResize(object sender, EventArgs e)
        {
            ReSet();
        }

        private void ReSet()
        {
            pictureBox.Size = new Size(Convert.ToInt32(viewerPanel.Width * 0.6), Convert.ToInt32(viewerPanel.Height * 0.8));
            pictureBox.Location = new Point((viewerPanel.Width - pictureBox.Width) / 2, (viewerPanel.Height - pictureBox.Height) / 2);
            singleImportPanel.Size = new Size(Convert.ToInt32(splitContainer.Panel1.Width), Convert.ToInt32(splitContainer.Panel1.Height * 0.35));
            exportPanel.Size = new Size(Convert.ToInt32(splitContainer.Panel1.Width), Convert.ToInt32(splitContainer.Panel1.Height * 0.3));
            ResizeElemets(singleLabel, singleImportPanel, loc: 0.3);
            ResizeElemets(importBtn, singleImportPanel, loc: 0.5);
            ResizeElemets(choosenLabel, singleImportPanel, loc: 0.7);
            ResizeElemets(inputPathLabel, singleImportPanel, loc: 0.9);

            ResizeElemets(multipleLabel, multiImportPanel, loc: 0.05);
            ResizeElemets(importDirBtn, multiImportPanel, loc: 0.3);
            ResizeElemets(choosenDirLabel, multiImportPanel, loc: 0.6);
            ResizeElemets(inputDirPathLabel, multiImportPanel, loc: 0.8);

            ResizeElemets(exportBtn, exportPanel, loc: 0.2);

            currentPanel.Size = new Size(Convert.ToInt32(splitContainer.Panel2.Width), Convert.ToInt32(splitContainer.Panel2.Height * 0.1));

            ResizeElemets(currentLabel, currentPanel, 0.2, 0.8, 0.15);
            ResizeElemets(imageCountLabeld, currentPanel, 0.6, 0.8, 0.15);

        }
        private void ResizeElemets(Control element, Control panel, double loc, double heigth = 0.2, double fontSize = 0.06)
        {
            element.Font = new Font(FontFamily.GenericSansSerif, Convert.ToSingle(panel.Height * fontSize), FontStyle.Regular);
            element.Size = new Size(Convert.ToInt32(panel.Width * 0.4), Convert.ToInt32(panel.Height * heigth));
            element.Location = new Point((panel.Width - element.Width) / 2, Convert.ToInt32(panel.Height * loc));
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "JPEG Image|*.jpg",
                Title = "Mentés képként"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (multipleImageEnable)
                {    
                    if (controller.ExportDir(dialog.FileName, images))
                    {
                        const string message = "Sikeres exportálás.";
                        const string caption = "Sikeres exportálás";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        const string message = "Nem várt hiba a exportálás közben. Kérem ellenőrizze az exportálandó fájlt!";
                        const string caption = "Hibás olvasás";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (controller.ExportFile(dialog.FileName, singlePicture))
                    {

                        if (controller.ExportDir(dialog.FileName, images))
                        {
                            const string message = "Sikeres exportálás.";
                            const string caption = "Sikeres exportálás";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            const string message = "Nem várt hiba a exportálás közben. Kérem ellenőrizze az exportálandó fájlt!";
                            const string caption = "Hibás olvasás";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

            }


        }

        private void dicomImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Add(this.splitContainer);
            ReSet();
        }

        private void dicomUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UploadWindow(UserEmail).Show();
        }
    }
}
