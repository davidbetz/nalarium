using System;
using System.Diagnostics;
using System.Timers;

namespace Nalarium
{
    public class DelayedAction
    {
        private readonly Action _action;
        private readonly Timer _timer;
        private readonly string _id;

        public DelayedAction(Action action, int delay = 5000, string id = "")
        {
            _id = id;
            _action = action;
            _timer = new Timer(delay);
            _timer.Elapsed += Elapsed;
        }

        public void Start()
        {
            if (_action == null)
            {
                return;
            }
            _timer.Start();
        }

        public void Stop()
        {
            if (!String.IsNullOrEmpty(_id))
            {
                Debug.WriteLine($"DelayedAction: Stop: {_id}");
            }
            _timer.Stop();
        }

        private void Elapsed(object sender, ElapsedEventArgs ea)
        {
            if (!String.IsNullOrEmpty(_id))
            {
                Debug.WriteLine($"DelayedAction: Elapsed: {_id}");
            }
            Stop();
            _action();
        }
    }
}