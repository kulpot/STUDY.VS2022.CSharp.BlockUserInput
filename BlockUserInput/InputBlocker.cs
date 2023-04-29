using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BlockUserInput
{
    static class InputBlocker
    {
        [DllImport("user32.dll")]
        static extern bool BlockInput(bool fBlockIt);


        private static Timer _timer = new Timer();

        static InputBlocker()
        {
            _timer.Tick += new EventHandler(_timer_Tick);
        }

        public static void BlockInput(int ms)
        {
            BlockInput(true);
            _timer.Interval = ms;
            _timer.Start();
        }

        private static void _timer_Tick(object sender, EventArgs e)
        {
            BlockInput(false);
            _timer.Stop();
        }
    }
}
