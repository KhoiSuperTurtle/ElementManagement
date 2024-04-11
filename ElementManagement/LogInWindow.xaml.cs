using System.Data;
using System.Windows;


namespace ElementManagement
{
    /// <summary>
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void btEnter_Click(object sender, RoutedEventArgs e)
        {
            DataBaseClass.ConnectionString = string.Format(DataBaseClass.ConnectionString, DataBaseClass.Users_ID, DataBaseClass.Password);
            DataBaseClass dataBaseClass = new DataBaseClass();
            try
            {
                dataBaseClass.connection.Open();
                try
                {
                    DataBaseClass data = new DataBaseClass();
                    data.sqlExecute(string.Format("select [Name_Role], [ID_Employee] from Employee where Login = '{0}' and Password = '{1}'", pbLogin.Password.ToString(), pbPassword.Password.ToString()), DataBaseClass.act.select);
                    if (data.resultTable.Rows.Count > 0)
                    {
                        string post = data.resultTable.DefaultView[0][0].ToString();
                        if (post.Equals("Инженер"))
                        {
                            RoleWindows.IngineerWindow ingineer = new RoleWindows.IngineerWindow();
                            ingineer.Show();
                            App.idEmployee = System.Int32.Parse(data.resultTable.DefaultView[0][1].ToString());
                            this.Close();
                        }
                        else if (post.Equals("Складовщик"))
                        {
                            RoleWindows.StorageWorkerWindow storage = new RoleWindows.StorageWorkerWindow();
                            storage.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Для данной роли нет модуля");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не верный логин или пароль!", DataBaseClass.App_Name);
                    }
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка. Пожалуйста, убедитесь, что есть подключение к серверу");
                }
            }
            catch
            {
                MessageBox.Show("Не верный логин или пароль!", DataBaseClass.App_Name);
                pbLogin.Focus();
            }
            finally
            {
                dataBaseClass.connection.Close();
                pbLogin.Clear();
                pbPassword.Clear();
            }
        }

        private void btCLose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
