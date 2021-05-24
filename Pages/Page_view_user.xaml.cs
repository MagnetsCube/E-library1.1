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
using E_library1._1.Entities;

namespace E_library1._1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_view_user.xaml
    /// </summary>
    public partial class Page_view_user : Page
    {
        public Page_view_user()
        {
            InitializeComponent();
        }

        private void _delete_Click(object sender, RoutedEventArgs e)
        {
            if (_listview.SelectedItem is User_List_View User)
            {
                if (context.Userdb.Where(i => i.idUser == User.idUser).FirstOrDefault() != null)
                {
                    context.Userdb.Remove(context.Userdb.Where(i => i.idUser == User.idUser).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    viewuser._listview.ItemsSource = context.User_List_View.ToList();
                }
                else
                {
                    MessageBox.Show("Удаление этого пользователя запрещено ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else MessageBox.Show("Выберите пользователя", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void _edit_Click(object sender, RoutedEventArgs e)
        {
            if (_listview.SelectedItem is User_List_View User)
            {
                if (context.Userdb.Where(i => i.idUser == User.idUser).FirstOrDefault() != null)
                {
                    //context.Userdb.Remove(context.Userdb.Where(i => i.idUser == User.idUser).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Запись изменена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    viewuser._listview.ItemsSource = context.User_List_View.ToList();
                }
                else
                {
                    MessageBox.Show("Изменение этого пользователя запрещено ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else MessageBox.Show("Выберите пользователя", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
