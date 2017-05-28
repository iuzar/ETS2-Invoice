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
            if (InputUsername.Text == string.Empty || InputPassword.Password == string.Empty || InputEmail.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie alle benötigten Daten in die Felder ein!");
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

                if (response == "taken") {
                    MessageBox.Show("Der Benutzername ist bereits vergeben!");
                    return;
                } else if (response == "email not valid")
                {
                    MessageBox.Show("The E-Mail adress is not valid!");
                    return;
                }

                MessageBox.Show("Sie wurden erfolgreich registriert!" + Environment.NewLine + "Sie erhalten nun eine E-Mail mit Schritten zur aktivierung ihres Kontos");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
