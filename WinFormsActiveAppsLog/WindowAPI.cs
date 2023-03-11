using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsActiveAppsLog
{
    /// <summary></summary>
    /// <see cref="https://thecodeprogram.com/how-to-get-active-windows-with-c-"/>
    public class WindowAPI
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string ActiveWindowTitle()
        {
            //Create the variable
            const int nChar = 256;
            var ss = new StringBuilder(nChar);

            //Run GetForeGroundWindows and get active window informations
            //assign them into handle pointer variable
            IntPtr handle;
            handle = GetForegroundWindow();

            if (GetWindowText(handle, ss, nChar) > 0)
                return ss.ToString();
            else
                return "";
        }
    }
}
