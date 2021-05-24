using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_library1._1.Pages;

namespace E_library1._1.Project_Link
{
    class Page_link
    {
        public static Page_authorization authorization = new Page_authorization();
        public static Page_registration registration = new Page_registration();
        public static Page_Catalog_Library mainmenu = new Page_Catalog_Library();
        public static Page_user_profile profile = new Page_user_profile();
        public static Page_user_library libraryuser = new Page_user_library();
        public static Page_general_library generallibrary = new Page_general_library();
        public static Page_view_user viewuser = new Page_view_user();
    }
}
