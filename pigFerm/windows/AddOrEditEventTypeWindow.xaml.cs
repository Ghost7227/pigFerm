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
    /// Логика взаимодействия для AddOrEditEventTypeWindow.xaml
    /// </summary>
    public partial class AddOrEditEventTypeWindow : Window
    {
        public AddOrEditEventTypeWindow()
        {
            InitializeComponent();
        }

        public AddOrEditEventTypeWindow(string target)
        {
            InitializeComponent();
            if (target == "add") { }
            else typeEvent.Visibility = Visibility.Collapsed;
        }

        private void saveTypeEventBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTB.Text))
            {
                try
                {
                    EventType eventType = new EventType();
                    eventType.nameEvent = nameTB.Text.Trim();

                    App.db.EventTypes.Add(eventType);
                    App.db.SaveChanges();

                    MessageBox.Show("Успешно добавлено");
                    Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Ошибка! Возможно, объект с таким названием уже существует");
                }
            }
            else MessageBox.Show("Заполните название!");
        }
    }
}
