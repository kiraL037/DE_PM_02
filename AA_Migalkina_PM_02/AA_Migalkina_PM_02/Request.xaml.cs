using System.Data.SqlClient;
using System.Windows;

namespace AA_Migalkina_PM_02
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        private string connectionString = "Data Source = LAPTOP - BP9G4DP1\\SQLEXPRESS;Initial Catalog = PM_02_AA_Migalkina; Integrated Security = True";

        public Request()
        {
            InitializeComponent();
        }

        private void CreateRequest(object sender, RoutedEventArgs e)
        {
            string type = txtType.Text;
            string sNumber = txtSNumber.Text;
            string problem = txtProblem.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Requests(type, serial_number, problem_description) VALUES (@type, @serial_number, @problem_description)";

                using (SqlCommand command = new SqlCommand(insertQuery,connection))
                {
                    command.Parameters.AddWithValue("type", type);
                    command.Parameters.AddWithValue("serial_number", sNumber);
                    command.Parameters.AddWithValue("problem_description", problem);
                    command.ExecuteNonQuery();  
                }
                ClearFields();
            }
            MessageBox.Show("Заявка успешно создана");
        }
        private void ClearFields()
        {
            txtType.Text = string.Empty;
            txtSNumber.Text = "";
            txtProblem.Text = string.Empty;
        }
    }
}
