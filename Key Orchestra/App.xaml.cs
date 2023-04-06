using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Key_Orchestra
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private Boolean ApplicationHiddenIs;
        public Boolean get_ApplicatoinHiddenIs() { return ApplicationHiddenIs; }
        public void set_ApplicationHiddenIs(Boolean value) { ApplicationHiddenIs = value; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var icon = GetResourceStream(new Uri("Icons/Icon.ico", UriKind.Relative)).Stream;
            var menu = new System.Windows.Forms.ContextMenuStrip();
            menu.Items.Add("終了", null, Exit_Click);
            var notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Visible = true,
                Icon = new System.Drawing.Icon(icon),
                Text = "Key Orchestra",
                ContextMenuStrip = menu
            };
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(NotifyIcon_Click);

            set_ApplicationHiddenIs(true);
        }

        private void NotifyIcon_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (get_ApplicatoinHiddenIs())
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    var wnd = new MainWindow();
                    wnd.Show();
                    set_ApplicationHiddenIs(false);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Shutdown();
        }
    }
}
