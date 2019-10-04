using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

using System.Runtime.InteropServices;

namespace LOL_Mastery_Tool
{
    public partial class frmMain : Form
    {
        #region DLL calls
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr mouse_event(uint dwFlags, int dx, int dy, IntPtr dwData, IntPtr dwExtraInfo);

        [DllImportAttribute("User32.dll")]
        private static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport( "user32.dll" )]
        private static extern IntPtr GetDC( IntPtr hWnd );

        [DllImport( "user32.dll" )]
        private static extern int ReleaseDC( IntPtr hWnd, IntPtr hDC );

        [DllImport( "gdi32.dll" )]
        private static extern int GetPixel( IntPtr hDC, int x, int y );

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int width, int height, SetWindowPosFlags uFlags);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        [Flags]
        public enum SetWindowPosFlags : uint
        {
            // ReSharper disable InconsistentNaming

            /// <summary>
            ///     If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request.
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000,

            /// <summary>
            ///     Prevents generation of the WM_SYNCPAINT message.
            /// </summary>
            SWP_DEFERERASE = 0x2000,

            /// <summary>
            ///     Draws a frame (defined in the window's class description) around the window.
            /// </summary>
            SWP_DRAWFRAME = 0x0020,

            /// <summary>
            ///     Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,

            /// <summary>
            ///     Hides the window.
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,

            /// <summary>
            ///     Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOACTIVATE = 0x0010,

            /// <summary>
            ///     Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,

            /// <summary>
            ///     Retains the current position (ignores X and Y parameters).
            /// </summary>
            SWP_NOMOVE = 0x0002,

            /// <summary>
            ///     Does not change the owner window's position in the Z order.
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,

            /// <summary>
            ///     Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
            /// </summary>
            SWP_NOREDRAW = 0x0008,

            /// <summary>
            ///     Same as the SWP_NOOWNERZORDER flag.
            /// </summary>
            SWP_NOREPOSITION = 0x0200,

            /// <summary>
            ///     Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,

            /// <summary>
            ///     Retains the current size (ignores the cx and cy parameters).
            /// </summary>
            SWP_NOSIZE = 0x0001,

            /// <summary>
            ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOZORDER = 0x0004,

            /// <summary>
            ///     Displays the window.
            /// </summary>
            SWP_SHOWWINDOW = 0x0040,

            // ReSharper restore InconsistentNaming
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        #endregion

        #region Variables and Constants
        #region DLL Constants
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP   = 0x0004;
        private const uint WM_PAINT             = 0x000F;
        private const int SW_SHOWNORMAL    = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        #endregion

        #region Tree Data
        private List<Point> OffensePoints = new List<Point>();
        private List<Point> DefensePoints = new List<Point>();
        private List<Point> UtilityPoints = new List<Point>();
        #endregion

        #region Profile Page Data
        private Point ProfileMoveOffset;
        private Point ProfileOffenseOffset;
        private Point ProfileDefenseOffset;
        private Point ProfileUtilityOffset;
        private Point ProfileColorPoint1;
        private Point ProfileColorPoint2;
        private Point ProfileResetPoint;
        private Point ProfileSavePoint;
        private Color ProfilePoint1Color;
        private Color ProfilePoint2Color;
        #endregion

        #region Champion Selection Page Data
        private Point ChampionMoveOffset;
        private Point ChampionOffenseOffset;
        private Point ChampionDefenseOffset;
        private Point ChampionUtilityOffset;
        private Point ChampionColorPoint1;
        private Point ChampionColorPoint2;
        private Point ChampionResetPoint;
        private Point ChampionSavePoint;
        private Color ChampionPointColor;
        #endregion

        #region XML Stuff
        private static string path = System.IO.Directory.GetCurrentDirectory() + "\\Data\\Builds.xml";
        private XmlDocument doc = new XmlDocument();
        private XmlNode     node;
        private XmlElement  root;
        private XmlElement  Build;
        private XmlElement  Offense;
        private XmlElement  Defense;
        private XmlElement  Utility;
        private XmlElement  Info;
        private Regex       newlineRegex = new Regex("\r?\n");

        private static string OptPath = System.IO.Directory.GetCurrentDirectory() + "\\Data\\Options.xml";
        private XmlDocument OptDoc = new XmlDocument();
        #endregion

        #region LoL Client Stuff
        IntPtr    lolHWND      = IntPtr.Zero;
        Rectangle lolRECT      = new Rectangle();
        float     lolWIDTH     = 1280F;
        float     lolRATIO     = 1F;
        static int windowHEIGHT = 478;
        static int windowWIDTH  = 218;
        SizeF ratioSMALL = new SizeF( windowWIDTH * 0.8F, windowHEIGHT * 0.8F );
        SizeF ratioBIG   = new SizeF( windowWIDTH * 1.2F, windowHEIGHT * 1.2F );
        private enum windowSizes { big, small }
        windowSizes  lolSIZE = windowSizes.big;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        #endregion

        #region The Rest
        private int masteryWidthSpacer  = 64;
        private int masteryHeightSpacer = 75;

        private enum Pages { ProfilePage, ChampionSelection };
        private enum States { Visible, Hidden };
        private Pages loc = Pages.ProfilePage;
        private States currentState = States.Visible;

        private bool loadingBuild = false;

        private bool Logging = true;
        private System.IO.StreamWriter logfile = new System.IO.StreamWriter(@"C:\Users\Derrik\Desktop\League Tools\log.txt", true);
        #endregion

        #region XML Options file Variables
        private int ClickInterval        = 100;
        private int ClickSleepInverval   = 50;
        private int LeagueSearchInverval = 5000;
        private int ModifySearchInverval = 75;
        #endregion
        #endregion

        public frmMain()
        {
            InitializeComponent();
            Hide();
        }

        #region Background Worker
        private void bgwColorChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int sleeptime = ModifySearchInverval;
            while ( true )
            {
                //if ( !Convert.ToBoolean( GetKeyState( VirtualKeyStates.VK_LBUTTON ) & KEY_PRESSED ) )
                //{
                    if( IsWindow( lolHWND ) ) 
                    {
                        worker.ReportProgress( 6 );
                        updateWindowLocation();
                        lolRATIO = lolRECT.Width / lolWIDTH;
                        //if ( lolSIZE == windowSizes.big   ) { MessageBox.Show( "Already big"   ); }
                        //if ( lolSIZE == windowSizes.small ) { MessageBox.Show( "Already Small" ); }
                        //MessageBox.Show( "lolRATIO = " + lolRATIO.ToString() );
                        if ( lolRATIO == 0.8F && lolSIZE == windowSizes.big ) 
                        {
                            worker.ReportProgress( 3 );
                        } else if ( lolRATIO == 1F && lolSIZE == windowSizes.small ) {
                            worker.ReportProgress( 4 );
                        }
                    } else {
                        lolHWND = FindWindowByCaption( IntPtr.Zero, "PVP.net Client" );
                        if( IsWindow( lolHWND ) ) { updateWindowLocation(); sleeptime = ModifySearchInverval; } else { worker.ReportProgress( 5 ); sleeptime = LeagueSearchInverval; }
                    }

                    if ( loadingBuild == false )
                    {
                        Color c = GetPixelColor( lolHWND, ProfileColorPoint1.X, ProfileColorPoint1.Y );
                        if ( c.R == ProfilePoint1Color.R && c.G == ProfilePoint1Color.G && c.B == ProfilePoint1Color.B )
                        {
                            c = GetPixelColor( lolHWND, ProfileColorPoint2.X, ProfileColorPoint2.Y );
                            if ( c.R == ProfilePoint2Color.R && c.G == ProfilePoint2Color.G && c.B == ProfilePoint2Color.B )
                            {
                                updateWindowLocation();
                                if ( this.Location.X != lolRECT.X + ProfileMoveOffset.X || 
                                     this.Location.Y != lolRECT.Y + ProfileMoveOffset.Y )
                                {
                                    worker.ReportProgress( 1 );
                                }
                            }
                        } else {
                            c = GetPixelColor( lolHWND, ChampionColorPoint1.X, ChampionColorPoint1.Y );
                            //MessageBox.Show( "Coordinates: " + ChampionColorPoint1.ToString() + "\nColor: " + c.ToString() + "\nStoredColor: " + ChampionPointColor.ToString() );
                            if ( c.R == ChampionPointColor.R && c.G == ChampionPointColor.G && c.B == ChampionPointColor.B ) {
                                c = GetPixelColor( lolHWND, ChampionColorPoint2.X, ChampionColorPoint2.Y );
                                //MessageBox.Show( "Coordinates: " + ChampionColorPoint1.ToString() + "\nColor: " + c.ToString() + "\nStoredColor: " + ChampionPointColor.ToString() );
                                if ( c.R == ChampionPointColor.R && c.G == ChampionPointColor.G && c.B == ChampionPointColor.B )
                                {
                                    updateWindowLocation();
                                    if ( this.Location.X != lolRECT.X + ChampionMoveOffset.X || 
                                         this.Location.Y != lolRECT.Y + ChampionMoveOffset.Y )
                                    {
                                        worker.ReportProgress( 2 );
                                    }
                                }
                            } else {
                                worker.ReportProgress( 0 );
                            }
                        }
                    }
                //}
                Thread.Sleep( sleeptime );
            }
        }

        private void bgwColorChecker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int result = e.ProgressPercentage;
            switch (result)
            {
                case 0:
                    setState( States.Hidden );
                    break;
                case 1:
                    Location = new Point ( lolRECT.X + ProfileMoveOffset.X, lolRECT.Y + ProfileMoveOffset.Y );
                    makeProgramVisible();
                    loc = Pages.ProfilePage;
                    logCase(1, "Page changed to Profile Page");
                    break;
                case 2:
                    Location = new Point ( lolRECT.X + ChampionMoveOffset.X, lolRECT.Y + ChampionMoveOffset.Y );
                    makeProgramVisible();
                    loc = Pages.ChampionSelection;
                    logCase(2, "Page changed to Champion Selection");
                    break;
                case 3:
                    this.Width  = Convert.ToInt32( windowWIDTH  * 0.8F );
                    this.Height = Convert.ToInt32( windowHEIGHT * 0.8F );
                    btnDelete.Width = 70;
                    btnEdit.Width   = 70;
                    btnNew.Width    = 70;
                    btnLoad.Width   = 70;
                    btnDelete.Location = new Point( 93, btnDelete.Location.Y );
                    btnEdit  .Location = new Point( 93, btnEdit  .Location.Y );
                    this.BackgroundImage = global::LOL_Mastery_Tool.Properties.Resources.bg_Small;
                    changePointData( windowSizes.small );
                    lolSIZE = windowSizes.small;
                    logCase(3, "Resize, Big to small");
                    break;
                case 4:
                    this.Width  = Convert.ToInt32( windowWIDTH  );
                    this.Height = Convert.ToInt32( windowHEIGHT );
                    btnDelete.Width = 90;
                    btnEdit.Width   = 90;
                    btnNew.Width    = 90;
                    btnLoad.Width   = 90;
                    btnDelete.Location = new Point( 116, btnDelete.Location.Y );
                    btnEdit  .Location = new Point( 116, btnEdit  .Location.Y );
                    this.BackgroundImage = global::LOL_Mastery_Tool.Properties.Resources.bg;
                    changePointData( windowSizes.big );
                    lolSIZE = windowSizes.big;
                    logCase(4, "Resize, Small to big");
                    break;
                case 5:
                    resizeToolStripMenuItem.Enabled = false;
                    //logCase(5, "Resize button disabled");
                    break;
                case 6:
                    resizeToolStripMenuItem.Enabled = true;
                    //logCase(5, "Resize button enabled");
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show( "Something went wrong in the background worker Process Changed Function" );
                    bgwColorChecker.Dispose();
                    this.Dispose();
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }

        private int lastCast = 0;
        private void logCase( int i, string s )
        {
            if ( lastCast != i && Logging )
            {
                string time = DateTime.Now.ToString("hh:mm:ss");
                lastCast = i;
                logfile.WriteLine( "(" + time + ") - Case " + i.ToString() + " : " + s );
            }
        }

        public static bool isTopWindow(IntPtr hWnd)
        {
            IntPtr topWindow = GetForegroundWindow();
            if (hWnd == topWindow)
                return true;
            return false;
        }

        public void makeProgramVisible()
        {
            if ( isTopWindow( lolHWND ) || isTopWindow( this.Handle ) )
            {
                setState( States.Visible );
            }
        }
        #endregion

        #region Event Handlers
        private void frmMain_Load(object sender, EventArgs e)
        {
            try   {             doc.Load( path ); }
            catch { setupXML(); doc.Load( path ); TrayIcon.ShowBalloonTip( 5000 ); }
            try   {                OptDoc.Load( OptPath ); }
            catch { OptSetupXML(); OptDoc.Load( OptPath ); }
            root = doc.DocumentElement;
            LoadSettings();
            gatherBuildData();
            if ( lbBuilds.Items.Count < 1 )
            {
                btnLoad  .Enabled = false;
                btnDelete.Enabled = false;
                btnEdit  .Enabled = false;
            } else { lbBuilds.SelectedIndex = 0; }
            lolSIZE = windowSizes.small;
            changePointData( windowSizes.big );
            lolSIZE = windowSizes.big;

            bgwColorChecker.RunWorkerAsync();
        }

        private void lbBuilds_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            try 
            { 
                node         = root.SelectSingleNode("//Build[@Name='" + lb.SelectedItem.ToString() + "']");
                edtData.Text = ( node.ChildNodes.Item(0).InnerText + "\r\n" + node.ChildNodes.Item(1).InnerText + "\r\n" + node.ChildNodes.Item(2).InnerText );
                btnLoad.Enabled   = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled   = true;
            } 
            catch { btnLoad.Enabled = false; btnDelete.Enabled = false; btnEdit.Enabled = false; edtData.Text = "00000000000000000\r\n0000000000000000\r\n0000000000000000"; }
        }

        private void lbBuilds_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point( e.X, e.Y );
            int   i = lbBuilds.IndexFromPoint( p );
            if ( i != -1 ) 
            {
                if ( toolTip.ToolTipTitle != lbBuilds.Items[i].ToString() || toolTip.Active == false )
                {
                    string name = lbBuilds.Items[i].ToString();
                    string info = "No description or info.";
                    try
                    { 
                        node = doc.DocumentElement.SelectSingleNode("//Build[@Name='" + name + "']");
                        if ( node != null && node.ChildNodes[3].InnerText != "" ) info = node.ChildNodes[3].InnerText;
                    }
                    catch {}

                    toolTip.ToolTipTitle = name;
                    toolTip.SetToolTip( lbBuilds, info );
                    toolTip.AutomaticDelay = 500;
                    toolTip.InitialDelay = 500;
                    toolTip.Active = true;
                }
            } else {
                toolTip.Active = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            bgwColorChecker.Dispose();
            this.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox.showBox();
        }

        private void x800ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWindowPos( lolHWND, HWND_TOP, lolRECT.X, lolRECT.Y, 1280, 800, SetWindowPosFlags.SWP_SHOWWINDOW );
            //Thread.Sleep( 100 );
            InvalidateRect( lolHWND, IntPtr.Zero, true );
            //Thread.Sleep( 100 );
            PostMessage( lolHWND, WM_PAINT, IntPtr.Zero, IntPtr.Zero );
            //ShowWindowAsync( lolHWND, SW_SHOWMINIMIZED );
            //ShowWindowAsync( lolHWND, SW_SHOWNORMAL );
        }

        private void x640ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWindowPos( lolHWND, HWND_TOP, lolRECT.X, lolRECT.Y, 1024, 640, SetWindowPosFlags.SWP_SHOWWINDOW );
            //Thread.Sleep( 100 );
            InvalidateRect( lolHWND, IntPtr.Zero, true );
            //Thread.Sleep( 100 );
            PostMessage( lolHWND, WM_PAINT, IntPtr.Zero, IntPtr.Zero );
            //ShowWindowAsync( lolHWND, SW_SHOWMINIMIZED );
            //ShowWindowAsync( lolHWND, SW_SHOWNORMAL );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bgwColorChecker.Dispose();
            this.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            loadingBuild = true;
            string[] data = BuildEditor.showBox();
            loadingBuild = false;
            if ( data[0] != "Cancel" )
            {
                if ( checkDataString( data[2] ) )
                {
                    data[0] = getUniqueName( data[0], doc );

                    Build   = doc.CreateElement( "Build"   );
                    Offense = doc.CreateElement( "Offense" );
                    Defense = doc.CreateElement( "Defense" );
                    Utility = doc.CreateElement( "Utility" );
                    Info    = doc.CreateElement( "Info"    );

                    Build.SetAttribute( "Name", data[0] );

                    Offense.InnerText = newlineRegex.Split(data[2])[0];
                    Defense.InnerText = newlineRegex.Split(data[2])[1];
                    Utility.InnerText = newlineRegex.Split(data[2])[2];
                    Info   .InnerText = data[1];

                    Build.AppendChild( Offense );
                    Build.AppendChild( Defense );
                    Build.AppendChild( Utility );
                    Build.AppendChild( Info    );

                    doc.DocumentElement.AppendChild( Build );

                    doc.Save( path );

                    lbBuilds.Items.Add( data[0] );
                    lbBuilds.SelectedIndex = lbBuilds.Items.IndexOf( data[0] );
                } else { System.Windows.Forms.MessageBox.Show( "Invalid build string.", "Error", MessageBoxButtons.OK ); }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string oldName = lbBuilds.SelectedItem.ToString();
            node = doc.DocumentElement.SelectSingleNode("//Build[@Name='" + oldName + "']");

            loadingBuild = true;
            string[] data  = BuildEditor.showBox( oldName, node.ChildNodes[3].InnerText, edtData.Text );
            loadingBuild = false;
            if ( data[0] != "Cancel" && ( data[0] != oldName || data[1] != node.ChildNodes[3].InnerText || buildStringDifferent( node, data[2] ) ) )
            {
                if ( checkDataString( data[2] ) )
                {
                    lbBuilds.Items.Remove( oldName );

                    node.ParentNode.RemoveChild( node );

                    Build   = doc.CreateElement( "Build"   );
                    Offense = doc.CreateElement( "Offense" );
                    Defense = doc.CreateElement( "Defense" );
                    Utility = doc.CreateElement( "Utility" );
                    Info    = doc.CreateElement( "Info"    );

                    Build.SetAttribute( "Name", data[0] );

                    Offense.InnerText = newlineRegex.Split(data[2])[0];
                    Defense.InnerText = newlineRegex.Split(data[2])[1];
                    Utility.InnerText = newlineRegex.Split(data[2])[2];
                    Info   .InnerText = data[1];

                    Build.AppendChild( Offense );
                    Build.AppendChild( Defense );
                    Build.AppendChild( Utility );
                    Build.AppendChild( Info    );

                    doc.DocumentElement.AppendChild( Build );

                    doc.Save( path );

                    lbBuilds.Items.Add( data[0] );
                    lbBuilds.SelectedIndex = lbBuilds.Items.IndexOf( data[0] );
                } else { System.Windows.Forms.MessageBox.Show( "Invalid build string.", "Error", MessageBoxButtons.OK ); }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Name = lbBuilds.SelectedItem.ToString();
            DialogResult diag = System.Windows.Forms.MessageBox.Show( "Are you sure that you want to delete " + Name + "?", "Make Sure!", MessageBoxButtons.YesNo );
            if ( diag == DialogResult.Yes )
            {
                lbBuilds.Items.Remove( Name );

                node = doc.DocumentElement.SelectSingleNode("//Build[@Name='" + Name + "']");
                node.ParentNode.RemoveChild( node );
                doc.Save( path );
                try { lbBuilds.SelectedIndex = 0; } catch {}
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            XmlNode build = doc.DocumentElement.SelectSingleNode("//Build[@Name='" + lbBuilds.SelectedItem.ToString() + "']");
            string s = build.ChildNodes[0].InnerText + "\r\n" + build.ChildNodes[1].InnerText + "\r\n" + build.ChildNodes[2].InnerText;

            if ( checkDataString( s ) && lbBuilds.Items.Count > 0 )
            {
                loadingBuild = true;
                getPointData();
                SetForegroundWindow( lolHWND );
                mouseClick( OffensePoints[0].X + lolRECT.X, OffensePoints[0].Y + lolRECT.Y );
                ResetPoints();
                Thread.Sleep( 300 );
                fillTree( build.ChildNodes[0].InnerText, OffensePoints );
                Thread.Sleep( 300 );
                fillTree( build.ChildNodes[1].InnerText, DefensePoints );
                Thread.Sleep( 300 );
                fillTree( build.ChildNodes[2].InnerText, UtilityPoints );
                Thread.Sleep( 300 );
                SaveBuild();
                Thread.Sleep( 300 );
                loadingBuild = false;
            } else { System.Windows.Forms.MessageBox.Show( "Invalid Build.", "Error", System.Windows.Forms.MessageBoxButtons.OK ); }
        }
        #endregion

        #region Utility Functions
        private void changePointData( windowSizes size )
        {
            if ( lolSIZE == windowSizes.big && size == windowSizes.small )
            {
                ProfileMoveOffset    = new Point(  94, 197 );
                ProfileOffenseOffset = new Point( 312, 225 );
                ProfileDefenseOffset = new Point( 534, 225 ); 
                ProfileUtilityOffset = new Point( 752, 225 );
                ProfileColorPoint1   = new Point( 188, 198 );
                ProfileColorPoint2   = new Point( 188, 580 );
                ProfileResetPoint    = new Point( 185, 331 );
                ProfileSavePoint     = new Point( 185, 305 );
                ProfilePoint1Color   = Color.FromArgb( 255, 147, 123, 59 );
                ProfilePoint2Color   = Color.FromArgb( 255, 147, 123, 59 );

                masteryWidthSpacer  = 49;
                masteryHeightSpacer = 57;

                ChampionMoveOffset    = new Point( 106, 150 );
                ChampionOffenseOffset = new Point( 326, 190 );
                ChampionDefenseOffset = new Point( 547, 190 );
                ChampionUtilityOffset = new Point( 767, 190 );
                ChampionColorPoint1   = new Point( 190, 160 );
                ChampionColorPoint2   = new Point( 190, 542 );
                ChampionResetPoint    = new Point( 190, 298 );
                ChampionSavePoint     = new Point( 190, 272 );
                ChampionPointColor   = Color.FromArgb( 255, 147, 123, 59 );

            } else if ( lolSIZE == windowSizes.small && size == windowSizes.big ) {
                ProfileMoveOffset    = new Point( 116, 247 );
                ProfileOffenseOffset = new Point( 390, 280 );
                ProfileDefenseOffset = new Point( 663, 280 );
                ProfileUtilityOffset = new Point( 938, 280 );
                ProfileColorPoint1   = new Point( 223, 248 );
                ProfileColorPoint2   = new Point( 223, 725 );
                ProfileResetPoint    = new Point( 225, 413 );
                ProfileSavePoint     = new Point( 222, 378 );
                ProfilePoint1Color   = Color.FromArgb( 255, 147, 123, 59 );
                ProfilePoint2Color   = Color.FromArgb( 255, 147, 123, 59 );

                masteryWidthSpacer  = 61;
                masteryHeightSpacer = 71;

                ChampionMoveOffset    = new Point( 126, 167 );
                ChampionOffenseOffset = new Point( 402, 202 );
                ChampionDefenseOffset = new Point( 677, 202 );
                ChampionUtilityOffset = new Point( 952, 202 );
                ChampionColorPoint1   = new Point( 237, 167 );
                ChampionColorPoint2   = new Point( 237, 644 );
                ChampionResetPoint    = new Point( 232, 339 );
                ChampionSavePoint     = new Point( 234, 307 );
                ChampionPointColor    = Color.FromArgb( 255, 147, 123, 59 );
            }
        }

        private void updateWindowLocation()
        {
            RECT rct;
            if( GetWindowRect( new HandleRef( this, lolHWND ), out rct ) )
            {
                lolRECT.X      = rct.Left;
                lolRECT.Y      = rct.Top;
                lolRECT.Width  = rct.Right  - rct.Left;
                lolRECT.Height = rct.Bottom - rct.Top;
            } else {
                MessageBox.Show( "GetWindowRect had an error" );
            }
        }

        private void fillTree( string s, List<Point> l )
        {
            int stringPOScounter = 0;

            foreach ( char c in s.ToCharArray() )
            {
                int ammount = Convert.ToInt32( c.ToString() );
                if ( ammount > 0 )
                {
                    Point p = l[stringPOScounter];
                    int   x = lolRECT.X + p.X;
                    int   y = lolRECT.Y + p.Y;
                    for ( int i = 0; i < ammount; i++ )
                    {
                        mouseClick( x, y );
                        Thread.Sleep( ClickInterval );
                    }
                }
                stringPOScounter++;
            }
        }

        private bool buildStringDifferent( XmlNode n, string s )
        {
            string s2 = n.ChildNodes[0].InnerText + "\r\n" + n.ChildNodes[1].InnerText + "\r\n" + n.ChildNodes[2].InnerText;
            return !( s2 == s );
        }

        private void getPointData()
        {
            OffensePoints.Clear();
            DefensePoints.Clear();
            UtilityPoints.Clear();
            if ( loc == Pages.ProfilePage )
            {
                #region Offense Tree
                // row 1
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 0, ProfileOffenseOffset.Y + masteryHeightSpacer * 0 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 1, ProfileOffenseOffset.Y + masteryHeightSpacer * 0 ) );        
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 2, ProfileOffenseOffset.Y + masteryHeightSpacer * 0 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 3, ProfileOffenseOffset.Y + masteryHeightSpacer * 0 ) );
                // row 2
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 1, ProfileOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 2, ProfileOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 3, ProfileOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                // row 3
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 0, ProfileOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 1, ProfileOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 2, ProfileOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 3, ProfileOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                // row 4
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 0, ProfileOffenseOffset.Y + masteryHeightSpacer * 3 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 1, ProfileOffenseOffset.Y + masteryHeightSpacer * 3 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 2, ProfileOffenseOffset.Y + masteryHeightSpacer * 3 ) );
                // row 5
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 1, ProfileOffenseOffset.Y + masteryHeightSpacer * 4 ) );
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 2, ProfileOffenseOffset.Y + masteryHeightSpacer * 4 ) );
                // row 6
                OffensePoints.Add( new Point( ProfileOffenseOffset.X + masteryWidthSpacer * 1, ProfileOffenseOffset.Y + masteryHeightSpacer * 5 ) );
                #endregion

                #region Defense Tree
                // row 1
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 0, ProfileDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 1, ProfileDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 2, ProfileDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 3, ProfileDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                // row 2
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 1, ProfileOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 2, ProfileOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                // row 3
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 0, ProfileDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 1, ProfileDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 2, ProfileDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 3, ProfileDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                // row 4
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 0, ProfileDefenseOffset.Y + masteryHeightSpacer * 3 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 1, ProfileDefenseOffset.Y + masteryHeightSpacer * 3 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 2, ProfileDefenseOffset.Y + masteryHeightSpacer * 3 ) );
                // row 5
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 1, ProfileDefenseOffset.Y + masteryHeightSpacer * 4 ) );
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 2, ProfileDefenseOffset.Y + masteryHeightSpacer * 4 ) );
                // row 6
                DefensePoints.Add( new Point( ProfileDefenseOffset.X + masteryWidthSpacer * 1, ProfileDefenseOffset.Y + masteryHeightSpacer * 5 ) );
                #endregion

                #region Utility Tree
                // row 1
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 0, ProfileUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 1, ProfileUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 2, ProfileUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 3, ProfileUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                // row 2
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 1, ProfileUtilityOffset.Y + masteryHeightSpacer * 1 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 2, ProfileUtilityOffset.Y + masteryHeightSpacer * 1 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 3, ProfileUtilityOffset.Y + masteryHeightSpacer * 1 ) );
                // row 3
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 1, ProfileUtilityOffset.Y + masteryHeightSpacer * 2 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 2, ProfileUtilityOffset.Y + masteryHeightSpacer * 2 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 3, ProfileUtilityOffset.Y + masteryHeightSpacer * 2 ) );
                // row 4
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 1, ProfileUtilityOffset.Y + masteryHeightSpacer * 3 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 2, ProfileUtilityOffset.Y + masteryHeightSpacer * 3 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 3, ProfileUtilityOffset.Y + masteryHeightSpacer * 3 ) );
                // row 5
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 1, ProfileUtilityOffset.Y + masteryHeightSpacer * 4 ) );
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 2, ProfileUtilityOffset.Y + masteryHeightSpacer * 4 ) );
                // row 6
                UtilityPoints.Add( new Point( ProfileUtilityOffset.X + masteryWidthSpacer * 2, ProfileUtilityOffset.Y + masteryHeightSpacer * 5 ) );
                #endregion
            } else if ( loc == Pages.ChampionSelection ) {
                #region Offense Tree
                // row 1
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 0, ChampionOffenseOffset.Y + masteryHeightSpacer * 0 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 1, ChampionOffenseOffset.Y + masteryHeightSpacer * 0 ) );        
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 2, ChampionOffenseOffset.Y + masteryHeightSpacer * 0 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 3, ChampionOffenseOffset.Y + masteryHeightSpacer * 0 ) );
                // row 2
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 1, ChampionOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 2, ChampionOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 3, ChampionOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                // row 3
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 0, ChampionOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 1, ChampionOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 2, ChampionOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 3, ChampionOffenseOffset.Y + masteryHeightSpacer * 2 ) );
                // row 4
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 0, ChampionOffenseOffset.Y + masteryHeightSpacer * 3 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 1, ChampionOffenseOffset.Y + masteryHeightSpacer * 3 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 2, ChampionOffenseOffset.Y + masteryHeightSpacer * 3 ) );
                // row 5
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 1, ChampionOffenseOffset.Y + masteryHeightSpacer * 4 ) );
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 2, ChampionOffenseOffset.Y + masteryHeightSpacer * 4 ) );
                // row 6
                OffensePoints.Add( new Point( ChampionOffenseOffset.X + masteryWidthSpacer * 1, ChampionOffenseOffset.Y + masteryHeightSpacer * 5 ) );
                #endregion

                #region Defense Tree
                // row 1
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 0, ChampionDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 1, ChampionDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 2, ChampionDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 3, ChampionDefenseOffset.Y + masteryHeightSpacer * 0 ) );
                // row 2
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 1, ChampionOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 2, ChampionOffenseOffset.Y + masteryHeightSpacer * 1 ) );
                // row 3
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 0, ChampionDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 1, ChampionDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 2, ChampionDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 3, ChampionDefenseOffset.Y + masteryHeightSpacer * 2 ) );
                // row 4
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 0, ChampionDefenseOffset.Y + masteryHeightSpacer * 3 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 1, ChampionDefenseOffset.Y + masteryHeightSpacer * 3 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 2, ChampionDefenseOffset.Y + masteryHeightSpacer * 3 ) );
                // row 5
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 1, ChampionDefenseOffset.Y + masteryHeightSpacer * 4 ) );
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 2, ChampionDefenseOffset.Y + masteryHeightSpacer * 4 ) );
                // row 6
                DefensePoints.Add( new Point( ChampionDefenseOffset.X + masteryWidthSpacer * 1, ChampionDefenseOffset.Y + masteryHeightSpacer * 5 ) );
                #endregion

                #region Utility Tree
                // row 1
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 0, ChampionUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 1, ChampionUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 2, ChampionUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 3, ChampionUtilityOffset.Y + masteryHeightSpacer * 0 ) );
                // row 2
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 1, ChampionUtilityOffset.Y + masteryHeightSpacer * 1 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 2, ChampionUtilityOffset.Y + masteryHeightSpacer * 1 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 3, ChampionUtilityOffset.Y + masteryHeightSpacer * 1 ) );
                // row 3
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 1, ChampionUtilityOffset.Y + masteryHeightSpacer * 2 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 2, ChampionUtilityOffset.Y + masteryHeightSpacer * 2 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 3, ChampionUtilityOffset.Y + masteryHeightSpacer * 2 ) );
                // row 4
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 1, ChampionUtilityOffset.Y + masteryHeightSpacer * 3 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 2, ChampionUtilityOffset.Y + masteryHeightSpacer * 3 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 3, ChampionUtilityOffset.Y + masteryHeightSpacer * 3 ) );
                // row 5
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 1, ChampionUtilityOffset.Y + masteryHeightSpacer * 4 ) );
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 2, ChampionUtilityOffset.Y + masteryHeightSpacer * 4 ) );
                // row 6
                UtilityPoints.Add( new Point( ChampionUtilityOffset.X + masteryWidthSpacer * 2, ChampionUtilityOffset.Y + masteryHeightSpacer * 5 ) );
                #endregion
            } else {
                System.Windows.Forms.MessageBox.Show( "Something went wrong with getPointData()" );
                bgwColorChecker.Dispose();
                this.Dispose();
                System.Windows.Forms.Application.Exit();
            }
        }

        private void ResetPoints()
        {
            if ( loc == Pages.ProfilePage )
            {
                do
                {
                    setState( States.Hidden );
                    Thread.Sleep( 100 );
                } while ( this.Location.X != -32000 && this.Location.Y != -32000 );
                mouseClick( lolRECT.X + ProfileResetPoint.X, lolRECT.Y + ProfileResetPoint.Y );
                Thread.Sleep( 500 );
                setState( States.Visible );
            } else if ( loc == Pages.ChampionSelection ) {
                do
                {
                    setState( States.Hidden );
                    Thread.Sleep( 100 );
                } while ( this.Location.X != -32000 && this.Location.Y != -32000 );
                mouseClick( lolRECT.X + ChampionResetPoint.X, lolRECT.Y + ChampionResetPoint.Y );
                Thread.Sleep( 500 );
                setState( States.Visible );
            } 
        }

        private void SaveBuild()
        {
            if ( loc == Pages.ProfilePage )
            {
                do
                {
                    setState( States.Hidden );
                    Thread.Sleep( 100 );
                } while ( this.Location.X != -32000 && this.Location.Y != -32000 );
                mouseClick( lolRECT.X + ProfileSavePoint.X, lolRECT.Y + ProfileSavePoint.Y );
                Thread.Sleep( 500 );
                setState( States.Visible );
            } else if ( loc == Pages.ChampionSelection ) {
                do
                {
                    setState( States.Hidden );
                    Thread.Sleep( 100 );
                } while ( this.Location.X != -32000 && this.Location.Y != -32000 );
                Thread.Sleep( 500 );
                mouseClick( lolRECT.X + ChampionSavePoint.X, lolRECT.Y + ChampionSavePoint.Y );
            }
        }

        private void setState( States state )
        {
            if ( currentState != state )
            {
                switch ( state )
                {
                    case States.Hidden:
                        WindowState = FormWindowState.Minimized;
                        this.Visible = false;
                        Hide();
                        currentState = States.Hidden;
                        logCase(0, "Hide Window");
                        break;
                    case States.Visible:
                        Show();
                        this.Visible = true;
                        WindowState = FormWindowState.Normal;
                        currentState = States.Visible;
                        logCase(1, "Window Visible");
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show( "Something went wrong with the setState function!" );
                        break;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            //stateToolStripMenuItem.Text = "currentState - " + currentState  + "\r\nstate - " + state;
        }

        private void gatherBuildData()
        {
            foreach( XmlNode n in root )
            {
                lbBuilds.Items.Add( n.Attributes.Item(0).InnerText );
            }
        }

        private bool checkDataString( string s )
        {
            bool r = true;
            string Offense = "";
            string Defense = "";
            string Utility = "";

            List<string> list = new List<string>();
            list.Add( Offense );
            list.Add( Defense );
            list.Add( Utility );

            try {Offense = newlineRegex.Split(s)[0];} catch {r = false;}
            try {Defense = newlineRegex.Split(s)[1];} catch {r = false;}
            try {Utility = newlineRegex.Split(s)[2];} catch {r = false;}

            if ( Offense.Length != 17 ) r = false;
            if ( Defense.Length != 16 ) r = false;
            if ( Utility.Length != 16 ) r = false;

            char[] c;
            foreach ( string s2 in list )
            {
                c = s2.ToCharArray();
                foreach ( char c2 in c )
                {
                    try   { Convert.ToInt32( c2.ToString() ); }
                    catch { r = false; }
                } 
            }
            return r;
        }

        private string getUniqueName( string s, XmlDocument doc )
        {
            bool unique = false;
            XmlNode node = doc.DocumentElement.SelectSingleNode("//Build[@Name='" + s + "']");
            if ( node != null )
            {
                do
                {
                    s += " Copy";
                    node = doc.DocumentElement.SelectSingleNode("//Build[@Name='" + s + "']");
                    if ( node == null )
                    {
                        unique = true;
                    }
                } while ( unique == false );
            }
            return s;
        }

        private void mouseClick( int x, int y )
        {
            Cursor.Position = new Point ( x, y );
            Thread.Sleep( ClickSleepInverval );
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, (IntPtr)0, (IntPtr)0);
            mouse_event(MOUSEEVENTF_LEFTUP,   x, y, (IntPtr)0, (IntPtr)0);
        }

        private Color GetPixelColor( IntPtr HWND, int x, int y )
        {
            Color color = Color.Empty;
            if (HWND != null)
            {
                IntPtr hDC = GetDC( HWND );
                int colorRef = GetPixel( hDC, x, y );
                color = Color.FromArgb(
                    (int)(colorRef & 0x000000FF),
                    (int)(colorRef & 0x0000FF00) >> 8,
                    (int)(colorRef & 0x00FF0000) >> 16 );
                ReleaseDC( HWND, hDC );
            }
            return color;
        }

        private void setupXML()
        {
            string p = System.IO.Directory.GetCurrentDirectory();
            StreamWriter wstream;
            try { wstream = new StreamWriter( p + "\\Data\\Builds.xml", false, Encoding.UTF8 ); }
            catch 
            { 
                Directory.CreateDirectory( p + "\\Data" ); 
                wstream = new StreamWriter( p + "\\Data\\Builds.xml", false, Encoding.UTF8 ); 
            }
            wstream.WriteLine( @"<?xml version=""1.0"" encoding=""utf-8""?>" );
            wstream.WriteLine( "   <Builds>" );
            wstream.WriteLine( "   </Builds>" );
            wstream.Flush();
            wstream.Close();
        }

        private void OptSetupXML()
        {
            string p = System.IO.Directory.GetCurrentDirectory();
            StreamWriter wstream = new StreamWriter( p + "\\Data\\Options.xml", false, Encoding.UTF8 );
            wstream.WriteLine( @"<?xml version=""1.0"" encoding=""utf-8""?>" );
            wstream.WriteLine( "<!-- You will need to restart the program for these settings to go into effect. -->" );
            wstream.WriteLine( "<!-- Don't modify, unless you know what you are doing. -->" );
            wstream.WriteLine( "<!-- I'll not be held responsible for anything that goes wrong, if you change stuff. -->" );
            wstream.WriteLine( "<Options>" );
            wstream.WriteLine( "   <!-- The time in milliseconds between sending mouse clicks. -->" );
            wstream.WriteLine( "   <ClickInterval>50</ClickInterval>" );
            wstream.WriteLine( "" );
            wstream.WriteLine( "   <!-- The time in milliseconds between moving the cursor, and sending the clicks. (time for the last mastery description to go away) -->" );
            wstream.WriteLine( "   <MouseMovePause>50</MouseMovePause>" );
            wstream.WriteLine( "" );
            wstream.WriteLine( "   <!-- The time in milliseconds between checks for a league of legends window. -->" );
            wstream.WriteLine( "   <!-- No real need to modify this, just here for people who want to dink with it.. -->" );
            wstream.WriteLine( "   <LeagueSearchTimer>5000</LeagueSearchTimer>" );
            wstream.WriteLine( "" );
            wstream.WriteLine( "   <!-- The time in milliseconds between checks to determine whether or not to hide the program. -->" );
            wstream.WriteLine( "   <!-- 75 is a good amount to look nice, lower if your pc isn't all that great. Work your way up from the 75. -->" );
            wstream.WriteLine( "   <ModifyingTimer>100</ModifyingTimer>" );
            wstream.WriteLine( "</Options>" );
            wstream.Flush();
            wstream.Close();
        }

        private void LoadSettings()
        {
            string oClickInterval     = OptDoc.DocumentElement.SelectSingleNode( "ClickInterval"     ).InnerText;
            string oMouseMovePause    = OptDoc.DocumentElement.SelectSingleNode( "MouseMovePause"    ).InnerText;
            string oLeagueSearchTimer = OptDoc.DocumentElement.SelectSingleNode( "LeagueSearchTimer" ).InnerText;
            string oModifyingTimer    = OptDoc.DocumentElement.SelectSingleNode( "ModifyingTimer"    ).InnerText;
            ClickInterval        = Convert.ToInt32( oClickInterval );
            ClickSleepInverval   = Convert.ToInt32( oMouseMovePause );
            LeagueSearchInverval = Convert.ToInt32( oLeagueSearchTimer );
            ModifySearchInverval = Convert.ToInt32( oModifyingTimer );
        }
        #endregion
    }
}