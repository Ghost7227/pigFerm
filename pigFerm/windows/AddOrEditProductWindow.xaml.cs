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
    /// Логика взаимодействия для AddOrEditProductWindow.xaml
    /// </summary>
    public partial class AddOrEditProductWindow : Window
    {
        public AddOrEditProductWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            typeProductCB.ItemsSource = App.db.productTypes.ToList();
            eventCB.ItemsSource = App.db.events.ToList();
        }

        product SeekProduct(product product)
        {
            int idProdType = product.idType;
            int idEvent = product.idEvent;
            product existProduct = App.db.products.FirstOrDefault(pr => pr.idType == idProdType && pr.idEvent == idEvent);
            
            if(existProduct != null) 
            {
                MessageBox.Show("Найдено совпадение типа продукции по дате и событию!", "применить изменения?", MessageBoxButton.YesNoCancel);
                return existProduct;
            }
                    
            else return null;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            productType productType = null;
            if (typeProductCB.SelectedItem != null) productType = typeProductCB.SelectedItem as productType;
            else MessageBox.Show("выберите вид продукции!");

            int quantity = -1;
            int pars = 0;
            if(int.TryParse(quantityTB.Text, out pars))
            {
                if (pars > 0) quantity = pars;
                else MessageBox.Show("Количество продукции не может быть отрицательным!");
            }
            else MessageBox.Show("Не удалось преобразовать в число!");

            @event @event = null;
            if (eventCB.SelectedItem != null) @event = eventCB.SelectedItem as @event;
            else MessageBox.Show("Выберите событие, в результате которого была получена продукция!");

            DateTime or = DateTime.Now;
            DateTime prodDate = or;
            if(productionDateDP.SelectedDate != null) prodDate = productionDateDP.SelectedDate.Value;
            else MessageBox.Show("Выберите дату производства");
            
            DateTime expDate = or;
            if (expirationDateDP.SelectedDate != null) expDate = expirationDateDP.SelectedDate.Value;
            else MessageBox.Show("Выберите дату окончания срока годности");

            string notes = "Без заметок";
            if(!string.IsNullOrWhiteSpace(descriptionTB.Text)) notes = descriptionTB.Text.Trim();

            if (productType != null && quantity > 0 && @event != null && prodDate <= or && expDate > or )
            {
                if (prodDate < expDate)
                {
                    try
                    {
                        product product = new product();
                        product.quantity = quantity;
                        product.descriiption = notes;
                        product.prodauctionDate = prodDate;
                        product.expirationDate = expDate;
                        product.@event = @event;
                        product.productType = productType;

                        if (SeekProduct(product) != null)
                        {
                            product existProduct = SeekProduct(product);
                            existProduct.quantity += quantity;

                            App.db.SaveChanges();
                            MessageBox.Show("Успешно изменено");
                        }
                        else
                        {
                            App.db.products.Add(product);
                            App.db.SaveChanges();

                            MessageBox.Show("Успешно добавлено");
                        }
                        Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка при сохранении!");
                    }
                }
                else MessageBox.Show("Дата окончания срока годности не может быть меньше даты производства!");
            }
            else MessageBox.Show("Исправьте ошибки!");
        }
    }
}
