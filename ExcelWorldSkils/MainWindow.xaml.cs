
using ExcelWorldSkils.Model.Frame;
using ExcelWorldSkils.View.Model;
using ExcelWorldSkils.View.Pages;
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

namespace ExcelWorldSkils
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core db = new Core();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AutchPage());
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (App.CurrentUser!=null && App.CurrentUser.IdRole!=1)
            {
                UserTextBlock.Text = db.context.Teachers.FirstOrDefault(x => x.UserId == App.CurrentUser.IdUser).TeacherName;
            }
           
        }
    }
}
