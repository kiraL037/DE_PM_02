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
    /// Логика взаимодействия для ManagerRequest.xaml
    /// </summary>
    public partial class ManagerRequest : Window
    {
        private string connectionString = "Data Source = LAPTOP - BP9G4DP1\\SQLEXPRESS;Initial Catalog = PM_02_AA_Migalkina; Integrated Security = True";

        public ManagerRequest()
        {
            InitializeComponent();
            LoadRequests();
        }

        private List<Requests> LoadRequests()
        {
            List<Requests> requests = new List<Requests>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string select = "SELECT * FROM Requests";
                SqlCommand command = new SqlCommand(select, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Requests request = new Requests();
                    request.ID_request = Convert.ToInt32(reader["ID_request"]);
                    request.type = reader["type"].ToString();
                    request.serial_number = reader["serial_number"].ToString();
                    request.problem_description = reader["problem_description"].ToString();
                    request.ID_user = Convert.ToInt32(reader["ID_user"]);
                    request.ID_worker = Convert.ToInt32(reader["ID_worker"]);
                    request.Status = reader["Status"].ToString();

                    requests.Add(request);
                }
                reader.Close();

                dataGrid.ItemsSource = requests;

            }
            return requests;
        }


        private void ChangeRequestData(object sender, RoutedEventArgs e)
        {

        }
    }
}
