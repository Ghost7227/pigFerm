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
    /// Логика взаимодействия для AddShipmentWindow.xaml
    /// </summary>
    public partial class AddShipmentWindow : Window
    {
        public AddShipmentWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            counterpartyCB.ItemsSource = App.db.counterparties.ToList();
            prodLV.ItemsSource = App.db.products.Where(pr => pr.quantity > 0).ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            counterparty counterparty = null;
            if (counterpartyCB.SelectedItem != null) counterparty = counterpartyCB.SelectedItem as counterparty;
            else MessageBox.Show("");

            DateTime date = DateTime.Now;
            if (dp1.SelectedDate != null) date = dp1.SelectedDate.Value;
            else MessageBox.Show("");



            if (counterparty != null && dp1.SelectedDate != null)
            {
                try
                {
                    shipment shipment = new shipment();
                    shipment.counterparty = counterparty;
                    shipment.date = date;

                    App.db.shipments.Add(shipment);
                    App.db.SaveChanges();
                    
                    MessageBox.Show("Успешно сохранено");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при сохранении!");
                }
            }
            else MessageBox.Show("Исправьте ошибки!");

        }
    }
}
