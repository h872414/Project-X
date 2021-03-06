﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using DicomLoader.Controller;

namespace DicomLoader.View
{
    public partial class SignInWindow : Form
    {
        readonly IWebController controller = new WebController();
       
        public SignInWindow()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Handles registration request from user, and load Registration page from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(ConfigurationManager.AppSettings["RegisterURL"]);
            }catch(Exception exception)
            {
                Debug.WriteLine(exception.ToString());
                const string message = "Alkalmazás hiba";
                const string caption = "Link hiba";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles sign in request of the user, call sign in method of server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
