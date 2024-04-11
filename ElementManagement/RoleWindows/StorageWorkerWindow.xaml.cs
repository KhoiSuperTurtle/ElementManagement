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
    public partial class StorageWorkerWindow : Window
    {
        public StorageWorkerWindow()
        {
            InitializeComponent();
            List<String> typesInventory = new List<string>
            {
                "Детали",
                "Устройства"
            };
            cbType.ItemsSource = typesInventory;

        }

        private void dtgInventory_Loaded(object sender, RoutedEventArgs e)
        {
            //На складе
            FillDtgInventoryWithDetails();
        }

        private void FillDtgInventoryWithDetails()
        {
            DataBaseClass _data = new DataBaseClass();
            _data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul], Name_Inventory_Status, Description from Inventory inner join Detail" +
                " on Inventory.ID_Detail = Detail.ID_Detail where Name_Inventory_Unit = 'Деталь'"), DataBaseClass.act.select);
            dtgInventory.ItemsSource = _data.resultTable.DefaultView;
            dtgInventory.Columns[0].Visibility = Visibility.Hidden;
            dtgInventory.Columns[1].Header = "На складе с:";
            dtgInventory.Columns[2].Header = "Количество: ";
            dtgInventory.Columns[3].Header = "Название";
            dtgInventory.Columns[4].Header = "Артикул";
            dtgInventory.Columns[5].Header = "Статус";
            dtgInventory.Columns[6].Header = "Описание";
        }

        private void FillDtgInventoryWithDeviced()
        {
            DataBaseClass _data = new DataBaseClass();
            _data.sqlExecute(string.Format("select Id_Inventory, DateTimeIncome, Count, Name, Articul, Name_Inventory_Status, Description " +
                "from Inventory inner join Device on Inventory.ID_Device = Device.ID_Device"), DataBaseClass.act.select);
            dtgInventory.ItemsSource = _data.resultTable.DefaultView;
            dtgInventory.Columns[0].Visibility = Visibility.Hidden;
            dtgInventory.Columns[1].Header = "На складе с:";
            dtgInventory.Columns[2].Header = "Количество: ";
            dtgInventory.Columns[3].Header = "Название";
            dtgInventory.Columns[4].Header = "Артикул";
            dtgInventory.Columns[5].Header = "Статус";
            dtgInventory.Columns[6].Header = "Описание";
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbType.SelectedItem.ToString())
            {
                case "Детали":
                    FillDtgInventoryWithDetails();
                    break;
                case "Устройства":
                    FillDtgInventoryWithDeviced();
                    break;
            }    
        }

        private void dtgRequested_Loaded(object sender, RoutedEventArgs e)
        {
            FillRequested();
        }
        private void FillRequested()
        {
            DataBaseClass _data = new DataBaseClass();
            _data.sqlExecute(string.Format("select ID_Request  as 'ID', Name as 'Название', Articul as 'Артикул', Date_Request as 'Дата запроса:'," +
                " Second_Name + ' ' + First_Name + ' ' + Middle_Name as 'ФИО', " +
                "Requested_Details.Count as 'Количество:', Requested_Details.ID_Detail as 'ID детали' from[dbo].[Requested_Details] inner join Employee on " +
                "[dbo].[Requested_Details].ID_Employee = Employee.ID_Employee " +
                "inner join Inventory on Requested_Details.ID_Detail = ID_Inventory inner join " +
                "Detail on Inventory.ID_Detail = Detail.ID_Detail where Status = 'Запрошен'"), DataBaseClass.act.select);
            dtgRequested.ItemsSource = _data.resultTable.DefaultView;
        }

        private void CancelledFill()
        {
            DataBaseClass _data = new DataBaseClass();
            _data.sqlExecute(string.Format("select ID_Request as 'ID', Name as 'Название', Articul as 'Артикул', Date_Request as 'Дата запроса:'," +
                " Second_Name + ' ' + First_Name + ' ' + Middle_Name as 'ФИО', " +
                "Requested_Details.Count as 'Количество:' from[dbo].[Requested_Details] inner join Employee on " +
                "[dbo].[Requested_Details].ID_Employee = Employee.ID_Employee " +
                "inner join Inventory on Requested_Details.ID_Detail = ID_Inventory inner join " +
                "Detail on Inventory.ID_Detail = Detail.ID_Detail where Status = 'Отменён'"), DataBaseClass.act.select);
            dtgCanceled.ItemsSource = _data.resultTable.DefaultView;
        }

        private void dtgCanceled_Loaded(object sender, RoutedEventArgs e)
        {
            
            CancelledFill();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //delete from Requested_Details where ID_Request = 5
            if (dtgCanceled.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgCanceled.SelectedItems[0];
                {
                    dataBaseClass.sqlExecute(string.Format("delete from Requested_Details where ID_Request = {0}", dataRowView.Row[0].ToString()), DataBaseClass.act.manipulation);
                    CancelledFill();
                }
            }
        }

        private void btAddInventory_Click(object sender, RoutedEventArgs e)
        {
            if (dtgInventory.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgInventory.SelectedItems[0];
                if (dataRowView.Row[5].ToString().Equals("На складе") && cbType.Text!= "Устройства")
                {
                    //
                    dataBaseClass.sqlExecute(string.Format("update Inventory set Count = Count + {0} where ID_Inventory = {1}", tbCount.Text.ToString(),dataRowView.Row[0].ToString()), DataBaseClass.act.manipulation);
                    FillDtgInventoryWithDetails();
                }
            }    
        }

        private void btRemoveInventory_Click(object sender, RoutedEventArgs e)
        {
            if (dtgInventory.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgInventory.SelectedItems[0];
                if (dataRowView.Row[5].ToString().Equals("На складе") && cbType.Text != "Устройства")
                {
                    //
                    dataBaseClass.sqlExecute(string.Format("update Inventory set Count = Count - {0} where ID_Inventory = {1}", tbCount.Text.ToString(), dataRowView.Row[0].ToString()), DataBaseClass.act.manipulation);
                    FillDtgInventoryWithDetails();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Отменён
            if (dtgRequested.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgRequested.SelectedItems[0];
                dataBaseClass.sqlExecute(string.Format("update Requested_Details set Status = 'Отменён' where ID_Request = {0}", dataRowView.Row[0].ToString()), DataBaseClass.act.manipulation);
                FillRequested();

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbType.Text != "Устройства")
            {
                DataBaseClass data = new DataBaseClass();
                data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul], Name_Inventory_Status, Description from Inventory inner join Detail" +
                    " on Inventory.ID_Detail = Detail.ID_Detail where Name_Inventory_Unit = 'Деталь' and Name like '%{0}%'", tbName.Text), DataBaseClass.act.select);
                //Data.dependency.OnChange += Dependency_OnChange_patient;
                dtgInventory.ItemsSource = data.resultTable.DefaultView;
                dtgInventory.Columns[0].Visibility = Visibility.Hidden;
                dtgInventory.Columns[1].Header = "На складе с:";
                dtgInventory.Columns[2].Header = "Количество: ";
                dtgInventory.Columns[3].Header = "Название";
                dtgInventory.Columns[4].Header = "Артикул";
                dtgInventory.Columns[5].Header = "Статус";
                dtgInventory.Columns[6].Header = "Описание";
            }
            else
            {
                DataBaseClass data = new DataBaseClass();
                data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul], Name_Inventory_Status, Description from Inventory inner join Device" +
                    " on Inventory.ID_Device = Device.ID_Device where Name_Inventory_Unit = 'Устройство' and Name like '%{0}%'", tbName.Text), DataBaseClass.act.select);
                //Data.dependency.OnChange += Dependency_OnChange_patient;
                dtgInventory.ItemsSource = data.resultTable.DefaultView;
                dtgInventory.Columns[0].Visibility = Visibility.Hidden;
                dtgInventory.Columns[1].Header = "На складе с:";
                dtgInventory.Columns[2].Header = "Количество: ";
                dtgInventory.Columns[3].Header = "Название";
                dtgInventory.Columns[4].Header = "Артикул";
                dtgInventory.Columns[5].Header = "Статус";
                dtgInventory.Columns[6].Header = "Описание";
            }
        }

        private void tbArticul_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbType.Text != "Устройства")
            {
                DataBaseClass data = new DataBaseClass();
                data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul], Name_Inventory_Status, Description from Inventory inner join Detail" +
                    " on Inventory.ID_Detail = Detail.ID_Detail where Name_Inventory_Unit = 'Деталь' and Articul like '{0}%'", tbArticul.Text), DataBaseClass.act.select);
                //Data.dependency.OnChange += Dependency_OnChange_patient;
                dtgInventory.ItemsSource = data.resultTable.DefaultView;
                dtgInventory.Columns[0].Visibility = Visibility.Hidden;
                dtgInventory.Columns[1].Header = "На складе с:";
                dtgInventory.Columns[2].Header = "Количество: ";
                dtgInventory.Columns[3].Header = "Название";
                dtgInventory.Columns[4].Header = "Артикул";
                dtgInventory.Columns[5].Header = "Статус";
                dtgInventory.Columns[6].Header = "Описание";
            }
            else
            {
                DataBaseClass data = new DataBaseClass();
                data.sqlExecute(string.Format("select [ID_Inventory], [DateTimeIncome], Inventory.[Count], [Name], [Articul], Name_Inventory_Status, Description from Inventory inner join Device" +
                    " on Inventory.ID_Device = Device.ID_Device where Name_Inventory_Unit = 'Устройство' and Articul like '{0}%'", tbArticul.Text), DataBaseClass.act.select);
                //Data.dependency.OnChange += Dependency_OnChange_patient;
                dtgInventory.ItemsSource = data.resultTable.DefaultView;
                dtgInventory.Columns[0].Visibility = Visibility.Hidden;
                dtgInventory.Columns[1].Header = "На складе с:";
                dtgInventory.Columns[2].Header = "Количество: ";
                dtgInventory.Columns[3].Header = "Название";
                dtgInventory.Columns[4].Header = "Артикул";
                dtgInventory.Columns[5].Header = "Статус";
                dtgInventory.Columns[6].Header = "Описание";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dtgRequested.SelectedItem != null)
            {
                DataBaseClass dataBaseClass = new DataBaseClass();
                DataBaseClass dataBaseClass1 = new DataBaseClass();
                DataRowView dataRowView = (DataRowView)dtgRequested.SelectedItems[0];
                dataBaseClass1.sqlExecute(string.Format("update Inventory set Count = Count - {0} where ID_Inventory = {1}", dataRowView.Row[5].ToString(), dataRowView.Row[6].ToString()), DataBaseClass.act.manipulation);
                dataBaseClass.sqlExecute(string.Format("update Requested_Details set Status = 'Получен' where ID_Request = {0}", dataRowView.Row[0].ToString()), DataBaseClass.act.manipulation);

                FillRequested();
                
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
    }
}
