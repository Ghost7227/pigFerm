using pigFerm.database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //ObservableCollection<product> productsInDb { get; set; }
        //ObservableCollection<product> selectedProducts {  get; set; }
        List <product> productsInDb = new List <product> ();
        List<product> selectedProducts = new List<product>();

        public AddShipmentWindow()
        {
            InitializeComponent();
            counterpartyCB.ItemsSource = App.db.counterparties.ToList();
            productsInDb = App.db.products.Where(pr => pr.quantity > 0).ToList();
            prodLV.ItemsSource = productsInDb;
        }

        void LoadData()
        {
            selectedProdLV.ItemsSource = null;
            selectedProdLV.ItemsSource = selectedProducts;
            prodLV.ItemsSource = null;
            prodLV.ItemsSource = productsInDb;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            counterparty counterparty = null;
            if (counterpartyCB.SelectedItem != null) counterparty = counterpartyCB.SelectedItem as counterparty;
            else MessageBox.Show("");

            DateTime date = DateTime.Now;
            if (dp1.SelectedDate != null) date = dp1.SelectedDate.Value;
            else MessageBox.Show("");
            
            decimal sum = 0;
            if(selectedProducts.Count > 0)
            {
                foreach (var product in selectedProducts)
                {
                    sum += product.quantity * product.queryQuantity;
                }
            }

            if(selectedProducts.Count > 0)
            {
                foreach (var product in selectedProducts)
                {
                    
                }
            }


            if (counterparty != null && dp1.SelectedDate != null && selectedProducts.Count > 0)
            {
                try
                {
                    shipment shipment = new shipment();
                    shipment.counterparty = counterparty;
                    shipment.date = date;
                    shipment.sum = sum;

                    App.db.shipments.Add(shipment);
                    App.db.SaveChanges();
                    MessageBox.Show($"id: {shipment.id}");

                    foreach (var product in selectedProducts)
                    {
                        //MessageBox.Show(product.queryQuantity.ToString());
                        productShipment productShipment = new productShipment
                        {
                            idProduct = product.id,
                            idShipment = shipment.id,
                            quantity = product.queryQuantity,
                        };
                        App.db.productShipments.Add(productShipment);
                        App.db.SaveChanges();
                    }

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

        private void prodLVItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            product selectedProduct = prodLV.SelectedItem as product;
            if (selectedProduct != null)
            {
                selectedProducts.Add(selectedProduct);
                productsInDb.Remove(selectedProduct);
                LoadData();
            }
        }
        private void selectedProdLVItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            product selectedProduct = selectedProdLV.SelectedItem as product;
            if (selectedProduct != null)
            {
                selectedProducts.Remove(selectedProduct);
                productsInDb.Add(selectedProduct);
                LoadData();
            }
        }

        private void queryQuantityTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space) e.Handled = true;
        }

        private void queryQuantityTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void queryQuantityTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox quantityTB = sender as TextBox;
            string str = quantityTB.Text;

            product product = prodLV.SelectedItem as product;
            if (product != null)
            {
                int parse = 0;
                if (int.TryParse(str, out parse)) product.queryQuantity = parse;
            }
        }
    }
}
