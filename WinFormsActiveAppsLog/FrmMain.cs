namespace WinFormsActiveAppsLog
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            logSetts.AddActiveApp(WindowAPI.ActiveWindowTitle());
            tim.Start();
        }

        // C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp

        private readonly LoggingSettings logSetts = new();

        private void Tim_Tick(object sender, EventArgs e)
        {
            try
            {
                // svakih ActiveAppInterval sekundi se belezi koji je prozor aktivan
                if (DateTime.Now.Second % LoggingSettings.ActiveAppInterval == 0)
                    logSetts.AddActiveApp(WindowAPI.ActiveWindowTitle());
                // svakog minuta se proverava da li postoji close.txt i ako postoji - app se gasi
                var closeFile = Path.Combine(logSetts.Folder, "close.txt");
                if (DateTime.Now.Second == 0 && File.Exists(closeFile))
                {
                    File.Delete(closeFile);
                    Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            logSetts.WriteToLog();
        }

        // https://stackoverflow.com/questions/1163761/capture-screenshot-of-active-window
        //    try
        //    {
        //        //var rect = Screen.AllScreens[0].Bounds;
        //        //using var bmpCapture = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
        //        //using var g = Graphics.FromImage(bmpCapture);
        //        //g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
        //        //bmpCapture.Save(@"c:\Users\bvnet\Downloads\Capture.jpeg", ImageFormat.Jpeg);
        //        var di = Directory.CreateDirectory(Path.Combine(logSetts.Folder, "asdf"));
        //          di.Attributes = FileAttributes.Hidden;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error! " + ex.Message);
        //    }
    }
}