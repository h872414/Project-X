using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


using Newtonsoft.Json;

namespace DicomLoader.Controller
{
    class WebController : IWebController
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<bool> SignIn(string email, string password)
        {
            String responseBody = null;
            var parameters = new Dictionary<string, string> { { "Email", email}, { "Password", password } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            
            using var response = await client.PostAsync(ConfigurationManager.AppSettings["SignInURL"],encodedContent);
            
            try
            {
                response.EnsureSuccessStatusCode();
                var contentStream = await response.Content.ReadAsStreamAsync();
                responseBody = await response.Content.ReadAsStringAsync();       
                dynamic json = JsonConvert.DeserializeObject(responseBody);
                Boolean accepted = Convert.ToBoolean(json["accepted"]);
                if (accepted) 
                {
                    if (DateTime.Today > Convert.ToDateTime(json["licenseDate"]))
                    {
                        return true;
                    }
                    else
                    {
                        const string caption = "Belépés megtagadva";
                        string message = Convert.ToString(json["error"]);
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }              
                }
                else
                {
                    const string caption = "Belépés megtagadva";
                    string message = Convert.ToString(json["error"]);
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException exception)
            {
                Debug.WriteLine(exception.ToString());
                const string message = "Server hiba";
                const string caption = "Ellenőrizze a kapcsolatás";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch (JsonReaderException exception)
                {
                Debug.WriteLine(exception.ToString());
                const string message = "Server hiba";
                const string caption = "Hibás adatok a Servertől";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;

        }
    }
}