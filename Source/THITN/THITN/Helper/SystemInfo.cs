using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using THITN.Models;

namespace THITN.Helper
{
    public static class SystemInfo
    {
        public static ScreenMode ScreenModeIs = ScreenMode.Logout;
        public static void Reset()
        {
            Role = DatabaseRole.None;
            CurrentSinhVien = null;
            DB.LoginUser = "sv";
            DB.LoginPass = "sv";
            ScreenModeIs = ScreenMode.Logout;
            IsLoggedIn = false;
        }
        public static bool IsLoggedIn = false;
        public static DatabaseRole Role = DatabaseRole.None;
        public static SinhVien CurrentSinhVien = null;
        public static GiaoVien CurrentGiaoVien = null;
        public static class DB
        {
            public static string LoginUser = "sv";
            public static string LoginPass = "sv";
            public static string ServerName = "LAPTOP-NERE0HJ3\\CS0";
            public static string ConnectionString
            {
                get
                {
                    return string.Format("Data Source={0};Initial Catalog=THITN;Persist Security Info=True;User ID={1};Password={2}", ServerName, LoginUser, LoginPass);
                }
            }
        }
    }
}
