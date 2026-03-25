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
using pigFerm.windows;

namespace pigFerm.pages
{
    /// <summary>
    /// Логика взаимодействия для RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        string target;
        public RoomsPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            roomsLV.ItemsSource = App.db.rooms.ToList();
            roomTypesLV.ItemsSource= App.db.roomTypes.ToList();
        }

        private void addNewRoom_Click(object sender, RoutedEventArgs e)
        {
            target = "room";
            AddNewRoomAndRoomTypeWindow addNewRoomAndRoomTypeWindow = new AddNewRoomAndRoomTypeWindow(target);
            addNewRoomAndRoomTypeWindow.ShowDialog();
            LoadData();
        }

        private void addNewRoomType_Click(object sender, RoutedEventArgs e)
        {
            target = "type";
            AddNewRoomAndRoomTypeWindow addNewRoomAndRoomTypeWindow = new AddNewRoomAndRoomTypeWindow(target);
            addNewRoomAndRoomTypeWindow.ShowDialog();
            LoadData();
        }
    }
}
