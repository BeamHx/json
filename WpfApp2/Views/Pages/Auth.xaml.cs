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
using WpfApp2.Model;

namespace WpfApp2.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
            LoginTextBox.Focus();
        }

        /// <summary>
        /// Нажатие левой клавиши мыши на "Зарегистрироваться"
        /// </summary>
        public void RegTextBlockMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Нажатие левой клавиши Enter на "Зарегистрироваться"
        /// </summary>
        public void RegTextBlockKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegTextBlockMouseLeftButtonDown(RegTextBlock, null);
            }
        }


        private void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginTextBox.Text;
                string password = PasswordPasswordBox.Password;
                if (login == String.Empty || password == String.Empty)
                {
                    MessageBox.Show("Вы не ввели логин или пароль!");
                }
                else
                {
                    Users result = UsersController.GetUser(login, password);
                    if (result != null)
                    {
                        App.CurrentUser = result;//сохранение информации о пользователе
                        MessageBox.Show("Вы авторизованы");
                    }
                    else
                    {
                        MessageBox.Show("Пользователь отсутствует");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
