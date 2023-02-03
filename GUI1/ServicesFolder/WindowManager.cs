using GUI1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI1.ServicesFolder
{
    public static class WindowManager
    {
        static LoginWindow loginWindow;
        static MainWindow mainWindow;

        public static void OpenMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }
        public static void CloseMainWindow()
        {
            if(mainWindow != null)
            {
                mainWindow.Close();
            }
            mainWindow = null;
        }
        public static void OpenLoginWindow()
        {
            loginWindow = new LoginWindow();
            loginWindow.Show();
        }
        public static void CloseLoginWindow()
        {
            if(loginWindow != null)
            {
                loginWindow.Close();
            }
            loginWindow = null;
        }
    }
}
