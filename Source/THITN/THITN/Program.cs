//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using THITN.Helper;
//using THITN.View;
//using THITN.Views; // Thêm dòng này để nhận diện thư mục Views

//namespace THITN
//{
//    static class Program
//    {
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);

//            // Khởi chạy Form Đăng nhập (frmLogin) thay vì Form1
//            SystemInfo.Reset();
//            while (true)
//            {

//                if (SystemInfo.ScreenModeIs == ScreenMode.Logout)
//                {
//                    Application.Run(new frmLogin());
//                }
//                if (SystemInfo.ScreenModeIs == ScreenMode.LoggedIn)
//                {
//                    Application.Run(new frmMain());
//                }
//                if (SystemInfo.ScreenModeIs == ScreenMode.Exiting)
//                {
//                    break;
//                }
//            }
//        }
//    }
//}
using System;
using System.Windows.Forms;
using THITN.Helper;
using THITN.View;

namespace THITN
{
    static class Programu
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SystemInfo.Reset();

            Application.Run(new frmMain());
        }
    }
}