using pigFerm.database;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Xml.Schema;

namespace pigFerm.windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditEventWindow.xaml
    /// </summary>
    public partial class AddOrEditEventWindow : Window
    {
        public AddOrEditEventWindow()
        {
            InitializeComponent();
        }

        public AddOrEditEventWindow(string target)
        {
            InitializeComponent();
            if(target == "add") 
            {
                eventtypeCB.ItemsSource = App.db.EventTypes.ToList();
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            EventType eventType = null;
            if (eventtypeCB.SelectedItem != null)
            {
                eventType = eventtypeCB.SelectedItem as EventType;
            }
            else MessageBox.Show("Выберите тип события!");

            DateTime dateTime = DateTime.Now.AddYears(100);
            if (dateTimePicker.Value.HasValue)
            {
                dateTime = dateTimePicker.Value.Value;
                if(dateTime > DateTime.Now) MessageBox.Show("Дата и время не могут быть больше текущих");
            }
            else MessageBox.Show("Укажите время события!");

            if (eventType != null && dateTime <= DateTime.Now)
            {
                database.@event eve = new @event();
                eve.EventType = eventType;
                eve.dateTime = dateTime;
                if (!string.IsNullOrWhiteSpace(descriptionTB.Text))
                {
                    eve.descriiption = descriptionTB.Text;
                }

                try
                {
                    App.db.events.Add(eve);
                    App.db.SaveChanges();
                    MessageBox.Show($"Событие {eve.EventType.nameEvent} {eve.dateTime} успешно сохранено");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else MessageBox.Show("Исправьте ошибки!");
        }
    }
}
