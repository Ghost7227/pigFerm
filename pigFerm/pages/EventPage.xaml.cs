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
using pigFerm.database;
using pigFerm.viewWindows;
using pigFerm.windows;

namespace pigFerm.pages
{
    /// <summary>
    /// Логика взаимодействия для EventPage.xaml
    /// </summary>
    public partial class EventPage : Page
    {
        public EventPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            eventTypeLV.ItemsSource = App.db.EventTypes.ToList();
            eventLV.Items.Clear();
            eventLV.ItemsSource = App.db.events.ToList();
        }

        private void addNewTypeEventBtn_Click(object sender, RoutedEventArgs e)
        {
            string target = "add";
            AddOrEditEventTypeWindow addOrEditEventTypeWindow = new AddOrEditEventTypeWindow(target);
            addOrEditEventTypeWindow.ShowDialog();
            LoadData();
        }

        private void addNewEventBtn_Click(object sender, RoutedEventArgs e)
        {
            string target = "add";
            AddOrEditEventWindow add = new AddOrEditEventWindow(target);
            add.ShowDialog();
            LoadData();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            @event ev = eventLV.SelectedItem as @event; 
            EventViewWindow eventViewWindow = new EventViewWindow(ev);
            eventViewWindow.ShowDialog();
        }

        private void editItemMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteItemMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
