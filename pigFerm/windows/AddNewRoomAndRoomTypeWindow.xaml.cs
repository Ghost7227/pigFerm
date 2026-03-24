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
            if(name != string.Empty)
            {

                MessageBox.Show("Сохранено");
            }
        }
    }
}
