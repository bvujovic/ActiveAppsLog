using System;

namespace WinFormsActiveAppsLog
{
    public class LoggingSettings
    {
        public LoggingSettings()
        {
            Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ActiveApps");
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);
            //TODO ako Directory.CreateDirectory() ne uspe - izaci iz aplikacije
            activeApps = new List<AppTimeItem>();
        }

        /// <summary>Ime foldera koji se nalazi u (user)/Documents u kojem ce se kreirati .log fajlovi.</summary>
        public string Folder { get; set; }

        /// <summary>Na koliko se sekundi ispituje koja je aplikacija aktivna.</summary>
        public static int ActiveAppInterval => 10; // test 5, produkcija 10
        //B public int ActiveAppInterval { get; set; } = 10; // test 5, produkcija 10

        /// <summary>U kom minutu (unutar sata) se podaci pisu u log fajl.</summary>
        public static int LogIntervalMinutes => 5; // test 1min, produkcija 5min
        //B public int LogIntervalMinutes { get; set; } = 5; // test 1min, produkcija 5min

        private readonly List<AppTimeItem> activeApps;

        public void AddActiveApp(string activeApp, DateTime? dateTime = null)
        {
            if (!dateTime.HasValue)
                dateTime = DateTime.Now;
            if (activeApps.Any())
            {
                var lastActiveApp = activeApps.Last();
                if (lastActiveApp.ActiveApp == activeApp)
                    lastActiveApp.End = DateTime.Now;
                else
                    activeApps.Add(new AppTimeItem(activeApp, dateTime.Value));
            }
            else
                activeApps.Add(new AppTimeItem(activeApp, dateTime.Value));
            WriteToLogIN();
        }

        private void WriteToLogIN()
        {
            if (!activeApps.Any())
                return;
            if (DateTime.Now.Second == 0 && DateTime.Now.Minute % LogIntervalMinutes == 0)
                WriteToLog();
        }

        public void WriteToLog()
        {
            // ime fajla na osnovu datuma
            //B var fileName = DateTime.Now.ToShortDateString() + ".log";
            var fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            var filePath = Path.Combine(Folder, fileName);
            // istovariti sve stavke u fajl
            using var sw = new StreamWriter(filePath, true);
            foreach (var aa in activeApps)
                sw.WriteLine(aa);
            sw.Close();
            // obrisati kolekciju activeApps
            activeApps.Clear();
        }
    }
}
