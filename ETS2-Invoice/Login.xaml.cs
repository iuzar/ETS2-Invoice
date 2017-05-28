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
        public static string url = "http://ets2.chakratos.com/";
        public static User user;
        private Main MainForm = null;
        private Register RegistrationForm = null;


        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (InputUsername.Text == string.Empty || InputPassword.Password == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie zuerst ihre Login Daten ein!");
                return;
            }
            var values = new NameValueCollection();
            values["username"] = InputUsername.Text;
            values["password"] = InputPassword.Password;
            values["login"] = "true";

            try
            {
                string response = Http.Send(url, values);
                if (response == "not activated")
                {
                    MessageBox.Show("Bitte aktivieren sie ihren Account per E-Mail!");
                    return;
                }
                user = JsonConvert.DeserializeObject<User>(Http.Send(url, values));
                if (MainForm == null)
                {
                    MainForm = new Main();
                }
                if (RegistrationForm != null && RegistrationForm.IsVisible)
                {
                    RegistrationForm.Close();
                }
                MainForm.Show();
                this.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Die eingegebenen Login Daten sind falsch!");
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrationForm == null || !RegistrationForm.IsLoaded)
            {
                RegistrationForm = new Register();
            }
            if (RegistrationForm.IsVisible)
            {
                return;
            }
            RegistrationForm.Show();
        }
    }
}
