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
        List<employee> employeesInDb = new List<employee>();
        List<employee> selectedEmployee = new List<employee>();

        List<Animal> animalsInDb = new List<Animal>();
        List<Animal> selectedAnimals = new List<Animal>();
        public AddOrEditEventWindow()
        {
            InitializeComponent();
        }

        void LoadEmployees()
        {
            employeeLV.ItemsSource = null;
            employeeLV.ItemsSource  = employeesInDb;
            selectedEmployeeLV.ItemsSource = null;
            selectedEmployeeLV.ItemsSource = selectedEmployee;
        }

        void LoadAnimals()
        {
            animalsLV.ItemsSource = null;
            animalsLV.ItemsSource = animalsInDb;
            selectedAnimalsLV.ItemsSource = null;
            selectedAnimalsLV.ItemsSource = selectedAnimals;
        }

        void LoadData()
        {
            eventtypeCB.ItemsSource = App.db.EventTypes.ToList();
            employeesInDb = App.db.employees.ToList();
            animalsInDb = App.db.Animals.Where(a => a.status == "Активный").ToList();
        }

        public AddOrEditEventWindow(string target)
        {
            InitializeComponent();
            LoadData();
            LoadEmployees();
            LoadAnimals();
        }

        public AddOrEditEventWindow(@event ev)
        {
            InitializeComponent();
            LoadData();
            if (ev  != null)
            {
                eventtypeCB.SelectedItem = ev.EventType;
                dateTimePicker.Value = ev.dateTime;
                selectedAnimals = ev.Animals.ToList();

                foreach (var evEm in ev.EventEmployees)
                {
                    selectedEmployee.Add(evEm.employee);
                }
                descriptionTB.Text = ev.descriiption;
            }
            LoadEmployees();
            LoadAnimals();
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

            if (eventType != null && dateTime <= DateTime.Now && selectedEmployee.Count > 0)
            {
                database.@event eve = new @event();
                eve.EventType = eventType;
                eve.dateTime = dateTime;
                if (!string.IsNullOrWhiteSpace(descriptionTB.Text))
                {
                    eve.descriiption = descriptionTB.Text;
                }

                if (selectedAnimals.Count > 0)
                {
                    foreach (var item in selectedAnimals)
                    {
                        eve.Animals.Add(item);
                    }
                }

                try
                {
                    App.db.events.Add(eve);
                    App.db.SaveChanges();

                    foreach (var item in selectedEmployee)
                    {
                        EventEmployee eventEmployee = new EventEmployee();
                        eventEmployee.@event = eve;
                        eventEmployee.employee = item;
                        eventEmployee.description = item.descriptionEventEmployee;

                        App.db.EventEmployees.Add(eventEmployee);
                        App.db.SaveChanges();
                    }

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

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            employee employee = employeeLV.SelectedItem as employee;
            if (employee != null)
            {
                selectedEmployee.Add(employee);
                employeesInDb.Remove(employee);
                LoadEmployees();
            }
        }
        private void selectedEmployeeListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            employee employee = selectedEmployeeLV.SelectedItem as employee;
            if (employee != null)
            {
                employee.descriptionEventEmployee = "";
                employeesInDb.Add(employee);
                selectedEmployee.Remove(employee);
                LoadEmployees();
            }
        }

        private void descriptionTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;

            employee employee = employeeLV.SelectedItem as employee;
            if(employee != null)
            {
                employee.descriptionEventEmployee = text.Trim();
            }
        }

        private void animalsLVItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Animal animal = animalsLV.SelectedItem as Animal;
            if(animal != null)
            {
                selectedAnimals.Add(animal);
                animalsInDb.Remove(animal);
                LoadAnimals();
            }
        }

        private void selectedAnimalsLVItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Animal animal = animalsLV.SelectedItem as Animal;
            if (animal != null)
            {
                animalsInDb.Add(animal);
                selectedAnimals.Remove(animal);
                LoadAnimals();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
