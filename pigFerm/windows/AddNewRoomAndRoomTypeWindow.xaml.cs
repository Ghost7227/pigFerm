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
using pigFerm.database;

namespace pigFerm.windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewRoomAndRoomTypeWindow.xaml
    /// </summary>
    public partial class AddNewRoomAndRoomTypeWindow : Window
    {
        public AddNewRoomAndRoomTypeWindow()
        {
            InitializeComponent();
        }

        public AddNewRoomAndRoomTypeWindow(String target)
        {
            InitializeComponent();
            if(target == "type")
            {
                createRoomGrid.Visibility = Visibility.Collapsed;
            }
            else if(target == "room")
            {
                createRoomTypeGrid.Visibility = Visibility.Collapsed;
                roonTypeCB.ItemsSource = App.db.roomTypes.ToList();
            }
            else
            {
                MessageBox.Show("Ошибка!");
                Close();
            }
        }

        private void addNewRoomTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameRoomTypeTB.Text;
            if(name != string.Empty && name.Any(ch => char.IsLetterOrDigit(ch)))
            {
                try
                {
                    roomType roomType = new roomType();
                    roomType.nameRoomTtpes = name;

                    App.db.roomTypes.Add(roomType);
                    App.db.SaveChanges();

                    MessageBox.Show("Сохранено");
                    Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Название не должно содержать спецСимволы!");
            }
        }

        private void addNewRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            roomType roomType = null;
            if (roonTypeCB.SelectedItem != null) roomType = roonTypeCB.SelectedItem as roomType;
            else MessageBox.Show("Выберите тип помещения!");

            string adres = string.Empty;
            if(adresTB.Text != string.Empty) adres = adresTB.Text;
            else MessageBox.Show("Введите адрес!");

            int capacity = -1;
            if(capacityTB.Text != string.Empty && capacityTB.Text.Any(ch => char.IsDigit(ch)))
            {
                capacity = Convert.ToInt32(capacityTB.Text);
                if(capacity < 0) MessageBox.Show("Вместимость не может быть отрицательной!"); 
            }
            else if(capacityTB.Text.Any(ch => !char.IsDigit(ch))) MessageBox.Show("Вместимость должна содержать только цифры!");
            else MessageBox.Show("Укажите вместимость!");

            int currentCount = -1;
            if (currentCountTB.Text != string.Empty && currentCountTB.Text.Any(ch => char.IsDigit(ch)))
            {
                currentCount = Convert.ToInt32(currentCountTB.Text);
                if (currentCount < 0) MessageBox.Show("Количество занятых мест не может быть отрицательным!"); 
            }
            else if (currentCountTB.Text.Any(ch => !char.IsDigit(ch))) MessageBox.Show("Количество занятых мест должно содержать только цифры!");
            else MessageBox.Show("Укажите количество занятых мест!");

            string locationNotes = string.Empty;
            if(locationNotesTB.Text != string.Empty) locationNotes = locationNotesTB.Text; 
            else MessageBox.Show("Заполните описание!");

            if(currentCount <= capacity)
            {
                if (roomType != null && adres != string.Empty && capacity >= 0 && currentCount >= 0 && locationNotes != string.Empty)
                {
                    room room = new room();
                    room.roomType = roomType;
                    room.adres = adres;
                    room.capacity = capacity;
                    room.currentCount = currentCount;
                    room.locationNotes = locationNotes;

                    try
                    {
                        App.db.rooms.Add(room);
                        App.db.SaveChanges();
                        MessageBox.Show("Успешно добавлено");
                        Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка добавления");
                    }
                }
                else MessageBox.Show("Исправьте ошибки"); 
            }
            else if(currentCount > capacity) MessageBox.Show("Количество занятых мест не может быть больше вместимости. \nИсправьте ошибки");
            else MessageBox.Show("Исправьте ошибки");
        }
    }
}
