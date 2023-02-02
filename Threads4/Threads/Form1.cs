using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunFileSystemWatcher();
            //LeerFicheroCashWX leerFicheroCashWX = new LeerFicheroCashWX();

            //System.IO.StreamReader reader = new System.IO.StreamReader("C:/Users/Gaming/Documents/winamax3.txt");
            //reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            //leerFicheroCashWX.leerficheroCash(reader, "C:/Users/Gaming/Documents/winamax3.txt");
            //Formularios f = new Formularios();
            //f.createTempTable("hola");
            //f.addPKey("hola");
            //f.insertDatos("hola");
            //DataTable dt = f.executeSelectTabla("hola");
        }
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public void RunFileSystemWatcher()
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = "C:/Users/Gaming/AppData/Local/PokerStars.ES/HandHistory/arruchador1";
            fsw.NotifyFilter = NotifyFilters.LastAccess;
            fsw.NotifyFilter = NotifyFilters.LastWrite; 
            //fsw.NotifyFilter = NotifyFilters.Size;

            //fsw.Created += FileSystemWatcher_Created;
            fsw.Changed += FileSystemWatcher_ChangedPokerStars;
            fsw.Filter = "*.txt";
            fsw.EnableRaisingEvents = true;

            FileSystemWatcher fsw2 = new FileSystemWatcher();
            fsw2.Path = "C:/Users/Gaming/AppData/Roaming/wames.04351C371E530C3762CBA45FA283ED972DCDEFB6.1/Local Store/documents/accounts/arruchador1/history";
            fsw2.NotifyFilter = NotifyFilters.LastAccess;
            fsw2.NotifyFilter = NotifyFilters.LastWrite;
            //fsw.NotifyFilter = NotifyFilters.Size;

            //fsw.Created += FileSystemWatcher_Created;
            fsw2.Changed += FileSystemWatcher_ChangedWinamax;
            fsw2.Filter = "*.txt";
            fsw2.EnableRaisingEvents = true;

        }

        private void FileSystemWatcher_ChangedWinamax(object sender, FileSystemEventArgs e)
        {
            
            if (e.FullPath.Replace("\\","/").IndexOf("real_holdem_no-limit.txt")!=-1)
            {
                leerFicheroCashWX(e);
                hilosEjecucionyPasarParametrosHudWX(e);
            }
            else if (char.IsNumber(e.FullPath.Replace("\\","/")[e.FullPath.Replace("\\","/").Length - 5]))
            {
                leerFicheroTorneo(e);
                hilosEjecucionyPasarParametrosHudWX(e);
            }
        }

        private void FileSystemWatcher_ChangedPokerStars(object sender, FileSystemEventArgs e)
        {
           
                //comprobacion si cash o torneo
                if (e.FullPath.Replace("\\","/")[e.FullPath.Replace("\\","/").Length - 5] == 'm')
                {
                    leerFicheroCashPS(e);
                    hilosEjecucionyPasarParametrosHudPS(e);
                }
                else if(char.IsNumber(e.FullPath.Replace("\\","/")[e.FullPath.Replace("\\","/").Length - 5]))
                {
                    leerFicheroTorneo(e);
                    hilosEjecucionyPasarParametrosHudPS(e);
                }
        }
        private void leerFicheroCashPS(FileSystemEventArgs e)
        {
            ResumenCash re = new ResumenCash();
            //leer fichero
            System.IO.StreamReader reader = new System.IO.StreamReader(e.FullPath.Replace("\\","/"));
            // reader.DiscardBufferedData();
            String tamanio="0";
            if (re.txtmaxtamaniobytxt(e.FullPath.Replace("\\","/")).Rows.Count != 0)
            {
                tamanio = re.txtmaxtamaniobytxt(e.FullPath.Replace("\\","/")).Rows[0][0].ToString();
            }
           
            reader.BaseStream.Seek(tamanio == "" ? 0 : tamanio == null ? 0 : Convert.ToInt64(tamanio), System.IO.SeekOrigin.Begin);
            LeerFicheroCashPS fichero = new LeerFicheroCashPS();
            fichero.leerficheroCash(reader, e.FullPath.Replace("\\","/"));
            reader.Close();
        }
        private void leerFicheroCashWX(FileSystemEventArgs e)
        {
            ResumenCash re = new ResumenCash();
            //leer fichero
            System.IO.StreamReader reader = new System.IO.StreamReader(e.FullPath.Replace("\\","/"));
            // reader.DiscardBufferedData();
            String tamanio = "0";
            string ruta = e.FullPath.Replace("\\","/").Replace(Convert.ToChar(92), '/').Replace("\\", "/");
            if (re.txtmaxtamaniobytxt(ruta).Rows.Count != 0)
            {
                tamanio = re.txtmaxtamaniobytxt(ruta).Rows[0][0].ToString();
            }

            reader.BaseStream.Seek(tamanio == "" ? 0 : tamanio == null ? 0 : Convert.ToInt64(tamanio), System.IO.SeekOrigin.Begin);
            LeerFicheroCashWX fichero = new LeerFicheroCashWX();
            fichero.leerficheroCash(reader, ruta);
            reader.Close();
        }
        private void leerFicheroTorneo(FileSystemEventArgs e)
        {
            ResumenTorneo re = new ResumenTorneo();
            //leer fichero
            System.IO.StreamReader reader = new System.IO.StreamReader(e.FullPath.Replace("\\","/"));
            // reader.DiscardBufferedData();
            String tamanio = "0";
            if (re.txtmaxtamaniobytxt(e.FullPath.Replace("\\","/")).Rows.Count != 0)
            {
                tamanio = re.txtmaxtamaniobytxt(e.FullPath.Replace("\\","/")).Rows[0][0].ToString();
            }

            reader.BaseStream.Seek(tamanio == "" ? 0 : tamanio == null ? 0 : Convert.ToInt64(tamanio), System.IO.SeekOrigin.Begin);
            LeerFicheroTorneoPS fichero = new LeerFicheroTorneoPS();
            fichero.leerficheroTorneo(reader, e.FullPath.Replace("\\","/"));
            reader.Close();
        }
        private Dictionary<string, List<AbortableBackgroundWorker>> listaHilos = new Dictionary<string, List<AbortableBackgroundWorker>>();
       
        private void hilosEjecucionyPasarParametrosHudPS(FileSystemEventArgs e)
        {
            String nombreVentana = extraerNombreVentanaPS(e);
                if (listaHilos.ContainsKey(nombreVentana))
                {
                    listaHilos.TryGetValue(nombreVentana, out List<AbortableBackgroundWorker> value);
                    for (int i=0; i<value.Count-1; i++)
                    {
                        try
                        {
                       
                        Invoke((MethodInvoker)delegate {
                            listaHuds[i].unhook();
                            listaHuds[i].Close();
                        });

                            value[i].Abort();
                            value[i].Dispose();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                       
                    }
                    listaHilos.Remove(nombreVentana);
                }
                ResumenCash r = new ResumenCash();
            String jugadoresMesa="6-max";
            if (r.jugadoresmesaresumenbytxt(e.FullPath.Replace("\\","/")).Rows.Count != 0)
            {
                //jugadoresMesa = r.jugadoresmesaresumenbytxt(e.FullPath.Replace("\\","/")).Rows[0][0].ToString();
            }
                
                List<AbortableBackgroundWorker> listaThread = new List<AbortableBackgroundWorker>();
                
                Dictionary<int, String> jugadores = ordenarJugadoresPS(e.FullPath.Replace("\\","/"));
              
                foreach (KeyValuePair<int, string> jugador in jugadores)
                {
                   
                    if (jugador.Value != null)
                    {
                    
                    AbortableBackgroundWorker worker = new AbortableBackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                    worker.WorkerSupportsCancellation = true;
                    Object[] parametros = new Object[5];
                    parametros[0] = new Hud();
                    parametros[1] = jugador.Value;
                    parametros[2] = nombreVentana;
                    parametros[3] = jugador.Key;
                    parametros[4] = jugadoresMesa;

                    worker.RunWorkerAsync(parametros);
                    listaThread.Add(worker);

                    }
                    
                }

                listaHilos.Add(nombreVentana, listaThread);            

                
            
            }
        private void hilosEjecucionyPasarParametrosHudWX(FileSystemEventArgs e)
        {
            String nombreVentana = extraerNombreVentanaWX(e);
            if (listaHilos.ContainsKey(nombreVentana))
            {
                listaHilos.TryGetValue(nombreVentana, out List<AbortableBackgroundWorker> value);
                for (int i = 0; i < value.Count; i++)
                {
                    try
                    {

                        this.Invoke((MethodInvoker)delegate {
                            listaHuds[i].unhook();
                        });

                        value[i].Abort();
                        value[i].Dispose();
                    }
                    catch (ThreadAbortException)
                    {

                    }

                }
                listaHilos.Remove(nombreVentana);
            }
            ResumenCash r = new ResumenCash();
            String jugadoresMesa = "5-max";
            string ruta = e.FullPath.Replace("\\","/").Replace(Convert.ToChar(92), '/').Replace("\\", "/");
            if (r.jugadoresmesaresumenbytxt(ruta).Rows.Count != 0)
            {
                jugadoresMesa = r.jugadoresmesaresumenbytxt(ruta).Rows[0][0].ToString();
            }

            List<AbortableBackgroundWorker> listaThread = new List<AbortableBackgroundWorker>();

            Dictionary<int, String> jugadores = ordenarJugadoresWX(ruta);
            //create temporary table
            foreach (KeyValuePair<int, string> jugador in jugadores)
            {

                if (jugador.Value != null)
                {

                    AbortableBackgroundWorker worker = new AbortableBackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                    worker.WorkerSupportsCancellation = true;
                    Object[] parametros = new Object[5];
                    parametros[0] = new Hud();
                    parametros[1] = jugador.Value;
                    parametros[2] = nombreVentana;
                    parametros[3] = jugador.Key;
                    parametros[4] = jugadoresMesa;

                    worker.RunWorkerAsync(parametros);
                    listaThread.Add(worker);

                }

            }

            listaHilos.Add(nombreVentana, listaThread);



        }
        List<Hud> listaHuds = new List<Hud>();
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           Object[] obj= (Object[])e.Argument;
            Hud jugador = (Hud)obj[0];
            jugador.Jugador = obj[1].ToString();
            jugador.Tituloventana = obj[2].ToString();
            jugador.NumJugador = (int)obj[3];
            jugador.JugadoresMesa = obj[4].ToString();
            listaHuds.Add(jugador);

            jugador.ShowDialog();
            //Application.Run(jugador);
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            StringBuilder strbTitle = new StringBuilder(MAXTITLE);
            int nLength = _GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
            strbTitle.Length = nLength;
            return strbTitle.ToString();
        }
        const int MAXTITLE = 255;
        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
       ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop,
       EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowText",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int _GetWindowText(IntPtr hWnd,
        StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);
        private static bool EnumWindowsProc(IntPtr hWnd, int lParam)
        {
            string strTitle = GetWindowText(hWnd);
            if (strTitle != "" & IsWindowVisible(hWnd)) //
            {
                lstTitles.Add(strTitle);
            }
            return true;
        }
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);
        private static List<string> lstTitles;
        private String extraerNombreVentanaPS(FileSystemEventArgs e)
        {
            int i = 0;
            String nombre = "";
            while ((e.FullPath.Replace("\\","/"))[i] != ' ')
            {
                i++;
            }
            i++;
            while ((e.FullPath.Replace("\\","/"))[i] != ' ')
            {
                nombre += (e.FullPath.Replace("\\","/"))[i];
                i++;
            }
            string[] strWindowsTitles = GetDesktopWindowsTitles();
            //int num = strWindowsTitles.Count() - 1;
            foreach (string strTitle in strWindowsTitles)
            {
                //if (!ventanas.Contains(strTitle) && strTitle.IndexOf(nombre) != -1)
                if (strTitle.IndexOf("Bloc") != -1)
                {

                    return strTitle;
                }
            }
            return null;
        }
        private String extraerNombreVentanaWX(FileSystemEventArgs e)
        {
            int i = 0;
            String nombre = "";
            string ruta = e.Name.Replace(Convert.ToChar(92), '/').Replace("\\", "/");
            while ((ruta)[i] != '_')
            {
                i++;
            }
            i++;
            // while ((ruta)[i] != ' ' && (ruta)[i] != '_')
            while ((ruta)[i] != '_')
            {
                nombre += (ruta)[i];
                i++;
            }
            string[] strWindowsTitles = GetDesktopWindowsTitles();
            //int num = strWindowsTitles.Count() - 1;
            foreach (string strTitle in strWindowsTitles)
            {
                //if (!ventanas.Contains(strTitle) && strTitle.IndexOf(nombre) != -1)
                // if (strTitle.IndexOf(nombre) != -1)
                if (strTitle.IndexOf("Bloc") != -1)
                {

                    return strTitle;
                }
            }
            return null;
        }
        private static string[] GetDesktopWindowsTitles()
        {
            lstTitles = new List<string>();
            EnumDelegate delEnumfunc = new EnumDelegate(EnumWindowsProc);
            bool bSuccessful = EnumDesktopWindows(IntPtr.Zero, delEnumfunc, IntPtr.Zero); //for current desktop

            if (bSuccessful)
            {
                return lstTitles.ToArray();
            }
            else
            {
                // Get the last Win32 error code
                int nErrorCode = Marshal.GetLastWin32Error();
                string strErrMsg = String.Format("EnumDesktopWindows failed with code {0}.", nErrorCode);
                throw new Exception(strErrMsg);
            }
        }
        
       
        //private void mostarHud(Hud jugador, string nombreJugador, string strTitle, int numJugador,String jugadoresMesa)
        //{
        //    jugador.Jugador = nombreJugador;
        //    jugador.Tituloventana = strTitle;
        //    jugador.NumJugador = numJugador;
        //    jugador.JugadoresMesa = jugadoresMesa;            
        //    listaHuds.Add(jugador);
        //    jugador.ShowDialog();
            


        //}
        
        private Dictionary<int, String> ordenarJugadoresPS(String txt)
        {
            ResumenCash r = new ResumenCash();
            String[] aux = new String[6];
            r.asientosByTxt(txt.Replace("\\", "/"));
            foreach (DataRow dr in r.DataTable.Rows)
            {
                aux[(int)dr[2] - 1] = dr[1].ToString();
            }
            r.posicionHeroByTxt(txt.Replace("\\", "/"));
            //Console.WriteLine(r.DataTable.Rows[0][0] == null ? 0 : Convert.ToInt32(r.DataTable.Rows[0][0]));
            int posicionHero = 0;
            Dictionary<int,String> listaJugadores = new Dictionary<int, string>();
            
            int x = 0;
            for (int i = posicionHero; i < aux.Length; i++)
            {
                listaJugadores.Add(x+1,aux[i]);
                x = x + 1;
            }
            for (int t = 0; t < posicionHero - 1; t++)
            {
                x = x + 1;
                listaJugadores.Add(x,aux[t]);
                
            }
            if (posicionHero != 0) {
                listaJugadores.Add(x + 1, aux[posicionHero - 1]);
            }
           
            return listaJugadores;
        }
        private Dictionary<int, String> ordenarJugadoresWX(String txt)
        {
            ResumenCash r = new ResumenCash();
            String[] aux = new String[6];
            Dictionary<int, String> listaJugadores = new Dictionary<int, string>();
            r.asientosByTxt(txt.Replace("\\", "/"));
            foreach (DataRow dr in r.DataTable.Rows)
            {
                listaJugadores.Add((int)dr[2], dr[1].ToString());
            }
           

            return listaJugadores;
        }







        private void Form1_Load(object sender, EventArgs e)
    {
           

    }

        

    }

    

    public class AbortableBackgroundWorker : BackgroundWorker
    {

        private Thread workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true; //We must set Cancel property to true!
                Thread.ResetAbort(); //Prevents ThreadAbortException propagation
            }
        }


        public void Abort()
        {
            if (workerThread != null)
            {
                workerThread.Abort();
                workerThread = null;
            }
        }
    }
    

}
