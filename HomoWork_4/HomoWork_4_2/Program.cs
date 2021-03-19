using System;

namespace HomoWork_4_2
{
    //Alarm事件类
    public class AlarmEventArgs : EventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public string AlarmContent { get; set; }
        public AlarmEventArgs(int hour,int minute,int second,string alarmContent)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            AlarmContent = alarmContent;
        }
    }
    //声明委托
    public delegate void AlarmHandler(object sender, AlarmEventArgs args);
    class Clock
    {
        private int hour;
        private int minute;
        private int second;
        private int alarm_hour;
        private int alarm_minute;
        private int alarm_second;
        private string alarm_content;

        public Clock(int hour,int minute,int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public event AlarmHandler OnAlarm;

        public void Alarm()
        {
            Console.WriteLine(this.alarm_content);
            AlarmEventArgs args = new AlarmEventArgs(this.alarm_hour,this.alarm_minute,this.alarm_second,this.alarm_content);
            OnAlarm(this, args);
        }
        public void SetAlarm(int hour, int minute, int second, string alarmContent)
        {
            this.alarm_hour = hour;
            this.alarm_minute = minute;
            this.alarm_second = second;
            this.alarm_content = alarmContent;
        }
        public void StartClock()
        {
            //TODO
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
