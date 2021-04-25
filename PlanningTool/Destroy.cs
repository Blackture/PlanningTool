using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PlanningTool
{
    class Destroy
    {
        private Timer timer;
        private object obj;
        public EventHandler<object> onDestroy;

        public Destroy(int t, object o)
        {
            obj = o;
            timer = new Timer();
            timer.Interval = t;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            onDestroy?.Invoke(this, obj);
            obj = null;
        }
    }
}
