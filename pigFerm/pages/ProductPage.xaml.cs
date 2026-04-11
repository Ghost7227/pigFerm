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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            ProductTypeLV.ItemsSource = App.db.productTypes.ToList();
            productLV.ItemsSource = App.db.products.ToList();
        }

        private void addNewProductTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditProductTypeWindow addOrEditProductTypeWindow = new AddOrEditProductTypeWindow();
            addOrEditProductTypeWindow.ShowDialog();

            LoadData();
        }

        private void addNewProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditProductWindow addOrEditProductWindow = new AddOrEditProductWindow();
            addOrEditProductWindow.ShowDialog();

            LoadData();
        }
    }
}
