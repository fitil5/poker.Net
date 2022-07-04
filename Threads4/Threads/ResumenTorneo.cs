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
    class ResumenTorneo : dbConnection
    {
        private static class parameter
        {
            public static NpgsqlParameter IdMano(Double idmano)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_idmano", NpgsqlDbType.Bigint);
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
            public static NpgsqlParameter Buyin(String buyin)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_buyin", NpgsqlDbType.Text);
                p.Value = buyin;
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
        }
        //resumen (idmano, fecha, mesa, stake, rake, jugadores, herocards, board, txt, txt_tamanio, bote) VALUES (p_idmano, p_fecha, p_mesa, p_stake, p_rake, p_jugadores, p_herocards, p_board, p_txt, p_txt_tamanio, p_bote
        public Boolean insertResumen(Double idmano, DateTime fecha, String mesa, Int32 jugadores, String herocards, String board, String txt, long txt_tamanio, Double bote, String jugadoresMesa)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[10];
            npgsqlParameters[0] = parameter.IdMano(idmano);
            npgsqlParameters[1] = parameter.Fecha(fecha);
            npgsqlParameters[2] = parameter.Mesa(mesa);
            npgsqlParameters[3] = parameter.Jugadores(jugadores);
            npgsqlParameters[4] = parameter.HeroCards(herocards);
            npgsqlParameters[5] = parameter.Board(board);
            npgsqlParameters[6] = parameter.Txt(txt);
            npgsqlParameters[7] = parameter.TxtTamanio(txt_tamanio);
            npgsqlParameters[8] = parameter.Bote(bote);
            npgsqlParameters[9] = parameter.JugadoresMesa(jugadoresMesa);
            return executeInsertProcedure("insertresumen_cash", npgsqlParameters);
        }
        public DataTable txtmaxtamaniobytxt(String txt)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Txt(txt);
            return executeSelectProcedure("resumenmaxtxt_tamaniobytxt_torneo", npgsqlParameters);            
        }
        public DataTable asientosByTxt(String txt)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Txt(txt);
            return executeSelectProcedure("asientosbytxt_torneo", npgsqlParameters);
        }
        public DataTable posicionHeroByTxt(String txt)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Txt(txt);
            return executeSelectProcedure("posicionherobytxt_torneo", npgsqlParameters);
        }


    }
}
