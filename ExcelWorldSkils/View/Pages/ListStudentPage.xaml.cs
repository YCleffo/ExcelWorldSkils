using ExcelWorldSkils.View.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

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

        private void ConclBtnWordClick(object sender, RoutedEventArgs e)
        {
            //Word.Application application = new Word.Application();
            //Word.Document document = application.Documents.Add();
            //application.Visible = true;
            //Word.Paragraph titleParagraph = document.Paragraphs.Add();
            //Word.Range titleRange = titleParagraph.Range;
            //titleRange.Text = "ВЕДОМОСТЬ итоговой аттестации";
            ////Выравнивание
            //titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            ////жирность
            //titleRange.Font.Bold = 1;
            ////ПЕРЕНОС СТРОКИ
            //titleRange.InsertParagraphAfter();
            ////Таблица
            //Word.Paragraph tableParagraph = document.Paragraphs.Add();
            //Word.Range tableRange = tableParagraph.Range;
            //Word.Table titleTable = document.Tables.Add(tableRange,1,3);
            //Word.Range cellRange;
            //cellRange = titleTable.Cell(1, 1).Range;
            //cellRange.Text = "«____» ____________ 20__г. ";
            //cellRange = titleTable.Cell(1, 3).Range;
            //cellRange.Text = "№________________";
            //application.Visible = true;

            int i = Convert.ToInt32(ComboBoxSort.SelectedValue);
            if (i != 0) arrayStudents = db.context.Students.Where(x => x.IdGroup == i).ToList();
            Word.Application application = new Word.Application();
            Word.Document wordDock = application.Documents.Add();
            Word.Paragraph titleParagraph = wordDock.Paragraphs.Add();
            Word.Range titleRange = titleParagraph.Range;
            titleRange.Text = "МИНИСТЕРСТВО ОБРАЗОВАНИЯ И МОЛОДЕЖНОЙ ПОЛИТИКИ СВЕРДЛОВСКОЙ ОБЛАСТИ";
            titleRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "ГОСУДАРСТВЕННОЕ АВТОНОМНОЕ ПРОФЕССИОНАЛЬНОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "СВЕРДЛОВСКОЙ ОБЛАСТИ";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "«ЕКАТЕРИНБУРГСКИЙ МОНТАЖНЫЙ КОЛЛЕДЖ»";
            titleRange.Bold = 1;
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "ВЕДОМОСТЬ";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            titleRange.Text = "итоговой аттестации";
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            Word.Paragraph tableParagraph = wordDock.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table titleTable = wordDock.Tables.Add(tableRange, 1, 2);
            Word.Range cellRange;
            cellRange = titleTable.Cell(1, 1).Range;
            cellRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellRange.Text = "«_____» _________ 20_____ Г.";
            cellRange = titleTable.Cell(1, 2).Range;
            cellRange.Text = "№_____________";
            cellRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            titleRange.InsertParagraphAfter();
            titleRange.Bold = 0;
            titleRange = titleParagraph.Range;
            titleRange.Text = $"Группа №: {ComboBoxSort.Text}";
            titleRange.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            titleRange.InsertParagraphAfter();
            titleRange = titleParagraph.Range;
            //titleRange.Text = $"Преподаватель: {App.LogIn.Login}";
            titleRange.InsertParagraphAfter();
            Word.Paragraph tableSParagraph = wordDock.Paragraphs.Add();
            Word.Range tableSRange = tableParagraph.Range;
            Word.Table titleSTable = wordDock.Tables.Add(tableSRange, arrayStudents.Count + 1, 3);
            Word.Range cellSRange;
            cellSRange = titleSTable.Cell(1, 1).Range;
            cellSRange.Text = "№ п/п";
            cellSRange = titleSTable.Cell(1, 2).Range;
            cellSRange.Text = "ФИО";
            cellSRange = titleSTable.Cell(1, 3).Range;
            cellSRange.Text = "Аттестация";
            int rowIndex = 2;
            foreach (var item in arrayStudents)
            {
                cellSRange = titleSTable.Cell(rowIndex, 1).Range;

                cellSRange.Text = Convert.ToString(rowIndex - 1);

                cellSRange = titleSTable.Cell(rowIndex, 2).Range;

                cellSRange.Text = item.FiestName + " " + item.LastName + " " + item.PatronomicName;

                cellSRange = titleSTable.Cell(rowIndex, 3).Range;

                cellSRange.Text = "";

                rowIndex++;
            }
            titleSTable.Borders.InsideLineStyle = titleSTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            application.Visible = true;
            //wordDock.SaveAs2($"{Directory.GetCurrentDirectory()}\\docs\\Test.docx");
            //wordDock.SaveAs2($"{Directory.GetCurrentDirectory()}\\docs\\Test.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }
    }
}
