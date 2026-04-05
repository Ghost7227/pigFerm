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
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
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


        }
    }
}
