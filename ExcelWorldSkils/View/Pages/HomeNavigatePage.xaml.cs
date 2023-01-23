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
    /// Логика взаимодействия для HomeNavigatePage.xaml
    /// </summary>
    public partial class HomeNavigatePage : Page
    {
        public HomeNavigatePage()
        {
            InitializeComponent();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddUsersPage());
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListStudent_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListStudentPage());
        }

        private void EditGrade_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeletStudent_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RemoveStudentPage());
        }
    }
}
