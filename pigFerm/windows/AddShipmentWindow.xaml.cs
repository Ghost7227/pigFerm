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
        List<product> productsInDb = new List<product>();
        List<product> selectedProducts = new List<product>();
        DateTime dateDoc = DateTime.Now;

        public AddShipmentWindow()
        {
            InitializeComponent();
            dp1.SelectedDate = dateDoc;
            counterpartyCB.ItemsSource = App.db.counterparties.ToList();
            LoadData();
        }
        void LoadData()
        {
            productsInDb = App.db.products.Where(pr => pr.quantity > 0 && pr.expirationDate > dateDoc && pr.prodauctionDate < dateDoc).ToList();
            
            foreach (var product in selectedProducts.ToList())
            {
                if(productsInDb.Contains(product)) productsInDb.Remove(product);
                if(product.expirationDate < dateDoc || product.prodauctionDate > dateDoc) selectedProducts.Remove(product);
            }

            LoadLists();
        }

        void LoadLists()
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
            else MessageBox.Show("Выберите контрагента");

            if (dp1.SelectedDate != null) dateDoc = dp1.SelectedDate.Value;
            else MessageBox.Show("Выберите дату");

            decimal sum = 0;
            if (selectedProducts.Count > 0)
            {
                foreach (var product in selectedProducts.ToList())
                {
                    if(product.expirationDate <= dateDoc) {
                        selectedProducts.Remove(product);
                    }
                    else sum += product.quantity * product.queryQuantity;
                }
            }


            if (counterparty != null && dp1.SelectedDate != null && selectedProducts.Count > 0)
            {
                try
                {
                    shipment shipment = new shipment();
                    shipment.counterparty = counterparty;
                    shipment.date = dateDoc;
                    shipment.sum = sum;

                    App.db.shipments.Add(shipment);
                    App.db.SaveChanges();

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
                LoadLists();
            }
        }
        private void selectedProdLVItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            product selectedProduct = selectedProdLV.SelectedItem as product;
            if (selectedProduct != null)
            {
                selectedProducts.Remove(selectedProduct);
                productsInDb.Add(selectedProduct);
                LoadLists();
            }
        }

        private void queryQuantityTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
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
                if (int.TryParse(str, out parse))
                {
                    if(parse > product.quantity)
                    {
                        quantityTB.Text = string.Empty;
                        MessageBox.Show($"Нельзя продать больше, чем есть на складе ({product.quantity})");
                    }
                    else product.queryQuantity = parse;
                }
            }
        }

        private void dp1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dateDoc = dp1.SelectedDate.Value;
            LoadData();
        }
    }
}
