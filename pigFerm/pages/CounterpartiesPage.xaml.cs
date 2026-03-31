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
    /// Логика взаимодействия для CounterpartiesPage.xaml
    /// </summary>
    public partial class CounterpartiesPage : Page
    {
        public CounterpartiesPage()
        {
            InitializeComponent();
            LoadData();
        }
        
        void LoadData()
        {
            counterpartyLV.ItemsSource = App.db.counterparties.ToList();
        }

        private void addNewConterpartyBtn_Click(object sender, RoutedEventArgs e)
        {
            string add = "add";
            AddOrEditCounterpartyWindow addOrEditCounterpartyWindow = new AddOrEditCounterpartyWindow(add);
            addOrEditCounterpartyWindow.ShowDialog();
            LoadData();
        }
    }
}
