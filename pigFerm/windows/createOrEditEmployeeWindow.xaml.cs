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

        bool isCorrectLastName = false;
        bool isCorrectFirstName = false;
        bool isCorrectMidleName = false;
        bool isCorrectBirthday = false;
        bool isCorrectgender = false;


        string gender;
        public createOrEditEmployeeWindow()
        {
            InitializeComponent();
        }

        void CheckDataEmployee()
        {
            int trueCount = 0;
            if(isCorrectLastName == true) trueCount++;
            if(isCorrectFirstName == true) trueCount++;
            if (isCorrectMidleName == true) trueCount++;
            if (isCorrectBirthday == true) trueCount++;
            if (isCorrectgender == true) trueCount++;
            if (pasportTB.Text.Length == 10) trueCount++;
            if (innTB.Text.Length == 12) trueCount++;
            if (snilsTB.Text.Length == 11) trueCount++;
            if (emailRegex.IsMatch(emailTB.Text)) trueCount++;
            if (phoneTB.Text.Length == 11) trueCount++;

            MessageBox.Show(trueCount.ToString());

            if(trueCount == 10)
            {
                saveBtn.IsEnabled = true;
            }
            else
            {
                saveBtn.IsEnabled = false;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            employee employee = new employee();
            employee.firstName = firstNameTB.Text;
            employee.midleName = midleNameTB.Text;
            employee.lastName = lastNameTB.Text;
            employee.pasport = pasportTB.Text;
            employee.snils = snilsTB.Text;
            employee.phone = phoneTB.Text;
            employee.email = emailTB.Text;
            employee.inn = innTB.Text;

            if (wGenderRB.IsChecked != true && mGenderRB.IsChecked != true)
            {
                MessageBox.Show("Выберите пол!");
                return;
            }

            if (wGenderRB.IsChecked == true) employee.gender = "Ж";
            if (mGenderRB.IsChecked == true) employee.gender = "М";
            /*
            employee.birthday =(System.DateTime) bdDatePicker.SelectedDate;

            App.db.employees.Add(employee);
            App.db.SaveChanges();
            DialogResult = true;
            Close();*/
        }


        private void midleNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (regex.IsMatch(midleNameTB.Text))
            {
                midleNameTB.Background = brush;
                isCorrectMidleName = false;
            }
            else if(midleNameTB.Text != string.Empty)
            {
                midleNameTB.Background = null;
                isCorrectMidleName = true;
                CheckDataEmployee();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            midleNameTB.Text = string.Empty;
            midleNameTB.IsEnabled = false;
            isCorrectMidleName = true;
            CheckDataEmployee();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            midleNameTB.IsEnabled = true;
            isCorrectMidleName = false;
            CheckDataEmployee();
        }

        private void bdDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bdDatePicker.SelectedDate != null)
            {
                DateTime birthDate = (DateTime)bdDatePicker.SelectedDate;
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Year;

                // Если день рождения еще не наступил в этом году, вычитаем год
                if (birthDate > today.AddYears(-age))
                    age--;
                if (age < 18)
                {
                    bdDatePicker.Background = brush;
                    isCorrectBirthday = false;
                }
                else
                {
                    bdDatePicker.Background = null;
                    isCorrectBirthday = false;
                }
            }
            CheckDataEmployee();
        }

        private void mGenderRB_Checked(object sender, RoutedEventArgs e)
        {
            gender = "М";
            isCorrectgender = true;
            CheckDataEmployee();
        }

        private void wGenderRB_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Ж";
            isCorrectgender = true;
            CheckDataEmployee();
        }

        private void pasportTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TB_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void lastNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (regex.IsMatch(lastNameTB.Text))
            {
                lastNameTB.Background = brush;
                isCorrectLastName = false;
            }
            else if (lastNameTB.Text != string.Empty)
            {
                lastNameTB.Background = null;
                isCorrectLastName = true;
                CheckDataEmployee();
            }
        }

        private void firstNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (regex.IsMatch(firstNameTB.Text))
            {
                firstNameTB.Background = brush;
                isCorrectFirstName = false;
            }
            else if (firstNameTB.Text != string.Empty)
            {
                firstNameTB.Background = null;
                isCorrectFirstName = true;
                CheckDataEmployee();
            }
        }
    }
}
