using pigFerm.database;
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
using System.Windows.Shapes;

namespace pigFerm.windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewDepartamentWindow.xaml
    /// </summary>
    public partial class AddNewDepartamentWindow : Window
    {
        public AddNewDepartamentWindow()
        {
            InitializeComponent();
        }

        private void saveNewDepBtn_Click(object sender, RoutedEventArgs e)
        {
            if(nameDepartamentTB.Text != string.Empty)
            {
                try
                {
                    department department = new department();
                    department.nameDepartment = nameDepartamentTB.Text;

                    App.db.departments.Add(department);
                    App.db.SaveChanges();

                    MessageBox.Show("Успешно добавлено!");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Возможно, отдел с таким названием уже существует!");
                }
            }
        }
    }
}
