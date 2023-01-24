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
    /// Логика взаимодействия для AddEstimatesPage.xaml
    /// </summary>
    public partial class AddEstimatesPage : Page

    {
        Core db = new Core();
        List<Students> arrayStudents;
        public AddEstimatesPage()
        {
            InitializeComponent();
            arrayStudents = db.context.Students.ToList();
            GroupComboBox.ItemsSource = db.context.Groups.ToList();
            GroupComboBox.DisplayMemberPath = "NameGroup";
            GroupComboBox.SelectedValuePath = "IdGroup";
            ProfessionComboBox.ItemsSource = db.context.Professions.ToList();
            ProfessionComboBox.DisplayMemberPath = "NameProfession";
            ProfessionComboBox.SelectedValuePath = "IdProfession";
            StudentComboBox.ItemsSource = db.context.Students.ToList();
            StudentComboBox.DisplayMemberPath = "FiestName";
            StudentComboBox.SelectedValuePath = "IdStudent";
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idGroup = Convert.ToInt32(GroupComboBox.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idGroup).ToList();
            StudentComboBox.IsEnabled = true;
            StudentComboBox.ItemsSource = arrayStudents;

        }

        private void ProfessionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idProfession = Convert.ToInt32(ProfessionComboBox.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idProfession).ToList();
        }

        private void StudentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IdStudent = Convert.ToInt32(StudentComboBox.SelectedValue);
        }

        private void AddEstimates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(EstimatesTexBox.Text))
                {
                    MessageBox.Show("Вы не заполнили поля!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    int idGroup = Convert.ToInt32(GroupComboBox.SelectedValue);
                    int student = Convert.ToInt32(StudentComboBox.SelectedValue);
                    int professionComboBox = Convert.ToInt32(ProfessionComboBox.SelectedValue);
                    Journals newEstimates = new Journals()
                    {
                        IdGroup = idGroup,
                        IdStudent = student,
                        IdSubject = professionComboBox,
                        Evaluation = Convert.ToInt32(EstimatesTexBox.Text)
                    };

                    db.context.Journals.Add(newEstimates);
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
    }
}
