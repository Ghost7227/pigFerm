using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для createOrEditEmployeeWindow.xaml
    /// </summary>
    public partial class createOrEditEmployeeWindow : Window
    {
        Regex regex = new Regex(@"[^а-яА-ЯёЁ]");
        Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 75, 88));
        SolidColorBrush borderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));


        bool existMidlename = true;

        public createOrEditEmployeeWindow()
        {
            InitializeComponent();
            postCB.ItemsSource = App.db.posts.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string lastName = "";
            if (!string.IsNullOrWhiteSpace(lastNameTB.Text))
            {
                lastNameTB.Background = null;
                lastName = lastNameTB.Text.Trim();
            }
            else lastNameTB.Background = brush;

            string firstname = "";
            if (!string.IsNullOrWhiteSpace(firstNameTB.Text))
            {
                firstNameTB.Background = null;
                firstname = firstNameTB.Text.Trim();
            }
            else firstNameTB.Background = brush;

            string midlename = "";
            if (!string.IsNullOrWhiteSpace(midleNameTB.Text) && existMidlename == true)
            {
                midleNameTB.Background = null;
                midlename = midleNameTB.Text.Trim();
            }
            else if (existMidlename == false) midleNameTB.Background = null;
            else midleNameTB.Background = brush;

            DateTime today = DateTime.Today;
            DateTime birthDate = today.AddYears(100);
            if (bdDatePicker.SelectedDate != null)
            {
                birthDate = (DateTime)bdDatePicker.SelectedDate;
                today = DateTime.Today;
                int age = today.Year - birthDate.Year;
                bdDatePicker.Background = null;

                // Если день рождения еще не наступил в этом году, вычитаем год
                if (birthDate > today.AddYears(-age)) age--;

                if (age < 18) bdDatePicker.Background = brush;
                else bdDatePicker.Background = null;
            }
            else bdDatePicker.Background = brush;

            string gender = "";
            if (wGenderRB.IsChecked == true) gender = "Ж";
            else if (mGenderRB.IsChecked == true) gender = "М";
            else MessageBox.Show("Выберите пол!");

            string passport = "";
            if (!string.IsNullOrWhiteSpace(pasportTB.Text) && pasportTB.Text.Length == 10)
            {
                passport = pasportTB.Text;
                pasportTB.Background = null;
            }
            else pasportTB.Background = brush;

            string snils = "";
            if (!string.IsNullOrWhiteSpace(pasportTB.Text) && snilsTB.Text.Length == 11)
            {
                snils = snilsTB.Text;
                snilsTB.Background = null;
            }
            else snilsTB.Background = brush;

            string inn = "";
            if (!string.IsNullOrWhiteSpace(pasportTB.Text) && innTB.Text.Length == 12)
            {
                inn = innTB.Text;
                innTB.Background = null;
            }
            else innTB.Background = brush;

            string email = "";
            if (emailRegex.IsMatch(emailTB.Text))
            {
                email = emailTB.Text.Trim();
                emailTB.Background = null;
            }
            else if(emailTB.Text == string.Empty) emailTB.Background = null;
            else emailTB.Background = brush;

            string phone = "";
            if (!string.IsNullOrWhiteSpace(phoneTB.Text) && phoneTB.Text.Length == 11 && phoneTB.Text.StartsWith("8"))
            {
                phone = phoneTB.Text;
                phoneTB.Background = null;
            }
            else phoneTB.Background = brush;

            post post = null;
            if(postCB.SelectedItem != null)
            {
                post = postCB.SelectedItem as post;
                postCB.Background = null;
            }
            else postCB.Background = brush;

            if (lastName != "" && firstname != "" && (midlename != "" || existMidlename == false) && birthDate != today.AddYears(100) && gender != "" &&
                passport != "" && snils != "" && inn != "" && phone != "" && post != null)
            {
                try
                {
                    employee employee = new employee();
                    employee.firstName = firstname;
                    employee.midleName = midlename;
                    employee.lastName = lastName;
                    employee.gender = gender;
                    employee.pasport = passport;
                    employee.snils = snils;
                    employee.phone = phone;
                    employee.email = email;
                    employee.inn = inn;
                    employee.birthday = birthDate;
                    employee.post = post;

                    App.db.employees.Add(employee);
                    App.db.SaveChanges();
                    MessageBox.Show($"Сотрудник {lastName} {midlename} {firstname} успешно добавлен!");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            else MessageBox.Show("Исправьте ошибки!");
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            midleNameTB.Text = string.Empty;
            midleNameTB.IsEnabled = false;
            existMidlename = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            midleNameTB.IsEnabled = true;
            existMidlename = true;
        }

        private void digit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void digit_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
