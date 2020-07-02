using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace arknight_mission_clicker
{
    class WindowManager
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        public int windowWidth = 960;
        public int windowHeight = 572;

        public void setWindowPos (int x, int y, string windowName = "NoxPlayer")
        {
            var w = FindWindow(null, windowName);

            SetWindowPos(w, IntPtr.Zero, x, y, windowWidth, windowHeight, 0x0020);
            SetForegroundWindow(w);

        }

        public void setWindowPosTop(int x, int y, string windowName = "NoxPlayer")
        {
            var w = FindWindow(null, windowName);

            SetWindowPos(w, new IntPtr(-1), x, y, windowWidth, windowHeight, 0x0020);
            SetForegroundWindow(w);

        }

        public void UnsetTopMost (int x, int y, string windowName = "NoxPlayer")
        {
            var w = FindWindow(null, windowName);

            SetWindowPos(w, new IntPtr(-2), x, y, windowWidth, windowHeight, 0x0020);
            SetForegroundWindow(w);
        }

    }
}
