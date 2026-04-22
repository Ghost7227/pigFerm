using pigFerm.database;
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
    /// Логика взаимодействия для EventPage.xaml
    /// </summary>
    public partial class EventPage : Page
    {
        string sortStr = "";
        string searchStr = "";
        public EventPage()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            eventTypeLV.ItemsSource = App.db.EventTypes.OrderBy(et => et.id).ToList();
            eventLV.ItemsSource = null;
            List<@event> events = new List<@event>();

            if (!string.IsNullOrWhiteSpace(searchStr))
            {
                events = App.db.events.Where(ev => ev.EventType.nameEvent.Contains(searchStr) || ev.dateTime.ToString().Contains(searchStr) || ev.descriiption.Contains(searchStr)).ToList();
            }
            else events = App.db.events.ToList();

            if (sortStr == "unstandart") eventLV.ItemsSource = events.OrderByDescending(ev => ev.id).ToList();
            else if (sortStr == "date") eventLV.ItemsSource = events.OrderBy(ev => ev.dateTime).ToList();
            else if (sortStr == "undate") eventLV.ItemsSource = events.OrderByDescending(ev => ev.dateTime).ToList();
            else eventLV.ItemsSource = events.OrderBy(ev => ev.id).ToList();
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
            @event eve = eventLV.SelectedItem as @event;
            if (eve != null)
            {
                AddOrEditEventWindow edit = new AddOrEditEventWindow(eve);
                edit.ShowDialog();
                LoadData();
            }
        }

        private void editItemMenu_Click(object sender, RoutedEventArgs e)
        {
            @event eve = eventLV.SelectedItem as @event;
            if (eve != null)
            {
                AddOrEditEventWindow edit = new AddOrEditEventWindow(eve);
                edit.ShowDialog();
                LoadData();
            }
        }

        private void deleteItemMenu_Click(object sender, RoutedEventArgs e)
        {
            @event eve = eventLV.SelectedItem as @event;
            if (eve != null)
            {
                try
                {
                    App.db.events.Remove(eve);
                    App.db.SaveChanges();
                    MessageBox.Show("Событие удалено");
                }
                catch (Exception)
                {
                    MessageBox.Show("Событие не может быть удалено, так как на него ссылаются другие объекты");
                }
            }
        }

        private void RB_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb != null)
            {
                if (rb.Name == "unstandartRB") sortStr = "unstandart";
                else if (rb.Name == "dateRB") sortStr = "date";
                else if (rb.Name == "undateRB") sortStr = "undate";
                else sortStr = "";
                LoadData();
            }
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(searchTB.Text)) searchStr = searchTB.Text.Trim();
            else searchStr = "";
            LoadData();
        }
    }
}
