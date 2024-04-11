using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace AA_Migalkina_PM_02
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private string connectionString = "Data Source = LAPTOP-BP9G4DP1\\SQLEXPRESS;Initial Catalog = PM_02_AA_Migalkina; Integrated Security = True";

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationUser(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            string phonenumber = txtPhonenumber.Text;
            string lastname = txtLastname.Text;
            string firstname = txtFirstname.Text;
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Password) ||
                string.IsNullOrEmpty(txtLastname.Text) || string.IsNullOrEmpty(txtFirstname.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            else
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Users(login, password, phone_number, last_name, first_name) " +
                        "VALUES (@login, @password, @phone_number, @last_name, @first_name)";

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@phone_number", phonenumber);
                    command.Parameters.AddWithValue("@last_name", lastname);
                    command.Parameters.AddWithValue("@first_name", firstname);
                    command.ExecuteNonQuery();
                }
            }
            AuthorizationWindow autorization = new AuthorizationWindow();
            autorization.Show();
        }

    }
}
