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
    /// Логика взаимодействия для ShipmentPage.xaml
    /// </summary>
    public partial class ShipmentPage : Page
    {
        public ShipmentPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            shipmentLV.ItemsSource = App.db.shipments.ToList();
        }

        private void addShipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            AddShipmentWindow addShipmentWindow = new AddShipmentWindow();
            addShipmentWindow.ShowDialog();
            LoadData();
        }
    }
}
