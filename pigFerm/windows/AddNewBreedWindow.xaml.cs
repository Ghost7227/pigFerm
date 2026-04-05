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
    /// Логика взаимодействия для AddNewBreedWindow.xaml
    /// </summary>
    public partial class AddNewBreedWindow : Window
    {
        public AddNewBreedWindow()
        {
            InitializeComponent();
        }

        private void saveBreedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBreedTB.Text))
            {
                try
                {
                    breed breed = new breed();
                    breed.nameBreed = nameBreedTB.Text.Trim();

                    App.db.breeds.Add(breed);
                    App.db.SaveChanges();
                    MessageBox.Show($"Порода {breed.nameBreed} успешно добавлена");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show($"Ошибка! Возможно, порода с таким названием уже есть");
                }
            }
            else MessageBox.Show("Заполните название!");
        }
    }
}
