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
using E_library1._1.Entities;

namespace E_library1._1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_registration.xaml
    /// </summary>
    public partial class Page_registration : Page
    {
        public bool next = false, num, space;
        int markclass;
        public List<Role> roles = context.Role.ToList();
        public Page_registration()
        {
            InitializeComponent();
            _datebirthday.SelectedDate = DateTime.UtcNow;
            //Список Gender
            List<Gender> genders = context.Gender.ToList();
            genders.Insert(0, new Gender() { Gender1 = "Все" });
            _gender.ItemsSource = genders;
            _gender.DisplayMemberPath = "Gender1";
            _gender.SelectedIndex = 0;
            //Список Role
            List<Role> roles = context.Role.ToList();
            roles.RemoveAt(1);
            //roles.Remove(new Role() {idRole = 2, NameRole = "Администратор" });
            roles.Insert(0, new Role() { NameRole = "Все роли" });
            _role.ItemsSource = roles;
            _role.DisplayMemberPath = "NameRole";
            _role.SelectedIndex = 0;
            //Список классов
            List<Class_reg> regs = context.Class_reg.ToList();
            regs.Insert(0, new Class_reg() { Class = "Класс" });
            _class.ItemsSource = regs;
            _class.DisplayMemberPath = "Class";
            _class.SelectedIndex = 0;
        }

        private void _exitreg_Click(object sender, RoutedEventArgs e)
        {
            //String
            _lastname.Text = String.Empty;
            _firstname.Text = String.Empty;
            _patronicym.Text = String.Empty;
            _email.Text = String.Empty;
            _telephone.Text = String.Empty;
            _password.Password = String.Empty;
            _returnpassword.Password = String.Empty;
            //DATE
            _datebirthday.SelectedDate = DateTime.UtcNow;
            //INT
            _gender.SelectedIndex = 0;
            _role.SelectedIndex = 0;
            _class.Visibility = Visibility.Hidden;
            _class.SelectedIndex = 0;
            frame_link.Navigate(authorization);
        }

        private void _newuser_Click(object sender, RoutedEventArgs e)
        {
            CheckLastName();
            if (next == true)
            {
                CheckFirstName();
                if (next == true)
                {
                    CheckPatronicym();
                    if (next == true)
                    {
                        CheckEmail();
                        if (next == true)
                        {
                            CheckTelephone();
                            if (next == true)
                            {
                                CheckPassword();
                                if (next == true)
                                {
                                    ChekGender();
                                    if (next == true)
                                    {
                                        CheckDate();
                                        {
                                            if (next == true)
                                            {
                                                CheckRole();
                                                if (next == true)
                                                {
                                                    CheckClass();
                                                    if (next == true)
                                                    {
                                                        int? check;
                                                        if (_class.SelectedIndex == 0)
                                                        {
                                                            check = null;
                                                        }
                                                        else
                                                        {
                                                            check = _class.SelectedIndex;
                                                        }
                                                        context.Userdb.Add(new Userdb
                                                        {
                                                            FirstName = _firstname.Text,
                                                            LastName = _lastname.Text,
                                                            Patronicym = _patronicym.Text,
                                                            Email = _email.Text,
                                                            Telephone = _telephone.Text,
                                                            Birthday = _datebirthday.DisplayDate,
                                                            idRole = markclass,
                                                            idClass = check,
                                                            Password = _password.Password,
                                                            idGender = _gender.SelectedIndex,
                                                            CheckUser = false
                                                        });
                                                        context.SaveChanges();
                                                        var message = MessageBox.Show("Регистрация прошла успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                                        if (message == MessageBoxResult.OK)
                                                        {
                                                            //String
                                                            _lastname.Text = String.Empty;
                                                            _firstname.Text = String.Empty;
                                                            _patronicym.Text = String.Empty;
                                                            _email.Text = String.Empty;
                                                            _telephone.Text = String.Empty;
                                                            _password.Password = String.Empty;
                                                            _returnpassword.Password = String.Empty;
                                                            //DATE
                                                            _datebirthday.SelectedDate = DateTime.UtcNow;
                                                            //INT
                                                            _gender.SelectedIndex = 0;
                                                            _role.SelectedIndex = 0;
                                                            _class.Visibility = Visibility.Hidden;
                                                            _class.SelectedIndex = 0;
                                                            frame_link.Navigate(authorization);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        void CheckClass()
        {
            switch (_role.SelectedIndex)
            {
                case 1:
                    //Ученик
                    if (_class.SelectedIndex != 0)
                    {
                        next = true;
                    }
                    else
                    {
                        var message = MessageBox.Show("Выберете класс", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (message == MessageBoxResult.OK)
                        {
                            next = false;
                            _class.SelectedIndex = 0;
                            _class.Focus();
                        }
                    }
                    break;
                case 2:
                    //Учитель
                    _class.SelectedIndex = 0;
                        next = true;
                    break;
                default:
                    //Гость
                    _class.SelectedIndex = 0;
                    next = true;
                    break;
            }
        }
        void CheckRole()
        {
                switch (_role.SelectedIndex)
                {
                    //Ученик
                    case 1:
                        markclass = 1;
                            break;
                    //Преподаватель
                    case 2:
                        markclass = 3;
                            break;
                    //Гость
                    case 3:
                        markclass = 4;
                            break;
                    default:
                        var message = MessageBox.Show("Выберете должность", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                            if (message == MessageBoxResult.OK)
                            {
                            next = false;
                            _role.SelectedIndex = 0;
                            _role.Focus();
                            }
                        break;
                }
        }
        void CheckDate()
        {
            if (_datebirthday.SelectedDate != DateTime.Now)
            {
                next = true;
            }
            else
            {
                var message = MessageBox.Show("Выберете дату", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _datebirthday.SelectedDate = DateTime.UtcNow;
                    _datebirthday.Focus();
                }
            }
        }
        void ChekGender()
        {
            if (_gender.SelectedIndex != 0)
            {
                next = true;
            }
            else
            {
                var message = MessageBox.Show("Выберете пол", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _gender.SelectedIndex = 0;
                    _gender.Focus();
                }
            }
        }
        void CheckPassword()
        {
            if (_password.Password != String.Empty)
            {
                if (_returnpassword.Password != String.Empty)
                {
                    if (_password.Password == _returnpassword.Password)
                    {
                        next = true;
                    }
                    else
                    {
                        var message = MessageBox.Show("Пароли должны быть одинаковые", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (message == MessageBoxResult.OK)
                        {
                            next = false;
                            _password.Clear();
                            _returnpassword.Clear();
                            _password.Focus();
                        }
                    }
                }
                else
                {
                    var message = MessageBox.Show("Поле не должно быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (message == MessageBoxResult.OK)
                    {
                        next = false;
                        _returnpassword.Clear();
                        _returnpassword.Focus();
                    }
                }
            }
            else
            {
                var message = MessageBox.Show("Поле не должно быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _password.Clear();
                    _password.Focus();
                }
            }
           
        }
        void CheckEmail()
        {
            if (_email.Text != "")
            {
                CheckSpace(_email.Text);
                if (space == true)
                {
                    next = true;
                }
                else
                {
                    var message = MessageBox.Show("Поле не должно содержать пробелы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (message == MessageBoxResult.OK)
                    {
                        next = false;
                        _email.Clear();
                        _email.Focus();
                    }
                }
            }
            else
            {
                var message = MessageBox.Show("Поле не должно быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _email.Focus();
                }

            }
        }
        void CheckTelephone()
        {
            CheckSpace(_telephone.Text);
            if (space == true)
            {
                CheckNumeral(_telephone.Text);
                if (num == false)
                {
                    next = true;
                }
                else
                {
                    var message = MessageBox.Show("Поле не должно содержать буквы или иные символы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (message == MessageBoxResult.OK)
                    {
                        next = true;
                        _telephone.Clear();
                        _telephone.Focus();
                    }
                }
            }
            else
            {
                var message = MessageBox.Show("Поле не должно содержать пробелы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _telephone.Clear();
                    _telephone.Focus();
                }
            }
        }
        void CheckPatronicym()
        {
            if (_patronicym.Text != "")
            {
                CheckSpace(_patronicym.Text);
                if (space == true)
                {
                    CheckNumeral(_patronicym.Text);
                    if (num == true)
                    {
                        next = true;
                    }
                    else
                    {
                        var message = MessageBox.Show("Поле не должно содержать цифры", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (message == MessageBoxResult.OK)
                        {
                            next = false;
                            _patronicym.Clear();
                            _patronicym.Focus();
                        }
                    }
                }
                else
                {
                    var message = MessageBox.Show("Поле не должно содержать пробелы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (message == MessageBoxResult.OK)
                    {
                        next = false;
                        _patronicym.Clear();
                        _patronicym.Focus();
                    }
                }
            }
            else
            {
                var message = MessageBox.Show("Поле не должно быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _patronicym.Focus();
                }
            }
        }
        void CheckFirstName()
        {
            if (_firstname.Text != "")
            {
                CheckSpace(_firstname.Text);
                if (space == true)
                {
                    CheckNumeral(_firstname.Text);
                    if (num == true)
                    {
                        next = true;
                    }
                    else
                    {
                        var message = MessageBox.Show("Поле не должно содержать цифры", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (message == MessageBoxResult.OK)
                        {
                            next = false;
                            _firstname.Clear();
                            _firstname.Focus();
                        }
                    }
                }
                else
                {
                    var message = MessageBox.Show("Поле не должно содержать пробелы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (message == MessageBoxResult.OK)
                    {
                        next = false;
                        _firstname.Clear();
                        _firstname.Focus();
                    }
                }
            }
            else
            {
                var message = MessageBox.Show("Поле не должно быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _firstname.Focus();
                }
            }
        }
        void CheckLastName()
        {
            if (_lastname.Text != "")
            {
                CheckSpace(_lastname.Text);
                if (space == true)
                {
                    CheckNumeral(_lastname.Text);
                    if (num == true)
                    {
                        next = true;
                    }
                    else
                    {
                        var message = MessageBox.Show("Поле не должно содержать цифры", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (message == MessageBoxResult.OK)
                        {
                            next = false;
                            _lastname.Clear();
                            _lastname.Focus();
                        }
                    }
                }
                else
                {
                    var message = MessageBox.Show("Поле не должно содержать пробелы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (message == MessageBoxResult.OK)
                    {
                        next = false;
                        _lastname.Clear();
                        _lastname.Focus();
                    }
                }
            }
            else
            {
                var message = MessageBox.Show("Поле не должно быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                if (message == MessageBoxResult.OK)
                {
                    next = false;
                    _lastname.Focus();
                }
            }
        }

        private void _role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (_role.SelectedIndex)
            {
                case 0:
                    _class.SelectedIndex = 0;
                    _class.Visibility = Visibility.Hidden;
                    _classtxt.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    _class.SelectedIndex = 0;
                    _class.Visibility = Visibility.Visible;
                    _classtxt.Visibility = Visibility.Visible;
                    break;
                case 2:
                    _class.SelectedIndex = 0;
                    _class.Visibility = Visibility.Hidden;
                    _classtxt.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    _class.SelectedIndex = 0;
                    _class.Visibility = Visibility.Hidden;
                    _classtxt.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        //Проверка на пробелы
        public void CheckSpace(string Space)
        {
            for (int i = 0; i < Space.Length; i++)
            {
                if (Char.IsWhiteSpace(Space, i) == false)
                {
                    //Не относится к пробелам
                    space = true;
                }
                else
                {
                    //Относится к пробелам
                    space = false;
                    break;
                }
            }
        }
        //Проверка на цифры
        public void CheckNumeral(string Numeral)
        {
            for (int i = 0; i < Numeral.Length; i++)
            {
                if (Char.IsDigit(Numeral, i) == false)
                {
                    //Не относится к цифрам
                    num = true;
                }
                else
                {
                    //Относится к цифрам
                    num = false;
                    break;
                }
            }
        }
    }
}