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
using static E_library1._1.Project_Link.Frame_link;
using static E_library1._1.Project_Link.Page_link;
using static E_library1._1.Project_Link.Entities_link;
using static E_library1._1.Project_Link.id;

namespace E_library1._1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_authorization.xaml
    /// </summary>
    public partial class Page_authorization : Page
    {
        public Page_authorization()
        {
            InitializeComponent();
            _passpass.Visibility = Visibility.Visible;
            _passtext.Visibility = Visibility.Hidden;
        }
        //Скрытие и раскрытие пароля
        private void _checkpassword_Click(object sender, RoutedEventArgs e)
        {
            if (_checkpassword.IsChecked == true)
            {
                _passpass.Visibility = Visibility.Hidden;
                _passtext.Visibility = Visibility.Visible;
                _passtext.Text = _passpass.Password;

            }
            else
            {
                _passtext.Visibility = Visibility.Hidden;
                _passpass.Visibility = Visibility.Visible;
                _passpass.Password = _passtext.Text;
            }
        }
        private void _autoenter_Click(object sender, RoutedEventArgs e)
        {
            if (_checkpassword.IsChecked == true)
            {
                //Создаётся файл автоматического входа
            }
            else
            {
                //Ничего не создаётся, чисто ручной вход
            }
        }
        //Регистрация
        private void _registration_Click(object sender, RoutedEventArgs e)
        {
            _login.Text = String.Empty;
            _passpass.Password = String.Empty;
            _passtext.Text = String.Empty;
            frame_link.Navigate(registration);
        }
        //Авторизация
        private void _enter_Click(object sender, RoutedEventArgs e)
        {
            var count = context.Userdb.Where(i => i.Telephone == _login.Text || i.Email == _login.Text && i.Password == _passpass.Password).FirstOrDefault();
            var count2 = context.User_List_View.Where(i => i.Telephone == _login.Text || i.Email == _login.Text && i.Password == _passpass.Password).FirstOrDefault();
            if (count != null)
            {
                //Заполнение страница данными пользователя (Личныйкабинет)
                profile._fio.Text = count2.FIO_USER;
                profile._telephone.Text = count2.Telephone;
                profile._email.Text = count2.Email;
                profile._gender.Text = count2.Gender;
                profile._birthday.Text = count2.Birthday.ToString();
                profile._role.Text = count2.NameRole;
                profile._classs.Text = count2.Class;
                //Подкачка данных для библиотеки пользователя и общей библиотеки
                libraryuser._listview.ItemsSource = context.Catalog_Library_User.Where(i => i.idUser == count2.idUser).ToList();
                generallibrary._listview.ItemsSource = context.Catalog_Library_App.ToList();
                viewuser._listview.ItemsSource = context.User_List_View.ToList();
                //Меню администратора
                switch (count.idRole)
                {
                    case 1:
                        mainmenu._operation.Visibility = Visibility.Collapsed;
                        profile._class.Visibility = Visibility.Visible;
                        break;
                    case 2:
                    mainmenu._operation.Visibility = Visibility.Visible;
                    profile._class.Visibility = Visibility.Collapsed;
                        break;
                    case 3:
                        mainmenu._operation.Visibility = Visibility.Collapsed;
                        profile._class.Visibility = Visibility.Collapsed;
                        break;
                    case 4:
                        mainmenu._operation.Visibility = Visibility.Collapsed;
                        profile._class.Visibility = Visibility.Collapsed;
                        break;
                    default:
                        break;
                }
                //Стерание информации и переход в систему
                _login.Text = String.Empty;
                _passpass.Password = String.Empty;
                _passtext.Text = String.Empty;
                frame_link.Navigate(mainmenu);
                frame_operation.Navigate(profile);
            }
            else
            {
                var message = MessageBox.Show("Данного пользователя не существует", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                _login.Focus();
                _login.Clear();
                _passpass.Clear();
                _passtext.Clear();
            }
        }

        private void _exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
