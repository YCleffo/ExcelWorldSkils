using ExcelWorldSkils.Model;
using ExcelWorldSkils.View.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        Students currentStudent;
        public LournalPage(Students  activeStudent)
        {
            InitializeComponent();
            arrayList = db.context.Journals.Where(x=>x.IdStudent== activeStudent.IdStudent).ToList();
            ListDataGrid.ItemsSource = arrayList;
            this.DataContext = activeStudent;
            currentStudent = activeStudent;
            EditRatingGrid.Visibility = Visibility.Collapsed;
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
                    
                    item.Evaluation = Convert.ToInt32(EditRatingTextBox.Text);
                    db.context.SaveChanges();
                    ListDataGrid.ItemsSource = db.context.Journals.Where(x => x.IdStudent == currentStudent.IdStudent).ToList(); ;
                    EditRatingGrid.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception)

            {
                MessageBox.Show("Данные не отредактированы. ");
            }
        }

        private void EditProfilButton_Click(object sender, RoutedEventArgs e)
        {
           Button activeButton= sender as Button;
            Journals activeElement = activeButton.DataContext as Journals;

            EditRatingGrid.Visibility = Visibility.Visible;
           
            EditRatingTextBox.Text = activeElement.Evaluation.ToString();
        }

        private void CloseEditRatingButton_Click(object sender, RoutedEventArgs e)
        {
            EditRatingGrid.Visibility = Visibility.Collapsed;
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            Word.Application application = new Word.Application();
            string file=$"{Directory.GetCurrentDirectory()}\\Docs\\Диплом.doc";
            if (File.Exists(file))
            {
                Word.Document doc = application.Documents.Open(file);
                doc.Activate();
                doc.Bookmarks["FIO"].Range.Text = StudentTextBlock.Text;
                doc.Bookmarks["Profession"].Range.Text = ProfessionTextBlock.Text;
                application.Visible = true;
                doc.SaveAs($"{Directory.GetCurrentDirectory()}\\Docs\\{StudentTextBlock.Text.Split()[0]}_Диплом.doc");
            }
        }
    }
}
