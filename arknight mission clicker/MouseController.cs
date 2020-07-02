using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arknight_mission_clicker
{
    interface MouseController
    {

        bool SetMouse(int x, int y);

        void Click();

        /// <summary>
        /// holds down the mouse button
        /// </summary>
        void Press();

        /// <summary>
        /// releases the mouse button
        /// </summary>
        void Release();

    }
}
