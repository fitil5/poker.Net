using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class LeerFicheroTorneoPS
    {
        string fichero;
        string ruta;

        public void CargaDeParametros(string fichero, string ruta)
        {
            this.ruta = ruta;
            this.fichero = fichero;
        }
        public List<string> f = new List<string>();
        public void ficherosCash(string rutaCarpeta)
        {

            foreach (String foundFile in System.IO.Directory.GetFiles(rutaCarpeta))
            {

                string ca = foundFile;
                int l = ca.Length - 1;


                if (ca[l - 4] == 'm')
                {
                    f.Add(Convert.ToString(ca));
                }
            }

        }
        public void recorrerlist()
        {
            int len = f.Count;

            // For i = 0 To len
            // txt = f(i)
            // leerfichero(txt)
            // Next
            //for (int i = 0; i < len; i++)
            // {
            //txt = f[i];
            //leerfichero(txt);

            // }

           // foreach (string txt in f)
                // txt = f(0)
                //leerfichero(txt.Replace(Convert.ToChar(92), '/'));
            //leerfichero("prueba.txt");
            //leerfichero(" C:\Users\Gaming\AppData\Local\PokerStars.ES\HandHistory\arruchador1\HH20180224 Arneb #2 - €0.01-€0.02 - EUR No Limit Hold'em.txt")
        }
        static bool IsNumeric(string value)

        {

            try

            {

                char[] chars = value.ToCharArray();

                foreach (char c in chars)

                {

                    if (!char.IsNumber(c))

                        return false;

                }

                return true;
            }

            catch (Exception ex) { return false; }

        }
        private string seat1 = "";
        private string seat2 = "";
        private string seat3 = "";
        private string seat4 = "";
        private string seat5 = "";
        private string seat6 = "";
        private string seat7 = "";
        private string seat8 = "";
        private string seat9 = "";
        private string seat1startingchips = "";
        private string seat2startingchips = "";
        private string seat3startingchips = "";
        private string seat4startingchips = "";
        private string seat5startingchips = "";
        private string seat6startingchips = "";
        private string seat7startingchips = "";
        private string seat8startingchips = "";
        private string seat9startingchips = "";
        private Decimal seat1chips;
        private Decimal seat2chips;
        private Decimal seat3chips;
        private Decimal seat4chips;
        private Decimal seat5chips;
        private Decimal seat6chips;
        private Decimal seat7chips;
        private Decimal seat8chips;
        private Decimal seat9chips;
        private string position = "";
        int seat1raise = 0;
        int seat2raise = 0;
        int seat3raise = 0;
        int seat4raise = 0;
        int seat5raise = 0;
        int seat6raise = 0;
        int seat7raise = 0;
        int seat8raise = 0;
        int seat9raise = 0;
        decimal seat1cant = 0;
        decimal seat2cant = 0;
        decimal seat3cant = 0;
        decimal seat4cant = 0;
        decimal seat5cant = 0;
        decimal seat6cant = 0;
        decimal seat7cant = 0;
        decimal seat8cant = 0;
        decimal seat9cant = 0;

        private Decimal mpot = 0;
        private string seat1win = "";
        private string seat2win = "";
        private string seat3win = "";
        private string seat4win = "";
        private string seat5win = "";
        private string seat6win = "";
        private string pot = "";
        private string rake = "";
        //public List<string> f = new List<string>();
        public StreamReader reader;
        private string txt;
        private string str;
        private string herocards;
        private string rutaCarpeta = @"C:\Users\Gaming\AppData\Local\PokerStars.ES\HandHistory\arruchador1\";
        int y;
        public void leerficheroTorneo(StreamReader reader,String txt)
        {
            ManosTorneo m = new ManosTorneo();
            CartasTorneo c = new CartasTorneo();
            FichasTorneo f = new FichasTorneo();
            ResumenTorneo r = new ResumenTorneo();
            AsientosTorneo a = new AsientosTorneo();
            //reader = new StreamReader(txt);
            string tablename = "";
            string cant = "";
 
            string tipo = "";
            var round = 1;
            // Dim idhand = ""
            var stake = "";
            var fecha = "";
            int cha;
            var board = "";
            var rake = "";
            mpot = 0;
            cha = 0;
            while (!reader.EndOfStream)
            {
                var idhand = ""; // aqui
                                 // str = reader.ReadLine
                while (Convert.ToChar(cha) != '#')
                    cha = reader.Read();
                cha = reader.Read();
                while (Convert.ToChar(cha) != ':')
                {
                    idhand = idhand + Convert.ToChar(cha);
                    cha = reader.Read();
                }
                // idhand = str.Substring(22, str.IndexOf(":") - str.IndexOf("#") - 1)
                while (Convert.ToChar(cha) != '(')
                    cha = reader.Read();
                // cha = reader.Read
                stake = "";
                while (Convert.ToChar(cha) != ')')
                {
                    // cha = reader.Read
                    if (IsNumeric(Convert.ToString(Convert.ToChar(cha))) || Convert.ToChar(cha) == '.' || Convert.ToChar(cha) == '/')
                        stake = stake + Convert.ToChar(cha);
                    cha = reader.Read();
                }
                cha = reader.Read();
                cha = reader.Read();
                cha = reader.Read();
                cha = reader.Read();
                while (Convert.ToChar(cha) != 'C')
                {
                    // cha = reader.Read
                    if (IsNumeric(Convert.ToString(Convert.ToChar(cha))) | Convert.ToChar(cha) == ':' | Convert.ToChar(cha) == '/' | Convert.ToChar(cha) == ' ')
                        fecha = fecha + Convert.ToChar(cha);
                    cha = reader.Read();
                }

                // stake = str.Substring(str.IndexOf("€") + 1, str.IndexOf(")") - str.IndexOf("€") - 1).Replace("€", "")
                // fecha = str.Substring(str.IndexOf("-") + 2, (str.IndexOf("C") - 2) - str.IndexOf("-"))
                while (Convert.ToChar(cha) != Convert.ToChar("'"))
                    cha = reader.Read();
                cha = reader.Read();
                // cha = reader.Read
                tablename = "";
                while (Convert.ToChar(cha) != Convert.ToChar("'"))
                {
                    tablename = tablename + Convert.ToChar(cha); // table name
                    cha = reader.Read();
                }
                cha = reader.Read();
                cha = reader.Read();
                String jugadoresMesa = "";
                while (Convert.ToChar(cha)!=' ')
                {
                    jugadoresMesa = jugadoresMesa + Convert.ToChar(cha);
                        cha = reader.Read();
                }
                
                while (Convert.ToChar(cha) != '#')

                    // tablename = tablename & Convert.ToChar(cha) 'table name
                    cha = reader.Read();
                cha = reader.Read();
                var buttonpos = Convert.ToChar(cha);
                str = reader.ReadLine();
                str = reader.ReadLine();

                // restablecer poner null?
                seat1 = "";
                seat2 = "";
                seat3 = "";
                seat4 = "";
                seat5 = "";
                seat6 = "";
                seat7 = "";
                seat8 = "";
                seat9 = "";
                seat1startingchips = "";
                seat2startingchips = "";
                seat3startingchips = "";
                seat4startingchips = "";
                seat5startingchips = "";
                seat6startingchips = "";
                seat7startingchips = "";
                seat8startingchips = "";
                seat9startingchips = "";
                var seat1cards = "";
                var seat2cards = "";
                var seat3cards = "";
                var seat4cards = "";
                var seat5cards = "";
                var seat6cards = "";
                var seat7cards = "";
                var seat8cards = "";
                var seat9cards = "";
                seat1raise = 0;
                seat2raise = 0;
                seat3raise = 0;
                seat4raise = 0;
                seat5raise = 0;
                seat6raise = 0;
                seat7raise = 0;
                seat8raise = 0;
                seat9raise = 0;
                seat1cant = 0;
                seat2cant = 0;
                seat3cant = 0;
                seat4cant = 0;
                seat5cant = 0;
                seat6cant = 0;
                seat7cant = 0;
                seat8cant = 0;
                seat9cant = 0;


                var players = 0;

                while (str.Substring(str.Length - 2, 1) == ")")
                {
                    switch (Convert.ToInt32(str.Substring(5, 1)))
                    {
                        case 1:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat1startingchips = str.Substring(str.Length - y, 1) + seat1startingchips;
                                    y = y + 1;
                                }
                                seat1chips = Convert.ToDecimal(seat1startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat1 = str.Substring(str.Length - y, 1) + seat1;
                                    y = y + 1;
                                }

                                break;
                            }

                        case 2:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat2startingchips = str.Substring(str.Length - y, 1) + seat2startingchips;
                                    y = y + 1;
                                }
                                seat2chips = Convert.ToDecimal(seat2startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat2 = str.Substring(str.Length - y, 1) + seat2;
                                    y = y + 1;
                                }

                                break;
                            }

                        case 3:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat3startingchips = str.Substring(str.Length - y, 1) + seat3startingchips;
                                    y = y + 1;
                                }
                                seat3chips = Convert.ToDecimal(seat3startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat3 = str.Substring(str.Length - y, 1) + seat3;
                                    y = y + 1;
                                }

                                break;
                            }

                        case 4:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat4startingchips = str.Substring(str.Length - y, 1) + seat4startingchips;
                                    y = y + 1;
                                }
                                seat4chips = Convert.ToDecimal(seat4startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat4 = str.Substring(str.Length - y, 1) + seat4;
                                    y = y + 1;
                                }

                                break;
                            }

                        case 5:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat5startingchips = str.Substring(str.Length - y, 1) + seat5startingchips;
                                    y = y + 1;
                                }
                                seat5chips = Convert.ToDecimal(seat5startingchips.Replace(".", ","));
                                y = y + 2;

                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat5 = str.Substring(str.Length - y, 1) + seat5;
                                    y = y + 1;
                                }

                                break;
                            }

                        case 6:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat6startingchips = str.Substring(str.Length - y, 1) + seat6startingchips;
                                    y = y + 1;
                                }
                                seat6chips = Convert.ToDecimal(seat6startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat6 = str.Substring(str.Length - y, 1) + seat6;
                                    y = y + 1;
                                }

                                break;
                            }
                        case 7:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat7startingchips = str.Substring(str.Length - y, 1) + seat7startingchips;
                                    y = y + 1;
                                }
                                seat7chips = Convert.ToDecimal(seat7startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat7 = str.Substring(str.Length - y, 1) + seat7;
                                    y = y + 1;
                                }

                                break;
                            }
                        case 8:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat8startingchips = str.Substring(str.Length - y, 1) + seat8startingchips;
                                    y = y + 1;
                                }
                                seat8chips = Convert.ToDecimal(seat8startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat8 = str.Substring(str.Length - y, 1) + seat8;
                                    y = y + 1;
                                }

                                break;
                            }
                        case 9:
                            {
                                y = 1;
                                while (str.Substring(str.Length - y, 1) != "(")
                                {
                                    // str.Substring(str.Length - y, 1)
                                    if (IsNumeric(str.Substring(str.Length - y, 1)) | str.Substring(str.Length - y, 1) == ".")
                                        seat9startingchips = str.Substring(str.Length - y, 1) + seat9startingchips;
                                    y = y + 1;
                                }
                                seat9chips = Convert.ToDecimal(seat9startingchips.Replace(".", ","));
                                y = y + 2;
                                // y = y + 1
                                while (str.Length - y > 7)
                                {
                                    // str.Substring(str.Length - y, 1)
                                    seat9 = str.Substring(str.Length - y, 1) + seat9;
                                    y = y + 1;
                                }

                                break;
                            }
                    }

                    // starting players
                    players = players + 1;

                    str = reader.ReadLine();
                }

                var i = 1;
                var line = 1;
                string[] arraylinea;
                cant = "0";
                mpot = 0;
                round = 0;
                board = "";
                herocards = "";
                round = 0;
                if (str.IndexOf("small blind") != -1)
                {
                    tipo = "small blind";
                    line = 1;
                    arraylinea = lineadospuntos(str);
                    cant = ultimosnum(arraylinea[1]);
                    //insertManos(Double idmano, Int32 movimiento, String tipo, Double cantidad, String jugador, String board, Double bote, Int32 ronda, Int32 posicion)
                    m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".", ",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                    mpot = mpot + Convert.ToDecimal(cant.Replace(".", ","));
                    asientochipsresta(arraylinea[0], Convert.ToDecimal(cant.Replace(".", ",")));
                    //Console.WriteLine(str);
                }
                while (str != "*** SUMMARY ***") // <> Nothing
                {
                    str = reader.ReadLine();
                    if (str.IndexOf(":") != -1)
                    {
                        arraylinea = lineadospuntos(str);

                        if (arraylinea[1].IndexOf("raises") != -1)
                        {
                            tipo = "raise";
                            cant = ultimosnum(arraylinea[1]);
                            m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".", ",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                            //mpot = mpot + Convert.ToDecimal(cant.Replace(".",","));
                            mpot = asientochipsrestaraise(arraylinea[0], Convert.ToDecimal(cant.Replace(".", ",")));
                            //seat1cant = Convert.ToDecimal(cant.Replace(".", ","));
                            //inserthand(idhand, line, tipo, cant, mpot, name, String board, int round, int position, String txt)
                            //Console.WriteLine(cant+ " "+ mpot+ " " + arraylinea[1]);
                        }
                        else if (arraylinea[1].IndexOf("folds") != -1)
                        {
                            tipo = "fold";
                            cant = "0";
                            m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".", ",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                        }
                        else if (arraylinea[1].IndexOf("calls") != -1)
                        {
                            tipo = "call";
                            cant = ultimosnum(arraylinea[1]);
                            m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".", ",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                            mpot = mpot + Convert.ToDecimal(cant.Replace(".", ","));
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                            asientochipsresta(arraylinea[0], Convert.ToDecimal(cant.Replace(".", ",")));
                        }
                        else if (arraylinea[1].IndexOf("checks") != -1)
                        {
                            tipo = "check";
                            cant = "0";
                            m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".", ",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                        }
                        else if (arraylinea[1].IndexOf("bets") != -1)
                        {
                            tipo = "bet";
                            cant = ultimosnum(arraylinea[1]);
                            m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".", ",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                            //mpot = mpot + Convert.ToDecimal(cant.Replace(".", ","));
                            mpot = asientochipsrestaraise(arraylinea[0], Convert.ToDecimal(cant.Replace(".", ",")));
                            //seat1cant = Convert.ToDecimal(cant.Replace(".", ","));
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                        }
                        else if (arraylinea[1].IndexOf("small blind") != -1)
                        {
                            line = 1;
                            tipo = "small blind";
                            cant = ultimosnum(arraylinea[1]);
                            m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".", ",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                            mpot = mpot + Convert.ToDecimal(cant.Replace(".", ","));
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                            asientochipsresta(arraylinea[0], Convert.ToDecimal(cant.Replace(".", ",")));
                        }
                        else if (arraylinea[1].IndexOf("big blind") != -1)
                        {
                            line = 2;
                            tipo = "big blind";
                            cant = ultimosnum(arraylinea[1]);
                            //Double idmano, Int32 movimiento, String tipo,Decimal cantidad,String jugador,String board,Decimal bote,Int32 ronda,Int32 posicion
                            //insertMano(idhand, line, tipo, cant, arraylinea[0], board, mpot, round, asiento(arraylinea[0]), txt, new FileInfo(txt).Length);
                            m.insertManos(Convert.ToDouble(idhand), line, tipo, Convert.ToDouble(cant.Replace(".",",")), arraylinea[0], board, Convert.ToDouble(mpot), round, asiento(arraylinea[0]));
                            mpot = mpot + Convert.ToDecimal(cant.Replace(".", ","));
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                            asientochipsresta(arraylinea[0], Convert.ToDecimal(cant.Replace(".", ",")));
                            round = 1;

                        }
                        else if (arraylinea[1].IndexOf("doesn't show hand") != -1)
                        {
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                        }

                        else
                        {
                            //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                        }
                        // inserthand(idhand, line, tipo, cant, mpot, arraylinea[0].Replace(("'"),""), board, round, asiento(arraylinea[0]), txt);
                        //Console.WriteLine(idhand +"  "+ line+"  " +cant + "  " + mpot + "  "+ arraylinea[0] + "  " +board+"  " +round+"  "  + asiento(arraylinea[0]));
                        //Console.WriteLine(arraylinea[0] + arraylinea[1]);
                        line = line + 1;
                    }
                    else
                    {
                        if (str.IndexOf("*** FLOP ***") != -1)
                        {
                            round = 2;
                            board = extrerboard(str);
                            seat1raise = 0;
                            seat2raise = 0;
                            seat3raise = 0;
                            seat4raise = 0;
                            seat5raise = 0;
                            seat6raise = 0;
                            seat7raise = 0;
                            seat8raise = 0;
                            seat9raise = 0;
                            //Console.WriteLine(str);
                        }
                        else if (str.IndexOf("*** TURN ***") != -1)
                        {
                            board = extrerboard(str);
                            round = 3;
                            seat1raise = 0;
                            seat2raise = 0;
                            seat3raise = 0;
                            seat4raise = 0;
                            seat5raise = 0;
                            seat6raise = 0;
                            seat7raise = 0;
                            seat8raise = 0;
                            seat9raise = 0;
                            //Console.WriteLine(str);
                        }
                        else if (str.IndexOf("*** RIVER ***") != -1)
                        {
                            board = extrerboard(str);
                            round = 4;
                            seat1raise = 0;
                            seat2raise = 0;
                            seat3raise = 0;
                            seat4raise = 0;
                            seat5raise = 0;
                            seat6raise = 0;
                            seat7raise = 0;
                            seat8raise = 0;
                            seat9raise = 0;
                            //Console.WriteLine(str);
                        }
                        else if (str.IndexOf("*** SHOW DOWN ***") != -1)
                        {
                            while (str != "*** SUMMARY ***")
                            {
                                str = reader.ReadLine();

                                if (str.IndexOf("collected") != -1)
                                {
                                    asientochipssuma(str.Substring(0, str.IndexOf("collected") - 1), Convert.ToDecimal(ultimosnum(str).Replace(".", ",")));
                                    // Console.WriteLine(ultimosnum(str));
                                }


                            }

                        }
                        else
                        {
                            if (str.IndexOf("Dealt to") != -1)
                            {
                                int u = str.Length - 1;
                                while (str[u] != '[' | u == 0)
                                {
                                    if (str[u] == 'A' | str[u] == 'T' | str[u] == 'J' | str[u] == 'Q' | str[u] == 'K' | IsNumeric(str[u].ToString()) == true | str[u] == 'c' | str[u] == 's' | str[u] == 'h' | str[u] == 'd')
                                    {
                                        herocards = str[u] + herocards;
                                    }
                                    u = u - 1;
                                }
                                if (str.IndexOf(seat1) != -1)
                                {
                                    seat1cards = herocards;
                                }
                                if (str.IndexOf(seat2) != -1)
                                {
                                    seat2cards = herocards;
                                }
                                if (str.IndexOf(seat3) != -1)
                                {
                                    seat3cards = herocards;
                                }
                                if (str.IndexOf(seat4) != -1)
                                {
                                    seat4cards = herocards;
                                }
                                if (str.IndexOf(seat5) != -1)
                                {
                                    seat5cards = herocards;
                                }
                                if (str.IndexOf(seat6) != -1)
                                {
                                    seat6cards = herocards;
                                }
                                if (str.IndexOf(seat7) != -1)
                                {
                                    seat7cards = herocards;
                                }
                                if (str.IndexOf(seat8) != -1)
                                {
                                    seat8cards = herocards;
                                }
                                if (str.IndexOf(seat9) != -1)
                                {
                                    seat9cards = herocards;
                                }
                            }
                            //Console.WriteLine(str);
                        }
                        //Console.WriteLine(str);
                    }

                }
                str = reader.ReadLine();
                //Console.WriteLine(str);
                //str = reader.ReadLine();
                rake = ultimosnum(str);
                //Console.WriteLine(rake);
                while (str != "")
                {

                    str = reader.ReadLine();

                    if (str.IndexOf(":") != -1)
                    {
                        //if()
                        if (str.Substring(0, 7) == "Seat 1:")
                        {
                            //Console.WriteLine(str.Replace(seat1,""));
                            //Console.WriteLine(str.Substring(8 + seat1.Length, str.Length - (8 + seat1.Length)).Replace(seat1,""));
                            if (str.Replace(seat1, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat1cards = extraercartassumary(str.Substring(8 + seat1.Length, str.Length - (8 + seat1.Length)));
                                //Console.WriteLine(str.Substring(8 + seat1.Length, str.Length - (8 + seat1.Length)));
                                //Console.WriteLine(seat1cards);
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 2:")
                        {
                            if (str.Replace(seat2, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat2cards = extraercartassumary(str.Substring(8 + seat2.Length, str.Length - (8 + seat2.Length)));
                                //Console.WriteLine(str.Substring(8 + seat2.Length, str.Length - (8 + seat2.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 3:")
                        {
                            if (str.Replace(seat3, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat3cards = extraercartassumary(str.Substring(8 + seat3.Length, str.Length - (8 + seat3.Length)));
                                //Console.WriteLine(str.Substring(8 + seat3.Length, str.Length - (8 + seat3.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 4:")
                        {
                            if (str.Replace(seat4, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat4cards = extraercartassumary(str.Substring(8 + seat4.Length, str.Length - (8 + seat4.Length)));
                                //Console.WriteLine(str.Substring(8 + seat4.Length, str.Length - (8 + seat4.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 5:")
                        {
                            if (str.Replace(seat5, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat5cards = extraercartassumary(str.Substring(8 + seat5.Length, str.Length - (8 + seat5.Length)));
                                //Console.WriteLine(str.Substring(8 + seat5.Length, str.Length - (8 + seat5.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 6:")
                        {
                            if (str.Replace(seat6, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat6cards = extraercartassumary(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 7:")
                        {
                            if (str.Replace(seat6, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat7cards = extraercartassumary(str.Substring(8 + seat7.Length, str.Length - (8 + seat7.Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 8:")
                        {
                            if (str.Replace(seat6, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat8cards = extraercartassumary(str.Substring(8 + seat8.Length, str.Length - (8 + seat8.Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 9:")
                        {
                            if (str.Replace(seat9, "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                seat6cards = extraercartassumary(str.Substring(8 + seat9.Length, str.Length - (8 + seat9.Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        //Console.WriteLine(str);

                    }


                }
                str = reader.ReadLine();
                str = reader.ReadLine();
                if(seat1 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat1cards, 1);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat1startingchips == "" ? "0" : seat1startingchips.Replace(".", ",")), Convert.ToDouble(seat1chips), 1);
                    a.insertAsientos(Convert.ToDouble(idhand), seat1, 1);
                }
                if (seat2 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat2cards, 2);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat2startingchips == "" ? "0" : seat2startingchips.Replace(".", ",")), Convert.ToDouble(seat2chips), 2);
                    a.insertAsientos(Convert.ToDouble(idhand), seat2, 2);
                }
                if (seat3 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat3cards, 3);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat3startingchips == "" ? "0" : seat3startingchips.Replace(".", ",")), Convert.ToDouble(seat3chips), 3);
                    a.insertAsientos(Convert.ToDouble(idhand), seat3, 3);
                }
                if (seat4 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat4cards, 4);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat4startingchips == "" ? "0" : seat4startingchips.Replace(".", ",")), Convert.ToDouble(seat4chips), 4);
                    a.insertAsientos(Convert.ToDouble(idhand), seat4, 4);
                }
                if (seat5 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat5cards, 5);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat5startingchips == "" ? "0" : seat5startingchips.Replace(".", ",")), Convert.ToDouble(seat5chips), 5);
                    a.insertAsientos(Convert.ToDouble(idhand), seat5, 5);
                }
                if (seat6 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat6cards, 6);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat6startingchips == "" ? "0" : seat6startingchips.Replace(".", ",")), Convert.ToDouble(seat6chips), 6);
                    a.insertAsientos(Convert.ToDouble(idhand), seat6, 6);
                }
                if (seat7 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat7cards, 7);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat7startingchips == "" ? "0" : seat7startingchips.Replace(".", ",")), Convert.ToDouble(seat7chips), 7);
                    a.insertAsientos(Convert.ToDouble(idhand), seat7, 7);
                }
                if (seat8 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat8cards, 8);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat8startingchips == "" ? "0" : seat8startingchips.Replace(".", ",")), Convert.ToDouble(seat8chips), 8);
                    a.insertAsientos(Convert.ToDouble(idhand), seat8, 8);
                }
                if (seat9 != "")
                {
                    c.insertCartas(Convert.ToDouble(idhand), seat9cards, 9);
                    f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat9startingchips == "" ? "0" : seat9startingchips.Replace(".", ",")), Convert.ToDouble(seat9chips), 9);
                    a.insertAsientos(Convert.ToDouble(idhand), seat9, 9);
                }






                //insertcards(idhand, seat1cards, seat2cards, seat3cards, seat4cards, seat5cards, seat6cards);
                //resumen (idmano, fecha, mesa, stake, rake, jugadores, herocards, board, txt, txt_tamanio, bote) VALUES (p_idmano, p_fecha, p_mesa, p_stake, p_rake, p_jugadores, p_herocards, p_board, p_txt, p_txt_tamanio, p_bote
                r.insertResumen(Convert.ToDouble(idhand), Convert.ToDateTime(fecha), tablename, players, herocards, board.Replace(" ", ""), txt, new FileInfo(txt).Length, Convert.ToDouble(mpot),jugadoresMesa);
                //insertsumary(idhand, fecha, tablename, stake, mpot.ToString().Replace(",", "."), rake, board.Replace(" ", ""), seat1.Replace("'", ""), seat2.Replace("'", ""), seat3.Replace("'", ""), seat4.Replace("'", ""), seat5.Replace("'", ""), seat6.Replace("'", ""), players, herocards, txt.Replace("'", ""));
                
                //f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat2startingchips == "" ? "0" : seat2startingchips), Convert.ToDouble(seat2chips), 2);
                //f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat3startingchips == "" ? "0" : seat3startingchips), Convert.ToDouble(seat3chips), 3);
                //f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat4startingchips == "" ? "0" : seat4startingchips), Convert.ToDouble(seat4chips), 4);
                //f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat5startingchips == "" ? "0" : seat5startingchips), Convert.ToDouble(seat5chips), 5);
                //f.insertFichas(Convert.ToDouble(idhand), Convert.ToDouble(seat6startingchips == "" ? "0" : seat6startingchips), Convert.ToDouble(seat6chips), 6);
                ////insertarchips(idhand, seat1startingchips.ToString().Replace(",", "."), seat2startingchips.ToString().Replace(",", "."), seat3startingchips.ToString().Replace(",", "."), seat4startingchips.ToString().Replace(",", "."), seat5startingchips.ToString().Replace(",", "."), seat6startingchips.ToString().Replace(",", "."), seat1chips.ToString().Replace(",", "."), seat2chips.ToString().Replace(",", "."), seat3chips.ToString().Replace(",", "."), seat4chips.ToString().Replace(",", "."), seat5chips.ToString().Replace(",", "."), seat6chips.ToString().Replace(",", "."));
               
                //a.insertAsientos(Convert.ToDouble(idhand), seat2, 2);
                //a.insertAsientos(Convert.ToDouble(idhand), seat3, 3);
                //a.insertAsientos(Convert.ToDouble(idhand), seat4, 4);
                //a.insertAsientos(Convert.ToDouble(idhand), seat5, 5);
                //a.insertAsientos(Convert.ToDouble(idhand), seat6, 6);
                fecha = "";
            }

        }

        //public void insertarchips(string idhand, string seat1startingchips, string seat2startingchips, string seat3startingchips, string seat4startingchips, string seat5startingchips, string seat6startingchips, string seat1chips, string seat2chips, string seat3chips, string seat4chips, string seat5chips, string seat6chips)
        //{
        //    if (seat1startingchips == "")
        //    {
        //        seat1startingchips = "0";
        //    }
        //    if (seat2startingchips == "")
        //    {
        //        seat2startingchips = "0";
        //    }
        //    if (seat3startingchips == "")
        //    {
        //        seat3startingchips = "0";
        //    }
        //    if (seat4startingchips == "")
        //    {
        //        seat4startingchips = "0";
        //    }
        //    if (seat5startingchips == "")
        //    {
        //        seat5startingchips = "0";
        //    }
        //    if (seat6startingchips == "")
        //    {
        //        seat6startingchips = "0";
        //    }

        //    // Create the Insert, Update() And Delete commands.
        //    OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");
        //    var query = "INSERT INTO chips (idhand,seat1start, seat2start, seat3start, seat4start, seat5start, seat6start, seat1fin, seat2fin, seat3fin, seat4fin, seat5fin, seat6fin) " + "VALUES ('" + idhand + "', " + seat1startingchips + "," + seat2startingchips + "," + seat3startingchips + "," + seat4startingchips + "," + seat5startingchips + "," + seat6startingchips + "," + seat1chips + "," + seat2chips + "," + seat3chips + "," + seat4chips + "," + seat5chips + "," + seat6chips + ")"; // "SELECT * FROM hand"
        //    //var hola = txt;
        //    OdbcCommand command = new OdbcCommand(query, connection);
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //    connection.Dispose();
        //}
        public string extraercartassumary(string str)
        {
            string cartas = "";
            int u = 0;
            while (str[u] != '[')
            {

                u = u + 1;
            }
            while (str[u] != ']')
            {
                if (str[u] == 'A' | str[u] == 'T' | str[u] == 'J' | str[u] == 'Q' | str[u] == 'K' | IsNumeric(str[u].ToString()) == true | str[u] == 'c' | str[u] == 's' | str[u] == 'h' | str[u] == 'd')
                {
                    cartas = cartas + str[u];
                }
                u = u + 1;
            }
            return cartas;
        }

        public string extrerboard(string linea)
        {
            string board = "";
            int f = linea.Length - 1;
            while (linea[f] != '*')
            // while (linea[f] == 'A' | linea[f] == 'T' | linea[f] == 'J' | linea[f] == 'Q' | linea[f] == 'K' | IsNumeric(linea[f].ToString()) == true | linea[f] == 'c' | linea[f] == 's' | linea[f] == 'h' | linea[f] == 'd' | linea[f] == ']' | linea[f] == '[' | linea[f] == ' ')
            {
                if (linea[f] == 'A' | linea[f] == 'T' | linea[f] == 'J' | linea[f] == 'Q' | linea[f] == 'K' | IsNumeric(linea[f].ToString()) == true | linea[f] == 'c' | linea[f] == 's' | linea[f] == 'h' | linea[f] == 'd')
                {
                    board = linea[f] + board;
                }
                f = f - 1;
            }
            //Console.WriteLine(board);
            return board;
        }
        //public void inserthand(String idhand, int line, String tipo, String cant, Decimal mpot, String name, String board, int round, int position, String txt)
        //{
        //    //if (string.IsNullOrEmpty(board))
        //    //    Parameters.Add(new OleDbParameter("EMPID", DBNull.Value));
        //    //else
        //    //    Parameters.Add(new OleDbParameter("EMPID", sbcId));
        //    if (board == "")
        //        board = DBNull.Value.ToString();
        //    cant = cant.Replace(",", ".");
        //    //mpot = mpot.Replace(",", ".");
        //    string auxmpot = mpot.ToString();
        //    auxmpot = auxmpot.Replace(",", ".");
        //    name = name.Replace("'", "");
        //    // Create the Insert, Update() And Delete commands.
        //    OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");
        //    var query = "INSERT INTO hand (idhand, line, tipo, cant, mpot, name, board, round, position) " + "VALUES ('" + idhand + "', '" + line + "','" + tipo + "'," + cant + "," + auxmpot + ",'" + name + "','" + board + "','" + round + "','" + position + "')"; // "SELECT * FROM hand"
        //    var hola = txt;
        //    OdbcCommand command = new OdbcCommand(query, connection);
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //    connection.Dispose();
        //    cant = cant.Replace(".", ",");
        //    //mpot = mpot.ToString().Replace(".", ",");
        //}
        //public void insertcards(string idhand, string seat1cards, string seat2cards, string seat3cards, string seat4cards, string seat5cards, string seat6cards)
        //{
        //    if (seat1cards == "")
        //    {
        //        seat1cards = DBNull.Value.ToString();
        //    }
        //    else if (seat2cards == "")
        //    {
        //        seat2cards = DBNull.Value.ToString();
        //    }
        //    else if (seat3cards == "")
        //    {
        //        seat3cards = DBNull.Value.ToString();
        //    }
        //    else if (seat4cards == "")
        //    {
        //        seat4cards = DBNull.Value.ToString();
        //    }
        //    else if (seat5 == "")
        //    {
        //        seat5cards = DBNull.Value.ToString();
        //    }
        //    else if (seat6cards == "")
        //    {
        //        seat6cards = DBNull.Value.ToString();
        //    }
        //    // Create the Insert, Update() And Delete commands.
        //    OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");
        //    var query = "INSERT INTO cards (idhand, seat1cards, seat2cards, seat3cards, seat4cards, seat5cards, seat6cards) " + "VALUES ('" + idhand + "','" + seat1cards + "','" + seat2cards + "','" + seat3cards + "','" + seat4cards + "','" + seat5cards + "','" + seat6cards + "')"; // "SELECT * FROM hand"
        //    var hola = txt;
        //    OdbcCommand command = new OdbcCommand(query, connection);
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //    connection.Dispose();
        //}
        //public void insertsumary(object idhand, object fecha, object tablename, object stake, object pot, object rake, object board, object seat1, object seat2, object seat3, object seat4, object seat5, object seat6, object players, object herocards, object txt)
        //{
        //    if (board.ToString() == "")
        //        board = DBNull.Value.ToString();

        //    // Create the Insert, Update() And Delete commands.
        //    OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL30");
        //    var query = "INSERT INTO sumary (idhand, fecha, tablename, stake, pot, rake, board, seat1, seat2, seat3, seat4, seat5, seat6, players, herocards, txt) " + "VALUES ('" + idhand + "', to_date('" + fecha + "','YYYY/MM/DD HH24:MI:SS '),'" + tablename + "','" + stake + "'," + pot + ",'" + rake + "','" + board + "','" + seat1 + "','" + seat2 + "','" + seat3 + "','" + seat4 + "','" + seat5 + "','" + seat6 + "','" + players + "','" + herocards + "','" + txt + "')"; // "SELECT * FROM hand"
        //    var hola = txt;
        //    OdbcCommand command = new OdbcCommand(query, connection);
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //    connection.Dispose();
        //}
        public int asiento(string name)
        {

            int num = 0;
            if (name == seat1)
            {
                num = 1;
            }
            else if (name == seat2)
            {
                num = 2;
            }
            else if (name == seat3)
            {
                num = 3;
            }
            else if (name == seat4)
            {
                num = 4;
            }
            else if (name == seat5)
            {
                num = 5;
            }
            else if (name == seat6)
            {
                num = 6;
            }
            else if (name == seat7)
            {
                num = 7;
            }
            else if (name == seat8)
            {
                num = 8;
            }
            else if (name == seat9)
            {
                num = 9;
            }

            return num;

        }
        public void asientochipsresta(string name, decimal cant)
        {


            if (name == seat1)
            {
                seat1chips = seat1chips - cant;
            }
            else if (name == seat2)
            {
                seat2chips = seat2chips - cant;
            }
            else if (name == seat3)
            {
                seat3chips = seat3chips - cant;
            }
            else if (name == seat4)
            {
                seat4chips = seat4chips - cant;
            }
            else if (name == seat5)
            {
                seat5chips = seat5chips - cant;
            }
            else if (name == seat6)
            {
                seat6chips = seat6chips - cant;
            }
            else if (name == seat7)
            {
                seat7chips = seat7chips - cant;
            }
            else if (name == seat8)
            {
                seat8chips = seat8chips - cant;
            }
            else if (name == seat9)
            {
                seat9chips = seat9chips - cant;
            }

        }
        public decimal asientochipsrestaraise(string name, decimal cant)
        {


            if (name == seat1)
            {
                seat1raise = seat1raise + 1;
                if (seat1raise > 1)
                {
                    seat1chips = (seat1chips + seat1cant) - cant;
                    seat1cant = cant - seat1cant;
                    return mpot + (cant - seat1cant);
                }
                else
                {
                    seat1chips = seat1chips - cant;
                    seat1cant = cant;
                    return mpot + cant;
                }


            }
            else if (name == seat2)
            {
                seat2raise = seat2raise + 1;
                if (seat2raise > 1)
                {
                    seat2chips = (seat2chips + seat2cant) - cant;
                    seat2cant = cant - seat2cant;
                    return mpot + (cant - seat2cant);
                }
                else
                {
                    seat2chips = seat2chips - cant;
                    seat2cant = cant;
                    return mpot + cant;
                }


            }
            else if (name == seat3)
            {
                seat3raise = seat3raise + 1;
                if (seat3raise > 1)
                {
                    seat3chips = (seat3chips + seat3cant) - cant;
                    seat3cant = cant - seat3cant;
                    return mpot + (cant - seat3cant);
                }
                else
                {
                    seat3chips = seat3chips - cant;
                    seat3cant = cant;
                    return mpot + cant;
                }


            }
            else if (name == seat4)
            {
                seat4raise = seat4raise + 1;
                if (seat4raise > 1)
                {
                    seat4chips = (seat4chips + seat4cant) - cant;
                    seat4cant = cant - seat4cant;
                    return mpot + (cant - seat4cant);
                }
                else
                {
                    seat4chips = seat4chips - cant;
                    seat4cant = cant;
                    return mpot + cant;
                }


            }
            else if (name == seat5)
            {
                seat5raise = seat5raise + 1;
                if (seat5raise > 1)
                {
                    seat5chips = (seat5chips + seat5cant) - cant;
                    seat5cant = cant - seat5cant;
                    return mpot + (cant - seat5cant);
                }
                else
                {
                    seat5chips = seat5chips - cant;
                    seat5cant = cant;
                    return mpot + cant;
                }


            }
            else if (name == seat6)
            {
                seat6raise = seat6raise + 1;
                if (seat6raise > 1)
                {
                    seat6chips = (seat6chips + seat6cant) - cant;
                    seat6cant = cant - seat6cant;
                    return mpot + (cant - seat6cant);
                }
                else
                {
                    seat6chips = seat6chips - cant;
                    seat6cant = cant;
                    return mpot + cant;
                }


            }
            else if (name == seat7)
            {
                seat7raise = seat7raise + 1;
                if (seat7raise > 1)
                {
                    seat7chips = (seat7chips + seat7cant) - cant;
                    seat7cant = cant - seat7cant;
                    return mpot + (cant - seat7cant);
                }
                else
                {
                    seat7chips = seat7chips - cant;
                    seat7cant = cant;
                    return mpot + cant;
                }
            }
            else if (name == seat8)
            {
                seat8raise = seat8raise + 1;
                if (seat8raise > 1)
                {
                    seat8chips = (seat8chips + seat8cant) - cant;
                    seat8cant = cant - seat8cant;
                    return mpot + (cant - seat8cant);
                }
                else
                {
                    seat8chips = seat8chips - cant;
                    seat8cant = cant;
                    return mpot + cant;
                }



            }
            else if (name == seat9)
            {
                seat9raise = seat9raise + 1;
                if (seat9raise > 1)
                {
                    seat9chips = (seat9chips + seat9cant) - cant;
                    seat9cant = cant - seat9cant;
                    return mpot + (cant - seat9cant);
                }
                else
                {
                    seat9chips = seat9chips - cant;
                    seat9cant = cant;
                    return mpot + cant;
                }


            }

            return mpot + cant;
        }
        public void asientochipssuma(string name, decimal cant)
        {
            if (name == seat1)
            {
                seat1chips = seat1chips + cant;
            }
            else if (name == seat2)
            {
                seat2chips = seat2chips + cant;
            }
            else if (name == seat3)
            {
                seat3chips = seat3chips + cant;
            }
            else if (name == seat4)
            {
                seat4chips = seat4chips + cant;
            }
            else if (name == seat5)
            {
                seat5chips = seat5chips + cant;
            }
            else if (name == seat6)
            {
                seat6chips = seat6chips + cant;
            }
            else if (name == seat7)
            {
                seat7chips = seat7chips + cant;
            }
            else if (name == seat8)
            {
                seat8chips = seat8chips + cant;
            }
            else if (name == seat9)
            {
                seat9chips = seat9chips + cant;
            }
        }
        public string ultimosnum(string linea)
        {
            int g = linea.Length - 1;
            string cant = "";
            while (IsNumeric(linea[g].ToString()) == false)
            {
                g = g - 1;
            }
            while (IsNumeric(linea[g].ToString()) == true | linea[g] == '.')
            {
                cant = linea[g] + cant;
                g = g - 1;
            }
            return cant;
        }
        private string[] lineadospuntos(string linea)
        {
            string[] output = new string[2];
            int x;
            if (linea.IndexOf(":") != -1)
            {
                for (x = linea.Length - 1; x >= 0; x--)
                {
                    if (linea[x] == ':')
                    {
                        break;
                    }

                }
                output[0] = linea.Substring(0, x);
                output[1] = linea.Substring(x + 2, linea.Length - (x + 2));
            }


            return output;
        }

        public void leeridhand(string txt, double maxidhand)
        {
            StreamReader reader = new StreamReader(txt);
            string str = "";
            int cha = 0;
            while (!reader.EndOfStream)
            {
                var idhand = ""; // aqui
                                 // str = reader.ReadLine
                while (Convert.ToChar(cha) != '#')
                    cha = reader.Read();
                cha = reader.Read();
                while (Convert.ToChar(cha) != ':')
                {
                    idhand = idhand + Convert.ToChar(cha);
                    cha = reader.Read();
                }

                while (str != "")
                {
                    str = reader.ReadLine();
                }
                str = reader.ReadLine();
                str = reader.ReadLine();
            }
        }
        //public Int64 select(string txt)
        //{
        //    Int64 count = 0;
        //    try
        //    {
        //        // Connect to a PostgreSQL database
        //        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres; " +
        //           "Password=toor;Database=poker;");
        //        conn.Open();

        //        // Define a query returning a single row result set
        //        NpgsqlCommand command = new NpgsqlCommand("SELECT max(h.idhand) from hand h,sumary s where s.idhand= h.idhand and s.txt= '" + txt.Replace("'", "").Replace("//", "/") + "' ", conn);

        //        // Execute the query and obtain the value of the first column of the first row
        //        count = (Int64)command.ExecuteScalar();

        //        //Console.Write("{0}\n", count);
        //        conn.Close();
        //    }
        //    //catch (NpgsqlException e)
        //    catch (System.InvalidCastException e)
        //    {

        //        return 0;

        //    }
        //    return count;
        }
    }
