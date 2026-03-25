using pigFerm.pages;
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

namespace pigFerm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //lv1.ItemsSource = App.db.groupTypes.ToList();
        }

        private void employeeBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new employeesPage());
        }

        private void postBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PostsPage());
        }

        private void roomBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new RoomsPage());
        }
    }
}
