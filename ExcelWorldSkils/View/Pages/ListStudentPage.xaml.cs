using ExcelWorldSkils.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelWorldSkils.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : Page
    {
        Core db = new Core();
        List<Students> arrayStudents;
        public ListStudentPage()
        {
            InitializeComponent();
            ListDataGrid.ItemsSource = db.context.Students.ToList();
            ComboBoxSort.ItemsSource = db.context.Groups.ToList();
            ComboBoxSort.DisplayMemberPath = "NameGroup";
            ComboBoxSort.SelectedValuePath = "IdGroup";
        }

        private void ComboBoxSortSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idGroup = Convert.ToInt32(ComboBoxSort.SelectedValue);
            arrayStudents = db.context.Students.Where(x => x.IdGroup == idGroup).ToList();
            ListDataGrid.ItemsSource = arrayStudents;
        }

        private void ConclusionBtnClick(object sender, RoutedEventArgs e)
        {
            Excel.Application aplication = new Excel.Application();
            aplication.Visible = true;


            /*количество листов*/

            aplication.SheetsInNewWorkbook = 1;

            /*добавляем рабочую книгу*/
            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            /*создаем лист*/
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            worksheet.StandardWidth = 20;
            worksheet.Columns.ColumnWidth = 20;

            

            worksheet.Cells[1][1] = "ФИО";
            worksheet.Cells[2][1] = "Группа";
            worksheet.Cells[3][1] = "Специальность";
            worksheet.Cells[4][1] = "Форма обучения";
            worksheet.Cells[5][1] = "Год поступления";

            

        }
    }
}
