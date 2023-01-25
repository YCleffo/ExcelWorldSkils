using ExcelWorldSkils.View.Model;
using ExcelWorldSkils.View.Pages;
using ExcelWorldSkils.ViewModel;
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

namespace ExcelWorldSkils.Model.Frame
{
    /// <summary>
    /// Логика взаимодействия для autchPage.xaml
    /// </summary>
    public partial class AutchPage : Page
    {
        Core db = new Core();
        public AutchPage()
        {
            InitializeComponent();

        }



        private void AutchBtnClick(object sender, RoutedEventArgs e)
        {
            try

            {

                //считаем количество записей в таблице с заданными параметрами (логин, пароль)
                Users autch = db.context.Users.Where(
                x => x.Login == LogInTextBox.Text && x.Password == PasswordTextBox.Text
                ).FirstOrDefault();

                if (autch == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                }
                else

                {
                    App.CurrentUser = autch;
                   
                    switch (autch.IdRole)
                    {

                        case 1:
                            this.NavigationService.Navigate(new StudentPage());

                            break;
                        case 2:
                            this.NavigationService.Navigate(new HomeNavigatePage());
                          
                            break;

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(),
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(LogInTextBox.Text))
                {
                    MessageBox.Show("Вы не заполнили поля!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    if (UsersViewModel.AddUser(LogInTextBox.Text, PasswordTextBox.Text) == false)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Добавление выполнено успешно !",
                  "Уведомление",
                  MessageBoxButton.OK,
                  MessageBoxImage.Information);
                        this.NavigationService.Navigate(new HomeNavigatePage());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Критический сбор в работе приложения:", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
