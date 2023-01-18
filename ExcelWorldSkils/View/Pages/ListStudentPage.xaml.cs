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
            arrayStudents = db.context.Students.ToList();
            ListDataGrid.ItemsSource = arrayStudents;
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

            //worksheet.StandardWidth = 30;
            //worksheet.Columns.ColumnWidth = 30;

            worksheet.Name = "Отчет студентов";

            int rowIndex = 2;

            worksheet.Cells[1][1] = "ФИО";
            worksheet.Cells[2][1] = "Группа";
            worksheet.Cells[3][1] = "Специальность";
            worksheet.Cells[4][1] = "Форма обучения";
            worksheet.Cells[5][1] = "Год поступления";

            int i = Convert.ToInt32(ComboBoxSort.SelectedValue);
            if (i != 0) arrayStudents = db.context.Students.Where(x => x.IdGroup == i).ToList();
            foreach (var item in arrayStudents)
            {
                worksheet.Cells[1][rowIndex] = item.FIO;
                worksheet.Cells[2][rowIndex] = item.Groups.NameGroup;
                worksheet.Cells[3][rowIndex] = item.Professions.NameProfession;
                worksheet.Cells[4][rowIndex] = item.FormTime.Name;
                worksheet.Cells[5][rowIndex] = item.YearAdd.Year;

                rowIndex++;
               
            }
            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[5][rowIndex - 1]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                 rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
            worksheet.Columns.AutoFit();
        }
    }
}
