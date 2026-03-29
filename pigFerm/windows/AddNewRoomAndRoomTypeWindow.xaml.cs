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
using pigFerm.windows;

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
                roomTypeCB.ItemsSource = App.db.roomTypes.ToList();
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
            if (roomTypeCB.SelectedItem != null) roomType = roomTypeCB.SelectedItem as roomType;
            else MessageBox.Show("Выберите тип помещения!");

            string adres = string.Empty;
            if(adresTB.Text != string.Empty) adres = adresTB.Text;
            else MessageBox.Show("Введите адрес!");

            int capacity = -1;
            int parseCapacity = 0;
            if(capacityTB.Text != string.Empty && int.TryParse(currentCountTB.Text, out parseCapacity))
            {
                capacity = parseCapacity;
                if(capacity < 0) MessageBox.Show("Вместимость не может быть отрицательной!"); 
            }
            else if(capacityTB.Text.Any(ch => !char.IsDigit(ch))) MessageBox.Show("Вместимость должна содержать только цифры!");
            else MessageBox.Show("Укажите вместимость!");

            int currentCount = -1;
            int parse = 0;
            if (currentCountTB.Text != string.Empty && int.TryParse(currentCountTB.Text, out parse))
            {
                currentCount = parse;
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

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void Number_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled= true;
            }
        }
    }
}
