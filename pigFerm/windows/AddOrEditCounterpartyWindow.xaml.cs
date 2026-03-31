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
    /// Логика взаимодействия для AddOrEditCounterpartyWindow.xaml
    /// </summary>
    public partial class AddOrEditCounterpartyWindow : Window
    {
        public AddOrEditCounterpartyWindow()
        {
            InitializeComponent();
        }
        public AddOrEditCounterpartyWindow(string target)
        {
            if(target == "add")
            {

            }
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            // Валидация данных
            if (string.IsNullOrWhiteSpace(txtName.Text)) MessageBox.Show("Пожалуйста, заполните наименование контрагента");
            else name = txtName.Text.Trim();

            string adres = "";
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) MessageBox.Show("Пожалуйста, заполните адрес");
            else adres = txtAddress.Text.Trim();

            if (name != "" && adres != "")
            {
                try
                {
                    // Создание объекта counterparty
                    var newCounterparty = new counterparty
                    {
                        nameCounterparties = name,
                        adres = adres,
                        description = txtDescription.Text.Trim(),
                        category = "Покупатель",
                        isRegular = chkIsRegular.IsChecked ?? false
                    };

                    App.db.counterparties.Add(newCounterparty);
                    App.db.SaveChanges();

                    MessageBox.Show($"Контрагент \"{newCounterparty.nameCounterparties}\" успешно создан!");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
                }
            }
            else MessageBox.Show("Исправьте ошибки!");
            
        }
    }
}
