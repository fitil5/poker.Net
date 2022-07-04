using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class LeerFicheroCashWX
    {
        string[] seats = new string[9];
        decimal[] stacks = new decimal[9];
        decimal[] startingStacks = new decimal[9];
        
        public void leerficheroCash(StreamReader reader, String txt)
        {
            ManosCash m = new ManosCash();
            CartasCash c = new CartasCash();
            FichasCash f = new FichasCash();
            ResumenCash r = new ResumenCash();
            AsientosCash a = new AsientosCash();
            //int cha = 0;
            //string idmano="";
            //string stake = "";
            //string nombreMesa = "";
            //string fecha = "";
            //string jugadoresMesa = "";


            while (!reader.EndOfStream)
            {
                int cha = 0;
                string idmano = "";
                string stake = "";
                string nombreMesa = "";
                string fecha = "";
                string jugadoresMesa = "";
                while (Convert.ToChar(cha) != '#')
                {
                    cha = reader.Read();
                }
                while (Convert.ToChar(cha) != ' ')
                {
                    cha = reader.Read();
                    idmano = idmano + Convert.ToChar(cha);
                }
                while (Convert.ToChar(cha) != '(')
                {
                    cha = reader.Read();
                    
                }
                cha = reader.Read();
                while (Convert.ToChar(cha) != ')')
                {
                    stake = stake + Convert.ToChar(cha);
                    cha = reader.Read();
                }
                stake =stake.Replace("€","");
                int i = 0;
                while (int.TryParse(Convert.ToChar(cha).ToString(), out i) == false)
                {
                    cha = reader.Read();
                }
                while (int.TryParse(Convert.ToChar(cha).ToString(), out i) == true | Convert.ToChar(cha) == '/' | Convert.ToChar(cha) == ' ' | Convert.ToChar(cha) == ':')
                {

                    fecha = fecha + Convert.ToChar(cha);
                    cha = reader.Read();
                }

                while (Convert.ToChar(cha) != Convert.ToChar(39))
                {
                    cha = reader.Read();                    
                }
                cha = reader.Read();
                while (Convert.ToChar(cha) != Convert.ToChar(39))
                {
                    
                    nombreMesa = nombreMesa + Convert.ToChar(cha);
                    cha = reader.Read();
                }
                cha = reader.Read();
                cha = reader.Read();
                while (Convert.ToChar(cha) != ' ')
                {

                    jugadoresMesa = jugadoresMesa + Convert.ToChar(cha);
                    cha = reader.Read();
                }
                reader.ReadLine();
                

                while (Convert.ToChar(cha) != ' ')
                {
                    cha = reader.Read();
                }
                
                string str = reader.ReadLine();
                while (str.IndexOf( "*** ANTE/BLINDS ***")==-1)
                {
                  
                    switch (str[5])
                    {
                        case '1':
                            {
                                seats[0] = str.Substring(str.IndexOf(":") + 1,(str.IndexOf("(")-2)- str.IndexOf(":"));
                                stacks[0] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[0] = stacks[0]; 
                                break;
                            }
                        case '2':
                            {
                                seats[1] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[1] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[1] = stacks[1];
                                break;
                            }
                        case '3':
                            {
                                seats[2] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[2] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[2] = stacks[2];
                                break;
                            }
                        case '4':
                            {
                                seats[3] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[3] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[3] = stacks[3];
                                break;
                            }
                        case '5':
                            {
                                seats[4] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[4] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[4] = stacks[4];
                                break;
                            }
                        case '6':
                            {
                                seats[5] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[5] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[5] = stacks[5];
                                break;
                            }
                        case '7':
                            {
                                seats[6] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[6] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[6] = stacks[6];
                                break;
                            }
                        case '8':
                            {
                                seats[7] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[7] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[7] = stacks[7];
                                break;
                            }
                        case '9':
                            {
                                seats[8] = str.Substring(str.IndexOf(":") + 1, (str.IndexOf("(") - 2) - str.IndexOf(":"));
                                stacks[8] = Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str));
                                startingStacks[8] = stacks[8];
                                break;
                            }

                    }
                    str = reader.ReadLine();
                }
                string cantidad="";
                string jugador = "";
                string tipo = "";
                int ronda = 0;
                int posicion;
                string board ="";
                decimal bote = 0;
                int linea = 1;
                string herocards="";
                string[] cards = new string[9];
                string rake="0";
                while (str !=null && str.IndexOf("*** SUMMARY ***") == -1)
                {
                    if (str == "")
                    {

                    }
                    else if (str.Substring(str.IndexOf(' ')).IndexOf("small blind") != -1)
                    {
                        cantidad = Utilidades.Utilidades.ultimosnum(str);
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "small blind";
                        linea = 1;
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-","").Replace(" ","")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        bote = bote + Convert.ToDecimal(cantidad);
                        asientochipsresta(jugador, Convert.ToDecimal(cantidad.Replace(".", ",")));
                       
                    }
                    else if (str.Substring(str.IndexOf(' ')).IndexOf("big blind") != -1)
                    {
                        cantidad = Utilidades.Utilidades.ultimosnum(str);
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "big blind";
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        asientochipsresta(jugador, Convert.ToDecimal(cantidad.Replace(".", ",")));
                        bote = bote + Convert.ToDecimal(cantidad);
                        
                        linea = linea + 1;
                    }
                    else if (str.Substring(str.IndexOf(' ')).IndexOf("big blind") != -1)
                    {
                        cantidad = Utilidades.Utilidades.ultimosnum(str);
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "big blind";
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        bote = bote + Convert.ToDecimal(cantidad);
                        asientochipsresta(jugador, Convert.ToDecimal(cantidad.Replace(".", ",")));
                        linea = linea + 1;
                    }
                    else if (str.Substring(str.IndexOf(' ')).IndexOf("raises") != -1)
                    {
                        cantidad = Utilidades.Utilidades.ultimosnum(str);
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "raise";
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        bote = bote + Convert.ToDecimal(cantidad);
                        asientochipsresta(jugador, Convert.ToDecimal(cantidad.Replace(".", ",")));
                        linea = linea + 1;
                    }
                    else if (str.Substring(str.IndexOf(' ')).IndexOf("bets") != -1)
                    {
                        cantidad = Utilidades.Utilidades.ultimosnum(str);
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "bet";
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        bote = bote + Convert.ToDecimal(cantidad);
                        asientochipsresta(jugador, Convert.ToDecimal(cantidad.Replace(".", ",")));
                        linea = linea + 1;
                    }
                    else if (str.Substring(str.IndexOf(' ')).IndexOf("calls") != -1)
                    {
                        cantidad = Utilidades.Utilidades.ultimosnum(str);
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "call";
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        bote = bote + Convert.ToDecimal(cantidad);
                        asientochipsresta(jugador, Convert.ToDecimal(cantidad.Replace(".", ",")));
                        linea = linea + 1;
                    }

                    else if (str.Substring(str.IndexOf(' ')).IndexOf("checks") != -1)
                    {
                        cantidad = "0";
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "check";
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        bote = bote + Convert.ToDecimal(cantidad);
                        linea = linea + 1;
                    }
                    else if (str.Substring(str.IndexOf(' ')).IndexOf("folds") != -1)
                    {
                        cantidad = "0";
                        jugador = str.Substring(0, str.IndexOf(' '));
                        tipo = "fold";
                        posicion = asiento(jugador);
                        m.insertManos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), linea, tipo, Convert.ToDouble(cantidad.Replace(".", ",")), jugador, board, Convert.ToDouble(bote), ronda, posicion);
                        bote = bote + Convert.ToDecimal(cantidad);
                        linea = linea + 1;
                    }

                     

                    else {
                        if (str.IndexOf("*** FLOP ***") != -1)
                        {
                            board = str.Replace("[", "").Replace("]", "").Replace("*** FLOP ***", "").Replace(" ", "");
                            ronda = 1;
                        }
                        else if (str.IndexOf("*** TURN ***") != -1)
                        {
                            board = str.Replace("[", "").Replace("]", "").Replace("*** TURN ***", "").Replace(" ", "");
                            ronda = 2;
                        }
                        else if (str.IndexOf("*** RIVER ***") != -1)
                        {
                            board = str.Replace("[", "").Replace("]", "").Replace("*** RIVER ***", "").Replace(" ", "");
                            ronda = 3;
                        }

                        else if (str.IndexOf("*** SHOW DOWN ***") != -1)
                        {
                            while (str != "*** SUMMARY ***")
                            {
                                str = reader.ReadLine();

                                if (str.IndexOf("collected") != -1)
                                {
                                    asientochipssuma(str.Substring(0, str.IndexOf("collected") - 1), Convert.ToDecimal(Utilidades.Utilidades.ultimosnum(str).Replace(".", ",")));

                                }
                            }
                        }
                        else if (str.IndexOf("*** ANTE/BLINDS ***") != -1)
                        {
                            str = reader.ReadLine();
                        }
                        else if (str.IndexOf("*** PRE-FLOP ***") != -1)
                        {
                            str = reader.ReadLine();

                        }
                        else
                        {

                            if (str.IndexOf("Dealt to") != -1)
                            {
                                int u = str.Length - 1;
                                while (str[u] != '[' | u == 0)
                                {
                                    int ou = 0;
                                    if (str[u] == 'A' | str[u] == 'T' | str[u] == 'J' | str[u] == 'Q' | str[u] == 'K' | int.TryParse(str[u].ToString(), out ou) == true | str[u] == 'c' | str[u] == 's' | str[u] == 'h' | str[u] == 'd')
                                    {
                                        herocards = str[u] + herocards;
                                    }
                                    u = u - 1;
                                }
                                if (seats[0] != null && str.IndexOf(seats[0]) != -1)
                                {
                                    cards[0] = herocards;
                                }
                                if (seats[1] != null && str.IndexOf(seats[1]) != -1)
                                {
                                    cards[1] = herocards;
                                }
                                if (seats[2] != null && str.IndexOf(seats[2]) != -1)
                                {
                                    cards[2] = herocards;
                                }
                                if (seats[3] != null && str.IndexOf(seats[3]) != -1)
                                {
                                    cards[3] = herocards;
                                }
                                if (seats[4] != null && str.IndexOf(seats[4]) != -1)
                                {
                                    cards[4] = herocards;
                                }
                                if (seats[5] != null && str.IndexOf(seats[5]) != -1)
                                {
                                    cards[5] = herocards;
                                }
                                if (seats[6] != null && str.IndexOf(seats[6]) != -1)
                                {
                                    cards[6] = herocards;
                                }
                                if (seats[7] != null && str.IndexOf(seats[7]) != -1)
                                {
                                    cards[7] = herocards;
                                }
                                if (seats[8] != null && str.IndexOf(seats[8]) != -1)
                                {
                                    cards[8] = herocards;
                                }
                            }
                            Console.WriteLine(str); 
                        }
                    }
                    str = reader.ReadLine();
                    Console.WriteLine(str);
                    //rake = Utilidades.Utilidades.ultimosnum(str);
                }
                str = reader.ReadLine();
                rake = Utilidades.Utilidades.extraerRake(str).ToString();
                while (str != "" && str !=null)
                {
                    str = reader.ReadLine();
                    if (str.IndexOf(":") != -1)
                    {
                       
                        if (str.Substring(0, 7) == "Seat 1:")
                        {
                            
                            if (str.Replace(seats[0], "").IndexOf("[") != -1)
                            {
                                cards[0] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[0].Length, str.Length - (8 + seats[0].Length)));
                                
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 2:")
                        {
                            if (str.Replace(seats[1], "").IndexOf("[") != -1)
                            {
                                cards[1] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[1].Length, str.Length - (8 + seats[1].Length)));
                              
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 3:")
                        {
                            if (str.Replace(seats[2], "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                cards[2] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[2].Length, str.Length - (8 + seats[2].Length)));
                                //Console.WriteLine(str.Substring(8 + seat3.Length, str.Length - (8 + seat3.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 4:")
                        {
                            if (str.Replace(seats[3], "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                cards[3] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[3].Length, str.Length - (8 + seats[3].Length)));
                                //Console.WriteLine(str.Substring(8 + seat4.Length, str.Length - (8 + seat4.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 5:")
                        {
                            if (str.Replace(seats[4], "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                cards[4] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[4].Length, str.Length - (8 + seats[4].Length)));
                                //Console.WriteLine(str.Substring(8 + seat5.Length, str.Length - (8 + seat5.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 6:")
                        {
                            if (str.Replace(seats[5], "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                cards[5] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[5].Length, str.Length - (8 + seats[5].Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 7:")
                        {
                            if (str.Replace(seats[6], "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                cards[6] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[6].Length, str.Length - (8 + seats[6].Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 8:")
                        {
                            if (str.Replace(seats[7], "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                cards[7] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[7].Length, str.Length - (8 + seats[7].Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        else if (str.Substring(0, 7) == "Seat 9:")
                        {
                            if (str.Replace(seats[8], "").IndexOf("[") != -1)//str.Substring (8 + seat1.Length, str.Length -(8 + seat1.Length)).IndexOf("[")!=-1)
                            {
                                cards[8] = Utilidades.Utilidades.extraercartassumary(str.Substring(8 + seats[8].Length, str.Length - (8 + seats[8].Length)));
                                //Console.WriteLine(str.Substring(8 + seat6.Length, str.Length - (8 + seat6.Length)));
                            }
                        }
                        //Console.WriteLine(str);

                    }
                }

                str = reader.ReadLine();
               // str = reader.ReadLine();
                if (seats[0] != null)
                { 
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[0]==null ? "": cards[0], 1);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[0] ), Convert.ToDouble(stacks[0]), 1);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[0], 1);
                }
                if (seats[1] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[1] == null ? "" : cards[1], 2);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[1]), Convert.ToDouble(stacks[1]), 2);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[1], 2);
                }
                if (seats[2] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[2] == null ? "" : cards[2], 3);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[2]), Convert.ToDouble(stacks[2]), 3);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[2], 3);
                }
                if (seats[3] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[3] == null ? "" : cards[3], 4);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[3]), Convert.ToDouble(stacks[3]), 4);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[3], 4);
                }
                if (seats[4] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[4] == null ? "" : cards[4], 5);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[4]), Convert.ToDouble(stacks[4]), 5);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[4], 5);
                }
                if (seats[5] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[5] == null ? "" : cards[5], 6);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[5]), Convert.ToDouble(stacks[5]), 6);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[5], 6);
                }
                if (seats[6] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[6] == null ? "" : cards[6], 7);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[6]), Convert.ToDouble(stacks[6]), 7);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[6], 7);
                }
                if (seats[7] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[7] == null ? "" : cards[7], 8);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[7]), Convert.ToDouble(stacks[7]), 8);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[7], 8);
                }
                if (seats[8] != null)
                {
                    c.insertCartas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), cards[8] == null ? "" : cards[8], 9);
                    f.insertFichas(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), Convert.ToDouble(startingStacks[8]), Convert.ToDouble(stacks[8]), 9);
                    a.insertAsientos(Convert.ToDouble(idmano.Replace("-", "").Replace(" ", "")), seats[8], 9);
                }
                int totaljugadores = 0;
                foreach(string jgdr in seats)
                {
                    if (jgdr != null)
                    {
                        totaljugadores = totaljugadores + 1;
                    }
                }
                
                r.insertResumen(Convert.ToDouble(idmano.Replace("-","").Replace(" ", "")), Convert.ToDateTime(fecha), nombreMesa, stake, Convert.ToDouble(rake.Replace(".", ",")), totaljugadores, herocards, board.Replace(" ", ""), txt.Replace(Convert.ToChar(92),'/').Replace("\\","/"), new FileInfo(txt).Length, Convert.ToDouble(bote), jugadoresMesa, "Winamax");


               // str = reader.ReadLine();
               // str = reader.ReadLine();

            }
        }
        public int asiento(string name)
        {

            int num = 0;
            if (name == seats[0])
            {
                num = 1;
            }
            else if (name == seats[1])
            {
                num = 2;
            }
            else if (name == seats[2])
            {
                num = 3;
            }
            else if (name == seats[3])
            {
                num = 4;
            }
            else if (name == seats[4])
            {
                num = 5;
            }
            else if (name == seats[5])
            {
                num = 6;
            }
            else if (name == seats[6])
            {
                num = 7;
            }
            else if (name == seats[7])
            {
                num = 8;
            }
            else if (name == seats[8])
            {
                num = 9;
            }

            return num;

        }
        public void asientochipssuma(string name, decimal cant)
        {
            if (name == seats[0])
            {
                stacks[0] = stacks[0] + cant;
            }
            else if (name == seats[1])
            {
                stacks[1] = stacks[1] + cant;
            }
            else if (name == seats[2])
            {
                stacks[2] = stacks[2] + cant;
            }
            else if (name == seats[3])
            {
                stacks[3] = stacks[3] + cant;
            }
            else if (name == seats[4])
            {
                stacks[4] = stacks[4] + cant;
            }
            else if (name == seats[5])
            {
                stacks[5] = stacks[5] + cant;
            }
            else if (name == seats[6])
            {
                stacks[6] = stacks[6] + cant;
            }
            else if (name == seats[7])
            {
                stacks[7] = stacks[7] + cant;
            }
            else if (name == seats[8])
            {
                stacks[8] = stacks[8] + cant;
            }
        }
        public void asientochipsresta(string name, decimal cant)
        {


            if (name == seats[0])
            {
                stacks[0] = stacks[0] - cant;
            }
            else if (name == seats[1])
            {
                stacks[1] = stacks[1] - cant;
            }
            else if (name == seats[2])
            {
                stacks[2] = stacks[2] - cant;
            }
            else if (name == seats[3])
            {
                stacks[3] = stacks[3] - cant;
            }
            else if (name == seats[4])
            {
                stacks[4] = stacks[4] - cant;
            }
            else if (name == seats[5])
            {
                stacks[5] = stacks[5] - cant;
            }
            else if (name == seats[6])
            {
                stacks[6] = stacks[6] - cant;
            }
            else if (name == seats[7])
            {
                stacks[7] = stacks[7] - cant;
            }
            else if (name == seats[8])
            {
                stacks[8] = stacks[8] - cant;
            }

        }
    }
}
