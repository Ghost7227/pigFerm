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


        }
    }
}
