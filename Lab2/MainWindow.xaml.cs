using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : System.Windows.Window
    {
        const int threatsPerPage = 15;
        static Paging PagedTable = new Paging();
        IList<Threat> threats = ExcelParser.GetExcelThreats();
        public static Threat choosenThreat;
        
        public MainWindow()
        {
            InitializeComponent();

            PagedTable.PageIndex = 0;
            DataTable dataTable = PagedTable.SetPaging(threats, threatsPerPage);
            dataGrid.ItemsSource = dataTable.DefaultView;
            /*foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = row[0].ToString();
                for (int i = 1; i < dataTable.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                listView_Services.Items.Add(item);
            }*/

            PageNumberDisplay();
        }
        void PageNumberDisplay()
        {
            PageContent.Content = $"{PagedTable.PageIndex + 1} страница из {threats.Count / threatsPerPage + 1}";
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = PagedTable.Previous(threats, threatsPerPage).DefaultView;
            PageNumberDisplay();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = PagedTable.Next(threats, threatsPerPage).DefaultView;
            PageNumberDisplay();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            DataRowView view = row.Item as DataRowView;
            foreach(Threat threat in Threat.threats)
            {
                if (threat.ThreatId == view.Row.ItemArray[0].ToString()) 
                { 
                    choosenThreat = threat;
                    new ThreatExtraWindow().Show();
                }
            }
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ExcelParser.DownloadExcel();
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            new SaveWindow().Show();
        }
        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Загрузка завершена");
        }
    }
}
