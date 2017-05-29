using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ETS2_Invoice.Classes;

namespace ETS2_Invoice
{
    /// <summary>
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (InputUsername.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie einen Benutzernamen ein!");
                return;
            } else if (InputPassword.Password == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie ein Passwort ein!");
                return;
            }
            else if (InputEmail.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie eine E-Mail-Adresse ein!");
                return;
            }

            var values = new NameValueCollection();
            values["username"] = InputUsername.Text;
            values["password"] = InputPassword.Password;
            values["email"] = InputEmail.Text;
            values["register"] = "true";

            try
            {
                string response = Http.Send(Login.url, values);

                if (response == "username taken") {
                    MessageBox.Show("Der Benutzername ist bereits vergeben!");
                    return;
                } else if (response == "email not valid")
                {
                    MessageBox.Show("Die eingegebene E-Mail ist nicht valide!");
                    return;
                } else if (response == "email taken")
                {
                    MessageBox.Show("Die E-Mail-Adresse ist bereits vergeben!");
                    return;
                }

                MessageBox.Show("Sie wurden erfolgreich registriert!" + Environment.NewLine + "Sie erhalten nun eine E-Mail mit Schritten zur aktivierung ihres Kontos");
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == tb.Tag.ToString())
            {
                tb.Text = string.Empty;
            }
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == string.Empty)
            {
                tb.Text = tb.Tag.ToString();
            }
        }
    }
}
