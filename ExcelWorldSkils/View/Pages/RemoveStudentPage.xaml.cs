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
    }
}
