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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace ExcelWorldSkils.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для LournalPage.xaml
    /// </summary>
    public partial class LournalPage : Page
    {
        Core db = new Core();
        List<Journals> arrayList;
        public LournalPage(Students  activeStudent)
        {
            InitializeComponent();
            arrayList = db.context.Journals.Where(x=>x.IdStudent== activeStudent.IdStudent).ToList();
            ListDataGrid.ItemsSource = arrayList;
            this.DataContext = activeStudent;
        }

        private void EditRatingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var item = ListDataGrid.SelectedItem as Journals;

                //проверка того, что пользователь выбрал строки для удаления

                if (item == null)

                {

                    MessageBox.Show("Вы не выбрали ни одной строки");

                    return;

                }

                else
                {
                    
                    item.Evaluation = 5;
                    db.context.SaveChanges();
                }
            }
            catch (Exception)

            {
                MessageBox.Show("Данные не отредактированы. ");
            }
        }

        private void EditProfilButton_Click(object sender, RoutedEventArgs e)
        {
            EditRatingGrid.Visibility = Visibility.Visible;
        }

        private void CloseEditRatingButton_Click(object sender, RoutedEventArgs e)
        {
            EditRatingGrid.Visibility = Visibility.Collapsed;
        }
    }
}
