using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using THITN.Views; // Thêm dòng này để nhận diện thư mục Views

namespace THITN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi chạy Form Đăng nhập (frmLogin) thay vì Form1
            Application.Run(new frmLogin());
        }
    }
}
