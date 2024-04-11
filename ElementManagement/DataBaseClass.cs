using System.Data;
using System.Data.SqlClient;

namespace ElementManagement
{
    class DataBaseClass
    {
        public static string Users_ID = "sa", Password = "123", App_Name = "Element Management";
        public static string ConnectionString = "Data Source = DESKTOP-V7VQ75M\\SQLEXPRESS; Initial Catalog = PP11_1TRAZBD; Persist Security Info = true; User ID = {0}; Password = '{1}';";
        public SqlConnection connection = new SqlConnection(ConnectionString);
        private SqlCommand command = new SqlCommand();
        public DataTable resultTable = new DataTable();
        public SqlDependency dependency = new SqlDependency();
        public enum act { select, manipulation };
        public void sqlExecute(string quety, act act)
        {
            command.Connection = connection;
            command.CommandText = quety;
            command.Notification = null;
            switch (act)
            {
                case act.select:
                    dependency.AddCommandDependency(command);
                    SqlDependency.Start(connection.ConnectionString);
                    connection.Open();
                    resultTable.Load(command.ExecuteReader());
                    connection.Close();
                    break;
                case act.manipulation:
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    break;
            }
        }
    }
}
