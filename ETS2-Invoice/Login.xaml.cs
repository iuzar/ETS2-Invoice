using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Windows;
using ETS2_Invoice.Classes;
using ETS2_Invoice.Classes.Database;
using Newtonsoft.Json;

namespace ETS2_Invoice
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static User user;
        private Main MainForm = null;


        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            string url = "http://ets2.chakratos.com/";
            var values = new NameValueCollection();
            values["username"] = InputUsername.Text;
            values["password"] = InputPassword.Password;

            try
            {
                string response = Http.Send(url, values);
                user = JsonConvert.DeserializeObject<User>(Http.Send(url, values));
                if (MainForm == null)
                {
                    MainForm = new Main();
                }
                MainForm.Show();
                this.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
