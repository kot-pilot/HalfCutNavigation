using Core;
using System;
using System.Timers;
using System.Windows.Forms;
using WindowsFormsUI.Properties;

namespace WindowsFormsUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyCustomApplicationContext());
        }

        private static void timerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            HalfMoveCaretService halfMoveCaretService = new HalfMoveCaretService();
            halfMoveCaretService.HalfMoveRight();
        }

        public class MyCustomApplicationContext : ApplicationContext
        {
            private NotifyIcon trayIcon;
            private System.Timers.Timer timer;

            public MyCustomApplicationContext()
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += new ElapsedEventHandler(timerElapsedEvent);
                timer.Interval = 5000;
                timer.Enabled = true;


                // Initialize Tray Icon
                trayIcon = new NotifyIcon()
                {
                    Icon = Resources.AppIcon,
                    ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                    Visible = true
                };
            }

            void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Visible = false;

                Application.Exit();
            }
        }
    }
}
