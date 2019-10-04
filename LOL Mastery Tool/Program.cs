using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace LOL_Mastery_Tool
{
    static class Program
    {
        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")] 
        public static extern int SendMessage( IntPtr hWnd, uint Msg, int wParam, int lParam ); 

        public const int WM_SYSCOMMAND = 0x0112; 
        public const int SC_CLOSE = 0xF060;

        /// <summary>
        /// The main entry point for the application. woo
        /// </summary>
        [STAThread]

        static void Main()
        {
            IntPtr search = FindWindowByCaption( IntPtr.Zero, "MiniDude22's Mastery Tool" );
            if ( IsWindow( search ) ) 
            { 
                SendMessage( search, WM_SYSCOMMAND, SC_CLOSE, 0 ); 
                MessageBox.Show( "Another instance of Minidude22's LoL Mastery Tool was running, and has been terminated!\r\nIf running the program from the wrong location, your builds may not load!", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
