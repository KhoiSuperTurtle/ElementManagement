using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElementManagement.RoleWindows
{
    /// <summary>
    /// Логика взаимодействия для Element.xaml
    /// </summary>
    public partial class IngineerWindow : Window
    {
        private int idDevice;
        private bool defaults = true;
        public IngineerWindow()
        {
            InitializeComponent();
        }

      



        private void dtgDetailsToRequest_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeToRequestTable();
        }

        

        private void btToRequestUploadClick(object sender, RoutedEventArgs e)
        {
            InitializeToRequestTable();
        }

        private void InitializeToRequestTable()
        {
            DataBaseClass _data = new DataBaseClass();
            _data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul], Description from Inventory inner join Detail" +
                " on Inventory.ID_Detail = Detail.ID_Detail where Name_Inventory_Unit = 'Деталь' and Name_Inventory_Status='На складе'"), DataBaseClass.act.select);
            dtgDetailsToRequest.ItemsSource = _data.resultTable.DefaultView;
            dtgDetailsToRequest.Columns[0].Visibility = Visibility.Hidden;
            dtgDetailsToRequest.Columns[1].Header = "На складе с:";
            dtgDetailsToRequest.Columns[2].Header = "Количество: ";
            dtgDetailsToRequest.Columns[3].Header = "Название";
            dtgDetailsToRequest.Columns[4].Header = "Артикул";
            dtgDetailsToRequest.Columns[5].Header = "Описание";
        }

        private void InitializeRequestedTable()
        {
            
            DataBaseClass dataRequested = new DataBaseClass();
            dataRequested.sqlExecute(string.Format("select [ID_Request] as 'ID', [Name] as 'Название:'," +
                " [Articul] as 'Артикул:', [Date_Request] as 'Дата запроса:', [Status] as 'Статус запроса:', Requested_Details.[Count] as 'Количество:', [Description] as 'Описание:', Requested_Details.ID_Detail as 'Деталь'" +
                " from Requested_Details inner join Inventory " +
                "on Requested_Details.ID_Detail = Inventory.ID_Inventory inner join Detail" +
                " on Inventory.ID_Detail = Detail.ID_Detail where ID_Employee = {0} and ([Status] = 'Запрошен' or [Status]='Получен')", App.idEmployee), DataBaseClass.act.select);
            dtgMyRequested.ItemsSource = dataRequested.resultTable.DefaultView;
        }

        private void tbArticulSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataBaseClass data = new DataBaseClass();
            data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul] from Inventory inner join Detail on" +
                " Inventory.ID_Detail = Detail.ID_Detail where Name_Inventory_Unit = 'Деталь' and Name_Inventory_Status = 'На складе' and Articul like '{0}%'", tbArticulSearch.Text), DataBaseClass.act.select);
            //Data.dependency.OnChange += Dependency_OnChange_patient;
            dtgDetailsToRequest.ItemsSource = data.resultTable.DefaultView;
            dtgDetailsToRequest.Columns[0].Visibility = Visibility.Hidden;
            dtgDetailsToRequest.Columns[1].Header = "На складе с:";
            dtgDetailsToRequest.Columns[2].Header = "Количество: ";
            dtgDetailsToRequest.Columns[3].Header = "Название";
            dtgDetailsToRequest.Columns[4].Header = "Артикул";
        }

        private void tbNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataBaseClass data = new DataBaseClass();
            data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul] from Inventory inner join Detail on" +
                " Inventory.ID_Detail = Detail.ID_Detail where Name_Inventory_Unit = 'Деталь' and Name_Inventory_Status = 'На складе' and Name like '%{0}%'", tbNameSearch.Text), DataBaseClass.act.select);
            //Data.dependency.OnChange += Dependency_OnChange_patient;
            dtgDetailsToRequest.ItemsSource = data.resultTable.DefaultView;
            dtgDetailsToRequest.Columns[0].Visibility = Visibility.Hidden;
            dtgDetailsToRequest.Columns[1].Header = "На складе с:";
            dtgDetailsToRequest.Columns[2].Header = "Количество: ";
            dtgDetailsToRequest.Columns[3].Header = "Название";
            dtgDetailsToRequest.Columns[4].Header = "Артикул";
        }

        private void btRequestCount(object sender, RoutedEventArgs e)
        {
            if (tbCountToRequest.Text.Length>0)
            if (dtgDetailsToRequest.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgDetailsToRequest.SelectedItems[0];
                if (Int32.Parse(dataRowView.Row[2].ToString()) >= Int32.Parse(tbCountToRequest.Text.ToString()))
                {
                    dataBaseClass.sqlExecute(string.Format("insert into Requested_Details (ID_Detail, ID_Employee, Date_Request, Status, Count) " +
                        "values({0}, {1}, default, default, {2})", Int32.Parse(dataRowView.Row[0].ToString()), App.idEmployee, tbCountToRequest.Text.ToString()), DataBaseClass.act.manipulation);
                    
                    tbCountToRequest.Text = "";
                }
            }
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the input is a numeric value (you can add support for decimal separator if needed)
            if (!IsTextNumeric(e.Text))
            {
                e.Handled = true; // Mark the event as handled to prevent the character from being entered
            }
        }

        private bool IsTextNumeric(string text)
        {
            // Modify the regex pattern to support decimal separator or negative numbers if needed
            Regex regex = new Regex("[^0-9]");
            return !regex.IsMatch(text);
        }

       

        private void btAcceptUsage_Click(object sender, RoutedEventArgs e)
        {
            if (dtgMyRequested.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgMyRequested.SelectedItems[0];
                if (dataRowView.Row[4].ToString().Equals("Получен"))
                {
                    dataBaseClass.sqlExecute(string.Format("update Requested_Details set Status = 'Использован' where ID_Request = {0}", Int32.Parse(dataRowView.Row[0].ToString())
                            ), DataBaseClass.act.manipulation);
                    InitializeRequestedTable();
                }
            }
        }

        private void dtgMyRequested_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeRequestedTable();
        }

        private void btCancelUsage_Click(object sender, RoutedEventArgs e)
        {
            if (dtgMyRequested.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgMyRequested.SelectedItems[0];
                if (dataRowView.Row[4].ToString().Equals("Получен"))
                {
                    dataBaseClass.sqlExecute(string.Format("update Inventory set Count = (Count+{0}) where Name_Inventory_Status = 'На складе' and ID_Inventory = {1}",
                            Int32.Parse(dataRowView.Row[5].ToString()), Int32.Parse(dataRowView.Row[7].ToString())), DataBaseClass.act.manipulation);
                }
                dataBaseClass.sqlExecute(string.Format("update Requested_Details set Status = 'Отменён' where ID_Request = {0}", Int32.Parse(dataRowView.Row[0].ToString())
                        ), DataBaseClass.act.manipulation);
                
                InitializeRequestedTable();
            }
        }

        private void dtgDeviceLists_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeDeviceList();
        }

        private void InitializeDeviceList()
        {
            DataBaseClass dataRequested = new DataBaseClass();
            dataRequested.sqlExecute(string.Format("select Device.ID_Device as 'ID', Name as 'Название', Articul as 'Артикул', Description as 'Описание', Count as 'Количество'" +
                "from Device inner join Inventory on Device.ID_Device = Inventory.ID_Device", App.idEmployee), DataBaseClass.act.select);
            //Data.dependency.OnChange += Dependency_OnChange_patient;
            dtgDeviceLists.ItemsSource = dataRequested.resultTable.DefaultView;
        }

        private void dtgDeviceLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgDeviceLists.SelectedItem != null)
            {
                DataBaseClass dataRequested = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgDeviceLists.SelectedItems[0];
                idDevice = Int32.Parse(dataRowView.Row[0].ToString());
                if (defaults)
                    InitializeDetailsDevice();
                else InitializeDetailsCompatible();
            }
        }
        private void InitializeDetailsDevice()
        {
            if (dtgDeviceLists.SelectedItem != null)
            {
                DataBaseClass dataRequested = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgDeviceLists.SelectedItems[0];
                dataRequested.sqlExecute(string.Format("select ID_Default as 'ID', Detail.Name as 'Название', Detail.Articul as 'Артикул', Detail.Description as 'Деталь' from [dbo].[Device_Default_Details]" +
                    " inner join Detail on Detail.ID_Detail = Device_Default_Details.ID_Detail " +
                    "where IsActual = 1 and ID_Device = {0} and isDeleted = 0", idDevice), DataBaseClass.act.select);
                //Data.dependency.OnChange += Dependency_OnChange_patient;
                dtgDetailsOfDevice.ItemsSource = dataRequested.resultTable.DefaultView;
            }
        }

        private void InitializeDetailsCompatible()
        {
                DataBaseClass dataRequested = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgDeviceLists.SelectedItems[0];
                dataRequested.sqlExecute(string.Format("select ID_Detail_DeviceCompability as 'ID', Detail.Name as 'Название'," +
                    " Detail.Articul as 'Артикул', Detail.Description as 'Описание', Compability as 'Совместимость', Note as 'Примечание'" +
                    " from[dbo].Detail_DeviceCompability " +
                    "inner join Detail on Detail.ID_Detail = Detail_DeviceCompability.ID_Detail " +
                    "where ID_Device = {0} and isDeleted = 0", idDevice), DataBaseClass.act.select);
                //Data.dependency.OnChange += Dependency_OnChange_patient;
                dtgDetailsOfDevice.ItemsSource = dataRequested.resultTable.DefaultView;
        }
        /// <summary>
        /// Логика кнопки добавления изготовленного устройства в учёт системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btNotifyDeviceProduction_Click(object sender, RoutedEventArgs e)
        {
            if (dtgDeviceLists.SelectedItem != null) //проверка на наличие выбранного элемента в таблице
            {
                DataBaseClass dataBaseClass = new DataBaseClass();  //инициализация класса работы с БД
                DataRowView dataRowView = (DataRowView)dtgDeviceLists.SelectedItems[0];  //хранение выбранной строки
                dataBaseClass.sqlExecute(string.Format("update Inventory set Count = Count + 1 where ID_Device = {0} and Name_Inventory_Status='На складе'", Int32.Parse(dataRowView.Row[0].ToString()) //Добавление изготовленного устройства в склад
                        ), DataBaseClass.act.manipulation);
                InitializeDeviceList(); //Обновление списка устройств на складе
            }
        }
        /// <summary>
        /// Логика кнопки переключения режима просмотра между деталями по умолчанию и всеми совместимыми деталями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btChengeShownDetails_Click(object sender, RoutedEventArgs e)
        {
            defaults = defaults? defaults=false : defaults=true; //изменяет переменную, отвечающую за хранение текущего режима
            if (defaults)  //обновление таблицы
            {
                (sender as Button).Content = "Посмотреть совместимые детали";
                InitializeDetailsDevice();
            }
            else
            {
                (sender as Button).Content = "Посмотреть детали по умолчанию";
                InitializeDetailsCompatible();
            }
        }
    }
}
