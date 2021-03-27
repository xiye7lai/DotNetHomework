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

    //Tick事件类
    public class TickEventArgs : EventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public TickEventArgs(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }
    //声明委托
    public delegate void AlarmHandler(object sender, AlarmEventArgs args);
    public delegate void TickHandler(object sender, TickEventArgs args);
    class Clock
    {
        private int hour;
        private int minute;
        private int second;
        private int alarm_hour;
        private int alarm_minute;
        private int alarm_second;
        private string alarm_content;
        private bool isAlarmed;

        public event AlarmHandler OnAlarm;
        public event TickHandler OnTick;

        public Clock()
        {
            OnTick += Clock_OnTick;
            OnAlarm += Clock_OnAlarm;
            this.hour = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
            this.isAlarmed = false;
        }

        //alarm处理事件
        private void Clock_OnAlarm(object sender, AlarmEventArgs args)
        {
            Console.WriteLine($"Alarm!{this.alarm_content}，Alarm时间：{this.alarm_hour}:{this.alarm_minute}:{this.alarm_second}");
        }

        //tick处理事件
        private void Clock_OnTick(object sender, TickEventArgs args)
        {
            Console.WriteLine($"Tick!，当前时间：{this.hour}:{this.minute}:{this.second}");
        }

        //触发alarm事件
        public void Alarm()
        {
            AlarmEventArgs args = new AlarmEventArgs(this.alarm_hour,this.alarm_minute,this.alarm_second,this.alarm_content);
            this.OnAlarm(this, args);
            this.isAlarmed = true;
        }
        public void SetAlarm(int hour, int minute, int second, string alarmContent)
        {
            this.alarm_hour = hour;
            this.alarm_minute = minute;
            this.alarm_second = second;
            this.alarm_content = alarmContent;
        }

        //触发tick事件
        public void Tick()
        {
            TickEventArgs args = new TickEventArgs(this.hour, this.minute, this.second);
            this.OnTick(this,args);
        }

        public void StartClock()
        {
            while (true)
            {
                if (!isAlarmed&&DateTime.Now.Hour == alarm_hour && DateTime.Now.Minute == alarm_minute && DateTime.Now.Second == alarm_second)
                {
                    this.Alarm();
                    continue;
                }
                while (DateTime.Now.Second != second || DateTime.Now.Minute != minute || DateTime.Now.Hour != hour)
                {
                    this.second = DateTime.Now.Second;
                    this.minute = DateTime.Now.Minute;
                    this.hour = DateTime.Now.Hour;
                    this.Tick();
                }
            }
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Clock c = new Clock();
            c.SetAlarm(23, 13, 40, "快起床呀！");
            c.StartClock();
        }
    }
}
