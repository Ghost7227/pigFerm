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

namespace pigFerm.windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewPostWindow.xaml
    /// </summary>
    public partial class AddNewPostWindow : Window
    {
        public AddNewPostWindow()
        {
            InitializeComponent();
            departamentCB.ItemsSource = App.db.departments.ToList();
        }

        private void savePostBtn_Click(object sender, RoutedEventArgs e)
        {
            department department = null;
            if (departamentCB.SelectedItem != null)
            {
                department = (department)departamentCB.SelectedItem;
            }
            else MessageBox.Show("Выберите отдел!");

            string namePost = string.Empty;
            if(nameTB.Text != string.Empty && nameTB.Text.Length > 3)
            {
                namePost = nameTB.Text.Trim();
            }
            else MessageBox.Show("Название должно содержать не менее 4 символов!");

            int salary = -1;
            int parse = 0;
            if (salaryTB.Text != string.Empty && int.TryParse(salaryTB.Text, out parse))
            {
                if (parse >= 0) salary = parse;
                else MessageBox.Show("Зарплата должна быть больше 0!");
            }
            else MessageBox.Show("Не удалось получить число!");

            if (departamentCB.SelectedItem != null && namePost != string.Empty && salary != -1)
            {
                post post = new post();
                post.namePost = namePost;
                post.salary = salary;
                post.department = department;

                try
                {
                    App.db.posts.Add(post);
                    App.db.SaveChanges();
                    MessageBox.Show("УспешноДобавлено");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при сохранении! Возможно, такая должность уже существует.");
                }
            }
            else MessageBox.Show("Исправьте ошибки!");
        }

        private void salaryTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void salaryTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
