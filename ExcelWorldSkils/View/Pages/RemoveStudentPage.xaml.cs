using ExcelWorldSkils.Model;
using ExcelWorldSkils.View.Model;
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

namespace ExcelWorldSkils.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RemoveStudentPage.xaml
    /// </summary>
    public partial class RemoveStudentPage : Page
    {
        Core db = new Core();
        List<Students> arrayStudents;
        public RemoveStudentPage()
        {
            InitializeComponent();
            arrayStudents = db.context.Students.ToList();
            ListDataGrid.ItemsSource = arrayStudents;
            SelectStudentComboBox.ItemsSource = db.context.Groups.ToList();
            SelectStudentComboBox.DisplayMemberPath = "NameGroup";
            SelectStudentComboBox.SelectedValuePath = "IdGroup";
        }

        private void SelectStudentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idGroup = Convert.ToInt32(SelectStudentComboBox.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idGroup).ToList();
            ListDataGrid.ItemsSource = arrayStudents;
        }

        private void RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var item = ListDataGrid.SelectedItem as Students;

                //проверка того, что пользователь выбрал строки для удаления

                if (item == null)
                {
                    MessageBox.Show("Вы не выбрали ни одной строки");
                    return;
                }
                else
                {
                    //выполним удаление только в том случае, если пользователь даст согласие на удаление
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        //удаляем выбранную строку
                        db.context.Students.Remove(item);
                        db.context.SaveChanges();
                        MessageBox.Show("Информация удалена");
                        //обновление DataGrid
                        ListDataGrid.ItemsSource = db.context.Students.ToList();
                    }
                }
        }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
}
    }
}
