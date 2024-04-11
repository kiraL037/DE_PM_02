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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private string connectionString = "Data Source = LAPTOP - BP9G4DP1\\SQLEXPRESS;Initial Catalog = PM_02_AA_Migalkina; Integrated Security = True";

        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void InForManager(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            if (IsUserExist(login, password))
            {

                ManagerRequest managerrequest = new ManagerRequest();
                managerrequest.Show();
            }
            else
            {
                MessageBox.Show("Неверно введены логин и пароль");
            }
        }
        private bool IsUserExist(string login, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectCount = "SELECT COUNT(*) FROM Managers WHERE Login=@Login AND Password=@Password";

                    SqlCommand command = new SqlCommand(selectCount, connection);

                    command.Parameters.AddWithValue("Login", login);
                    command.Parameters.AddWithValue("Password", password);

                    command.ExecuteNonQuery();

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                        return true;
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Менеджера не существует, проверьте правильность введенных данных" + ex.Message);
                return false;
            }

        }
    }
}
