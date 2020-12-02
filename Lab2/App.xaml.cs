using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //выход
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ExcelParser.ExitExcel();
        }
    }
}
