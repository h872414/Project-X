using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

using DicomLoader.Controller;
using DicomLoader.Model;
using DicomLoader.Model.DAO;

namespace DicomLoader.View
{
    public partial class SignInWindow : Form
    {
        readonly IWebController controller = new WebController();
       
        public SignInWindow()
        {
            InitializeComponent();
        }


        private void RegButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["RegisterURL"]);
            }catch(Exception exception)
            {
                Debug.WriteLine(exception.ToString());
                const string message = "Alkalmazás hiba";
                const string caption = "Link hiba";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private async void SignInButton_Click(object sender, EventArgs e)
        {
            String email = EmailTextBox.Text.Trim();
            String password = PasswordTextBox.Text.Trim();

            var result = await controller.SignIn(email, password);
            if (result)
            {
               
                new MainWindow(email).Show();
                this.Hide();
  
            }


        }

    }
}
