using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads
{
    public partial class Hud : Form
    {


        public Hud()
        {
            InitializeComponent();
        }
        private string _tituloventana;
        private string _jugador;
        private int _numJugador;
        private String _jugadoresMesa;

        public string Tituloventana { get => _tituloventana; set => _tituloventana = value; }
        public string Jugador { get => _jugador; set => _jugador = value; }
        public int NumJugador { get => _numJugador; set => _numJugador = value; }
        public string JugadoresMesa { get => _jugadoresMesa; set => _jugadoresMesa = value; }

        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;
        private const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;

        private const uint EVENT_SYSTEM_MOVESIZESTART = 0x000A;
        private const uint EVENT_SYSTEM_MOVESIZEEND = 0x000B;
        private const uint EVENT_OBJECT_DESTROY = 0x8001;
        private WinEventDelegate dele = null;
        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);


        private  void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (eventType == EVENT_SYSTEM_MOVESIZEEND)
            {
                mover();
                Debug.WriteLine("EVENT_SYSTEM_MOVESIZEEND");
            }
            else if (eventType == EVENT_OBJECT_DESTROY)
            {
                if (IntPtr.Zero == NativeMethods.FindWindow(null, Tituloventana))
                {
                    this.Close();
                    Debug.WriteLine("EVENT_SYSTEM_MOVESIZEEND");
                }

            }


            Console.WriteLine(eventType.ToString());


        }

        //private void WindowEventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        //{
        //    if (eventType == EVENT_SYSTEM_MOVESIZESTART)
        //    {
        //        mover();
        //        Debug.WriteLine("EVENT_SYSTEM_MOVESIZESTART");
        //    }
        //    else if (eventType == EVENT_SYSTEM_MOVESIZEEND)
        //    {
        //        mover();
        //        Debug.WriteLine("EVENT_SYSTEM_MOVESIZEEND");
        //    }
        //    else if (eventType == EVENT_OBJECT_DESTROY)
        //    {
        //        if (IntPtr.Zero == NativeMethods.FindWindow(null, Tituloventana))
        //        {
        //            this.Close();
        //            Debug.WriteLine("EVENT_SYSTEM_MOVESIZEEND");
        //        }

        //    }


        //    Console.WriteLine(eventType.ToString());
        //}
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        static class NativeMethods
        {


            [DllImport("user32.dll")]
            public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
            //[DllImport("user32.dll", SetLastError = true)]
            //public static extern IntPtr SetWinEventHook(int eventMin, int eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, int idProcess, int idThread, int dwflags);
            //public delegate void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
            [DllImport("user32.dll")]
            public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
            [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
            public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
            [DllImport("user32.dll", EntryPoint = "FindWindowA")]
            public static extern IntPtr FindWindow(string sClass, string sWindow);
            [DllImport("user32.dll")]
            public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        IntPtr hwnd;

        uint processID = 0;

        IntPtr hhook = IntPtr.Zero;
        public void car()
        {


            hwnd = NativeMethods.FindWindow(null, Tituloventana);
            GetWindowThreadProcessId(hwnd, out processID);
            dele = new WinEventDelegate(WinEventProc);
            hhook = NativeMethods.SetWinEventHook(EVENT_SYSTEM_MOVESIZESTART, EVENT_OBJECT_DESTROY, IntPtr.Zero, dele, (uint)processID, (uint)0, WINEVENT_OUTOFCONTEXT);
            //hhook = NativeMethods.SetWinEventHook((int)EVENT_SYSTEM_MOVESIZESTART, (int)EVENT_OBJECT_DESTROY, IntPtr.Zero, WindowEventCallback, (int)processID, (int)0,(int) WINEVENT_OUTOFCONTEXT);
            mover();


        }
        public void unhook()
        {
            NativeMethods.UnhookWinEvent(hhook);
            dele = null;
            Debug.WriteLine("unhook");
            this.Close();
        }

        public void mover()
        {
            Rect move = new Rect();
            NativeMethods.GetWindowRect(hwnd, ref move);
            Formularios f = new Formularios();
            f.posicionformbynumjugador(NumJugador, JugadoresMesa);

            this.Left = move.Left + (Convert.ToInt32(f.DataTable.Rows.Count == 0 ? 0 : Convert.ToInt32(f.DataTable.Rows[0][0])));
            this.Top = move.Top + (Convert.ToInt32(f.DataTable.Rows.Count == 0 ? 0 : Convert.ToInt32(f.DataTable.Rows[0][1])));
            NativeMethods.SetWindowLong(this.Handle, -8 /*GWL_HWNDPARENT*/, hwnd);
        }



        private void Form2_Load_1(object sender, EventArgs e)
        {

            car();
            estadisticas();
            label1.Text = Jugador;
        }


        private void estadisticas()
        {
            //Label cbet = new Label();
            ManosCash m = new ManosCash();
            m.cbet(Jugador);
            if (m.DataTable.Rows.Count == 0)
            {
                this.label2.Text = "-";
            }
            else
            {
                this.label2.Text = m.DataTable.Rows[0][0].ToString();
            }


        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Hud_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                Formularios F = new Formularios();
                Rect move = new Rect();
                //hwnd = NativeMethods.FindWindow(null, Tituloventana);
                NativeMethods.GetWindowRect(hwnd, ref move);
                F.updateFormulario(NumJugador, (int)Hud.MousePosition.X - move.Left, (int)Hud.MousePosition.Y - move.Top, JugadoresMesa);
                //label2.Text = "x:" + Hud.MousePosition.X.ToString() + "y:" + Hud.MousePosition.Y.ToString();
            }
        }

        private void Hud_FormClosing(object sender, FormClosingEventArgs e)
        {
            unhook();
        }
    }
}
