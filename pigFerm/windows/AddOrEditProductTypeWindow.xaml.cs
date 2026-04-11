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
    /// Логика взаимодействия для AddOrEditProductTypeWindow.xaml
    /// </summary>
    public partial class AddOrEditProductTypeWindow : Window
    {
        public AddOrEditProductTypeWindow()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            if (!string.IsNullOrWhiteSpace(nameTB.Text)) name = nameTB.Text.Trim();
            else MessageBox.Show("Введите название!");

            string unit = "";
            if (!string.IsNullOrWhiteSpace(unitTB.Text)) unit = unitTB.Text.Trim();
            else MessageBox.Show("Укажите единицу измерения!");

            decimal cost = 0;
            decimal costParse;
            if (!string.IsNullOrWhiteSpace(costTB.Text))
            {
                if (decimal.TryParse(costTB.Text, out costParse)) cost = costParse;
                else cost = -1;
            }
            else MessageBox.Show("Не удалось преобразовать стоимость в число!");

            if(name != "" && unit != "" && cost > 0)
            {
                try
                {
                    productType productType = new productType();
                    productType.nameTypeProduct = name;
                    productType.unit = unit;
                    productType.cost = cost;

                    App.db.productTypes.Add(productType);
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
