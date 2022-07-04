using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class ResumenCash:dbConnection
    {
        private static class parameter
        {
            public static NpgsqlParameter IdMano(Double idmano)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_idmano", NpgsqlDbType.Numeric);
                p.Value = idmano;
                return p;
            }
            public static NpgsqlParameter Fecha(DateTime fecha)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_fecha", NpgsqlDbType.Date);
                p.Value = fecha;
                return p;
            }
            public static NpgsqlParameter Mesa(String mesa)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_mesa", NpgsqlDbType.Text);
                p.Value = mesa;
                return p;
            }
            public static NpgsqlParameter Stake(String stake)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_stake", NpgsqlDbType.Text);
                p.Value = stake;
                return p;
            }
            public static NpgsqlParameter Rake(Double rake)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_rake", NpgsqlDbType.Double);
                p.Value = rake;
                return p;
            }
            public static NpgsqlParameter Jugadores(Int32 jugadores)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_jugadores", NpgsqlDbType.Integer);
                p.Value = jugadores;
                return p;
            }
            public static NpgsqlParameter HeroCards(String heroCards)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_herocards", NpgsqlDbType.Text);
                p.Value = heroCards;
                return p;
            }
            public static NpgsqlParameter Board(String board)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_board", NpgsqlDbType.Text);
                p.Value = board;
                return p;
            }
            public static NpgsqlParameter Txt(String txt)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_txt", NpgsqlDbType.Text);
                p.Value = txt;
                return p;
            }
            public static NpgsqlParameter TxtTamanio(long txtTamanio)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_txt_tamanio", NpgsqlDbType.Bigint);
                p.Value = txtTamanio;
                return p;
            }
            public static NpgsqlParameter Bote(Double bote)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_bote", NpgsqlDbType.Double);
                p.Value = bote;
                return p;
            }
            public static NpgsqlParameter JugadoresMesa(String jugadores_mesa)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_jugadores_mesa", NpgsqlDbType.Text);
                p.Value = jugadores_mesa;
                return p;
            }
            public static NpgsqlParameter Sala(String sala)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_sala", NpgsqlDbType.Text);
                p.Value = sala;
                return p;
            }
        }
        //resumen (idmano, fecha, mesa, stake, rake, jugadores, herocards, board, txt, txt_tamanio, bote) VALUES (p_idmano, p_fecha, p_mesa, p_stake, p_rake, p_jugadores, p_herocards, p_board, p_txt, p_txt_tamanio, p_bote
        public Boolean insertResumen(Double idmano,DateTime fecha,String mesa,String stake, Double rake,Int32 jugadores,String herocards,String board,String txt,long txt_tamanio, Double bote,String jugadoresMesa,String sala)
        {
                NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[13];
                npgsqlParameters[0] = parameter.IdMano(idmano);
                npgsqlParameters[1] = parameter.Fecha(fecha);
                npgsqlParameters[2] = parameter.Mesa(mesa);
                npgsqlParameters[3] = parameter.Stake(stake);
                npgsqlParameters[4] = parameter.Rake(rake);
                npgsqlParameters[5] = parameter.Jugadores(jugadores);
                npgsqlParameters[6] = parameter.HeroCards(herocards);
                npgsqlParameters[7] = parameter.Board(board);
                npgsqlParameters[8] = parameter.Txt(txt);
                npgsqlParameters[9] = parameter.TxtTamanio(txt_tamanio);
                npgsqlParameters[10] = parameter.Bote(bote);
                npgsqlParameters[11] = parameter.JugadoresMesa(jugadoresMesa);
                npgsqlParameters[12] = parameter.Sala(sala);
            return executeInsertProcedure("insertresumen_cash", npgsqlParameters);
        }
        public DataTable txtmaxtamaniobytxt(String txt)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Txt(txt.Replace(Convert.ToChar(92), '/').Replace("\\", "/"));
            return executeSelectProcedure("resumenmaxtxt_tamaniobytxt_cash", npgsqlParameters);            
        }
        public DataTable asientosByTxt(String txt)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Txt(txt.Replace(Convert.ToChar(92), '/').Replace("\\", "/"));
            return executeSelectProcedure("asientosbytxt_cash", npgsqlParameters);
        }
        public DataTable posicionHeroByTxt(String txt)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Txt(txt.Replace(Convert.ToChar(92), '/').Replace("\\", "/"));
            return executeSelectProcedure("posicionherobytxt_cash", npgsqlParameters);
        }
        public DataTable jugadoresmesaresumenbytxt(String txt)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Txt(txt.Replace(Convert.ToChar(92), '/').Replace("\\", "/"));
            return executeSelectProcedure("jugadoresmesaresumenbytxt_cash", npgsqlParameters);
        }

        
    }
}
