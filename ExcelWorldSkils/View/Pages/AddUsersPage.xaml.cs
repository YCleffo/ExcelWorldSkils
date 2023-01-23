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
    /// Логика взаимодействия для AddUsersPage.xaml
    /// </summary>
    public partial class AddUsersPage : Page
    {
        Core db = new Core();
        List<Students> arrayStudents;
        public AddUsersPage()
        {
            InitializeComponent();
            arrayStudents = db.context.Students.ToList();
            GroupComboBox.ItemsSource = db.context.Groups.ToList();
            GroupComboBox.DisplayMemberPath = "NameGroup";
            GroupComboBox.SelectedValuePath = "IdGroup";
            FormTimeComboBox.ItemsSource = db.context.FormTime.ToList();
            FormTimeComboBox.DisplayMemberPath = "Name";
            FormTimeComboBox.SelectedValuePath = "Id";
            YearAddComboBox.ItemsSource = db.context.YearAdd.ToList();
            YearAddComboBox.DisplayMemberPath = "Year";
            YearAddComboBox.SelectedValuePath = "IdYear";
            ProfessionComboBox.ItemsSource = db.context.Professions.ToList();
            ProfessionComboBox.DisplayMemberPath = "NameProfession";
            ProfessionComboBox.SelectedValuePath = "IdProfession";
        }

        private void AddUsersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(LastNameTextBox.Text))
                {
                    MessageBox.Show("Вы не заполнили поля!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    int idGroup = Convert.ToInt32(GroupComboBox.SelectedValue);
                    int formTimeComboBox = Convert.ToInt32(GroupComboBox.SelectedValue);
                    int yearAddComboBox = Convert.ToInt32(GroupComboBox.SelectedValue);
                    int professionComboBox = Convert.ToInt32(GroupComboBox.SelectedValue);
                    Students newStudent = new Students()
                    {
                        LastName = LastNameTextBox.Text,
                        FiestName = FiestNameTextBox.Text,
                        PatronomicName = PatronomicTextBox.Text,
                        IdGroup = idGroup,
                        IdFormTime = formTimeComboBox,
                        IdYearAdd = yearAddComboBox,
                        IdProfession = professionComboBox
                    };

                    db.context.Students.Add(newStudent);
                    db.context.SaveChanges();

                    MessageBox.Show("Добавление выполнено успешно !",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                    this.NavigationService.Navigate(new HomeNavigatePage());
                }

            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void GroupTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idGroup = Convert.ToInt32(GroupComboBox.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idGroup).ToList();
        }

        private void FormTimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idFormTime = Convert.ToInt32(FormTimeComboBox.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idFormTime).ToList();
        }

        private void YearAddComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idYearAdd = Convert.ToInt32(YearAddComboBox.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idYearAdd).ToList();
        }

        private void ProfessionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idProfession = Convert.ToInt32(ProfessionComboBox.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idProfession).ToList();
        }
    }
}
