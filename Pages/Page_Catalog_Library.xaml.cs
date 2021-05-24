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
    /// Логика взаимодействия для Page_Catalog_Library.xaml
    /// </summary>
    public partial class Page_Catalog_Library : Page
    {
        public Page_Catalog_Library()
        {
            InitializeComponent();
            frame_operation = _framesustem;
        }

        private void _exitsys_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void _relog_Click(object sender, RoutedEventArgs e)
        {
            _operation.Visibility = Visibility.Collapsed;
            idRole = 0;
            ID = 0;
            frame_link.Navigate(authorization);
        }

        private void _userinfo_Click(object sender, RoutedEventArgs e)
        {
            frame_operation.Navigate(profile);
        }

        private void _userlocallibrary_Click(object sender, RoutedEventArgs e)
        {
            frame_operation.Navigate(libraryuser);
        }

        private void _userlibrary_Click(object sender, RoutedEventArgs e)
        {
            frame_operation.Navigate(generallibrary);
        }

        private void _userlist_Click(object sender, RoutedEventArgs e)
        {
            frame_operation.Navigate(viewuser);
        }
    }
}
