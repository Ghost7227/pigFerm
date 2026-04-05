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
    /// Логика взаимодействия для AddNewGroupTypeWindow.xaml
    /// </summary>
    public partial class AddNewGroupTypeWindow : Window
    {
        public AddNewGroupTypeWindow()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTypeGroupTB.Text))
            {
                try
                {
                    groupType groupType = new groupType();
                    groupType.nameGroup = nameTypeGroupTB.Text.Trim();

                    App.db.groupTypes.Add(groupType);
                    App.db.SaveChanges();

                    MessageBox.Show($"Тип {groupType.nameGroup} добавлен");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Возможно, тип с таким названием уже существует");
                }
            }
            else MessageBox.Show("Заполните название");
        }
    }
}
