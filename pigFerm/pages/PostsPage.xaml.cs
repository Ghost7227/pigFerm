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
using pigFerm.windows;

namespace pigFerm.pages
{
    /// <summary>
    /// Логика взаимодействия для PostsPage.xaml
    /// </summary>
    public partial class PostsPage : Page
    {
        public PostsPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            PostsListView.ItemsSource = App.db.posts.ToList();
            DepartamentListView.ItemsSource = App.db.departments.ToList();
        }

        private void addNewDepartamentBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewDepartamentWindow addNewDepartamentWindow = new AddNewDepartamentWindow();
            addNewDepartamentWindow.ShowDialog();
            LoadData();
        }
    }
}
