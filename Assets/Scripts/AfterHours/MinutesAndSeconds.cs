using System;

namespace AfterHours
{
    [Serializable]
    public struct MinutesAndSeconds
    {
        public int Minutes;

        public int Seconds;

        public MinutesAndSeconds(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
        }
        
        public int TotalSeconds
        {
            get { return Minutes * 60 + Seconds; }
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}", Minutes, Seconds);
        }
    }
}