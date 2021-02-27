using System;

namespace ARVR
{
    public class Time
    {
        private DateTime StartTime = DateTime.Now;
        private DateTime timeLastUpdate;

        public long TotalElapsedTime
        {
            get
            {
                TimeSpan span = DateTime.Now - StartTime;
                return (long)Math.Round(span.TotalMilliseconds);
            }
        }

        public long ElapsedTime
        {
            get
            {
                TimeSpan span = DateTime.Now - timeLastUpdate;
                return (long)Math.Round(span.TotalMilliseconds);
            }
        }

        public void Update()
        {
            timeLastUpdate = DateTime.Now;
        }

    }

}
