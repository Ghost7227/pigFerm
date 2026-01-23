using pigFerm.windows;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pigFerm.pages
{
    /// <summary>
    /// Логика взаимодействия для employeesPage.xaml
    /// </summary>
    public partial class employeesPage : Page
    {
        public employeesPage()
        {
            InitializeComponent();
            employeeLV.ItemsSource = App.db.employees.ToList();
        }

        private void addNewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            createOrEditEmployeeWindow createOrEditEmployeeWindow = new createOrEditEmployeeWindow();
            if(createOrEditEmployeeWindow.ShowDialog() == true)
            {
                if(createOrEditEmployeeWindow.DialogResult == true)
                {
                    MessageBox.Show("Сотрудник добавлен");
                }
            }
        }
    }
}
