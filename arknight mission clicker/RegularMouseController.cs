using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace arknight_mission_clicker
{
    class RegularMouseController : MouseController
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


        public bool SetMouse(int x, int y)
        {
            _x = x;
            _y = y;

            System.Drawing.Point p;
            GetCursorPos(out p);
            _prevX = p.X;
            _prevY = p.Y;

            return SetCursorPos(x, y);
        }

        public void Click()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, _x, _y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, _x, _y, 0, 0);

            SetCursorPos(_prevX, _prevY);
        }

        public void Press()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, _x, _y, 0, 0);
        }

        public void Release()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, _x, _y, 0, 0);

            SetCursorPos(_prevX, _prevY);
        }

    }
}
