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
    /// Логика взаимодействия для AddOrEditAnimalGroupWindow.xaml
    /// </summary>
    public partial class AddOrEditAnimalGroupWindow : Window
    {
        public AddOrEditAnimalGroupWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            typeGroupCB.ItemsSource = App.db.groupTypes.ToList();
            roomCB.ItemsSource = App.db.rooms.ToList();
            employeeCB.ItemsSource = App.db.employees.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            groupType groupType = null;
            if (typeGroupCB.SelectedItem != null) groupType = typeGroupCB.SelectedItem as groupType;
            else MessageBox.Show("Выберите тип группы!");

            room room = null;
            if(roomCB.SelectedItem != null) room = roomCB.SelectedItem as room;
            else MessageBox.Show("Выберите помещение!");

            employee employee = null;
            if(employeeCB.SelectedItem != null) employee = employeeCB.SelectedItem as employee;
            else MessageBox.Show("Выберите ответственного!");

            if (groupType != null && room != null && employee != null)
            {
                try
                {
                    AnimalGroup animalGroup = new AnimalGroup();
                    animalGroup.employee = employee;
                    animalGroup.room = room;
                    animalGroup.groupType = groupType;

                    App.db.AnimalGroups.Add(animalGroup);
                    App.db.SaveChanges();

                    MessageBox.Show("Успешно сохранено");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            else MessageBox.Show("Исправьте ошибки!");
        }
    }
}
