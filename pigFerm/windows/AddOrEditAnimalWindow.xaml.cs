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
    /// Логика взаимодействия для AddOrEditAnimalWindow.xaml
    /// </summary>
    public partial class AddOrEditAnimalWindow : Window
    {
        public AddOrEditAnimalWindow()
        {
            InitializeComponent();
            breedCB.ItemsSource = App.db.breeds.ToList();
            groupCB.ItemsSource = App.db.AnimalGroups.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            breed breed = null;
            if(breedCB.SelectedItem != null) breed = breedCB.SelectedItem as breed;
            else MessageBox.Show("Укажите породу!");

            string eartag = "";
            if (!string.IsNullOrWhiteSpace(ear_tagTB.Text)) eartag = ear_tagTB.Text.Trim();
            else MessageBox.Show("Укажите ID ушной бирки!");

            string name = "";
            if(!string.IsNullOrWhiteSpace(nameTB.Text)) name = nameTB.Text.Trim();
            
            DateTime bd = DateTime.Now;
            if(bdDatePicker.SelectedDate != null) bd = bdDatePicker.SelectedDate.Value;

            string gender = "";
            if (mGenderRB.IsChecked == true) gender = "М";
            else if (wGenderRB.IsChecked == true) gender = "Ж";
            else MessageBox.Show("Выберите пол животного!");

            AnimalGroup animalGroup = null;
            if(groupCB.SelectedItem != null) animalGroup = groupCB.SelectedItem as AnimalGroup;
            else MessageBox.Show("Выберите группу!");

            Animal mother = null;
            Animal father = null;
            string origin = "";
            DateTime dateTimeArrival = DateTime.Now.AddDays(3);
            if(sRB.IsChecked == true)
            {
                if(motherCB.SelectedItem != null) mother = motherCB.SelectedItem as Animal;
                else MessageBox.Show("Выберите мать!");
                if (fatherCB.SelectedItem != null) father = fatherCB.SelectedItem as Animal;
                else MessageBox.Show("Выберите отца!");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(originTB.Text)) origin = originTB.Text.Trim();
                else MessageBox.Show("Заполните поле \"Происхождение\"!");
                if (arrivalDateDatePicker.SelectedDate != null) dateTimeArrival = arrivalDateDatePicker.SelectedDate.Value;
                else MessageBox.Show("Дата прибытия должна быть меньше текущего времени!");
            }

            if (breed != null && eartag != "" && bd < DateTime.Now && gender != "" && animalGroup != null && (mother != null && father != null || origin != "" && dateTimeArrival < DateTime.Now))
            {
                Animal newAnimal = new Animal();
                newAnimal.breed1 = breed;
                newAnimal.ear_tag = eartag;
                newAnimal.name = name;
                newAnimal.birth_date = bd;
                newAnimal.gender = gender;
                newAnimal.AnimalGroup = animalGroup;

                if(mother == null && father == null)
                {
                    newAnimal.origin = origin;
                    newAnimal.arrival_date = dateTimeArrival;
                }
                else
                {
                    newAnimal.mother_id = mother.id;
                    newAnimal.father_id = father.id;
                }

                try
                {
                    App.db.Animals.Add(newAnimal);
                    App.db.SaveChanges();

                    MessageBox.Show("Успешно добавлено");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Возможно, животное с таким ID ушной бирки уже существует");
                }
            }
        }

        private void sRB_Checked(object sender, RoutedEventArgs e)
        {
            motherCB.Visibility = Visibility.Visible;
            motherTBlock.Visibility = Visibility.Visible;
            fatherCB.Visibility = Visibility.Visible;
            fatherTBlock.Visibility = Visibility.Visible;

            originTB.Visibility = Visibility.Collapsed;
            originTBlock.Visibility = Visibility.Collapsed;
            arrivalDateDatePicker.Visibility = Visibility.Collapsed;
            arrivaTBlock.Visibility = Visibility.Collapsed;
        }

        private void buyRB_Checked(object sender, RoutedEventArgs e)
        {
            motherCB.Visibility = Visibility.Collapsed;
            motherTBlock.Visibility = Visibility.Collapsed;
            fatherCB.Visibility = Visibility.Collapsed;
            fatherTBlock.Visibility = Visibility.Collapsed;

            originTB.Visibility = Visibility.Visible;
            originTBlock.Visibility = Visibility.Visible;
            arrivalDateDatePicker.Visibility = Visibility.Visible;
            arrivaTBlock.Visibility = Visibility.Visible;

            LoadParents();
        }

        void LoadParents()
        {
            motherCB.ItemsSource = App.db.Animals.Where(a => a.gender == "Ж").ToList();
            fatherCB.ItemsSource = App.db.Animals.Where(a => a.gender == "М").ToList();
        }
    }
}
