using System;

namespace WinFormsActiveAppsLog
{
    public class AppTimeItem
    {
        public string ActiveApp { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public AppTimeItem(string activeApp, DateTime start)
        {
            ActiveApp = activeApp;
            Start = start;
            End = null;
        }

        public override string ToString()
        {
            var fmt = "HH:mm:ss";
            if (End.HasValue)
            {
                var itv = End.Value - Start;
                if (itv.Seconds % 10 != 0)
                    itv = itv.Add(TimeSpan.FromSeconds(1));
                // dodavanje 2x po pola intervala uzorkovanja (pola intervala pre prvog uzorka i pola posle poslednjeg)
                itv = itv.Add(TimeSpan.FromSeconds(LoggingSettings.ActiveAppInterval));
                return $"{Start.ToString(fmt)} - {End.Value.ToString(fmt)} : {itv:mm':'ss} -> {ActiveApp}";
            }
            else
                return $"{Start.ToString(fmt)} -> {ActiveApp}";
        }
    }
}
