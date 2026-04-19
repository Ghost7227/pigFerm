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

namespace pigFerm.viewWindows
{
    /// <summary>
    /// Логика взаимодействия для EventViewWindow.xaml
    /// </summary>
    public partial class EventViewWindow : Window
    {
        public EventViewWindow()
        {
            InitializeComponent();
        }
        public EventViewWindow(@event ev)
        {
            InitializeComponent();
            titleTB.Text = ev.typeAndDateEvent;
            eventtypeTB.Text = ev.EventType.nameEvent;
            datetimeTB.Text = ev.dateTime.ToString("dd.MM.yyyy HH:mm");

            foreach (var evEm in ev.EventEmployees) 
            {
                selectedEmployeeLV.Items.Add(evEm.employee);
            }

            selectedAnimalsLV.ItemsSource = ev.Animals;
            descriptionTB.Text = ev.descriiption;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
