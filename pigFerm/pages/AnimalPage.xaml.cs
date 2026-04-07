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
    /// Логика взаимодействия для AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        public AnimalPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            breedLV.ItemsSource = App.db.breeds.ToList();
            typeGroupLV.ItemsSource = App.db.groupTypes.ToList();
            groupLV.ItemsSource = App.db.AnimalGroups.ToList();
            animalLV.ItemsSource = App.db.Animals.ToList();
        }

        private void AddNewBreedBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewBreedWindow addNewBreedWindow = new AddNewBreedWindow();
            addNewBreedWindow.ShowDialog();

            LoadData();
        }

        private void addNewTypeGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewGroupTypeWindow addNewGroupTypeWindow = new AddNewGroupTypeWindow();
            addNewGroupTypeWindow.ShowDialog();

            LoadData();
        }

        private void addNewGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditAnimalGroupWindow addOrEditAnimalGroupWindow = new AddOrEditAnimalGroupWindow();
            addOrEditAnimalGroupWindow.ShowDialog();

            LoadData();
        }

        private void addNewAnimalBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditAnimalWindow addNewAnimalWindow = new AddOrEditAnimalWindow();
            addNewAnimalWindow.ShowDialog();

            LoadData();
        }
    }
}
