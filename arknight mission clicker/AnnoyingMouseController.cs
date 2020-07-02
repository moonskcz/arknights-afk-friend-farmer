using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace arknight_mission_clicker
{
    class AnnoyingMouseController : MouseController
    {
        [DllImport("user32.dll")]
        static private extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out System.Drawing.Point lpPoint);

        private int _x = 0;
        private int _y = 0;

        private int _prevX = 0;
        private int _prevY = 0;

        private WindowManager WM;

        public AnnoyingMouseController ()
        {
            WM = new WindowManager();
        }

        public bool SetMouse(int x, int y)
        {
            _x = x;
            _y = y;

            System.Drawing.Point p;
            GetCursorPos(out p);
            _prevX = p.X;
            _prevY = p.Y;

            WM.setWindowPos(100, 100);
            return SetCursorPos(x, y);
        }

        public void Click()
        {
            WM.setWindowPos(100, 100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, _x, _y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, _x, _y, 0, 0);

            SetCursorPos(_prevX, _prevY);
        }

        public void Press()
        {
            WM.setWindowPos(100, 100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, _x, _y, 0, 0);
        }

        public void Release()
        {
            WM.setWindowPos(100, 100);
            mouse_event(MOUSEEVENTF_LEFTUP, _x, _y, 0, 0);

            SetCursorPos(_prevX, _prevY);
        }
    }
}
