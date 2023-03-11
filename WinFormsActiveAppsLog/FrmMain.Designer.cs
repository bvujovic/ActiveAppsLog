namespace WinFormsActiveAppsLog
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tim = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tim
            // 
            tim.Interval = 1000;
            tim.Tick += Tim_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(134, 11);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Location = new Point(-200, 0);
            Margin = new Padding(2);
            Name = "FrmMain";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Active Apps Log";
            FormClosed += FrmMain_FormClosed;
            Load += FrmMain_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer tim;
    }
}