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
    class ManosTorneo : dbConnection
    {
        private static class parameter
        {
            public static NpgsqlParameter IdMano(Double idmano)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_idmano", NpgsqlDbType.Bigint);
                p.Value = idmano;
                return p;
            }
            public static NpgsqlParameter Movimiento(Int32 movimiento)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_movimiento", NpgsqlDbType.Integer);
                p.Value = movimiento;
                return p;
            }
            public static NpgsqlParameter Tipo(String tipo)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_tipo", NpgsqlDbType.Text);
                p.Value = tipo;
                return p;
            }
            public static NpgsqlParameter Cantidad(Double cantidad)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_cantidad", NpgsqlDbType.Double);
                p.Value = cantidad;
                return p;
            }
            public static NpgsqlParameter Jugador(String jugador)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_jugador", NpgsqlDbType.Text);
                p.Value = jugador;
                return p;
            }
            public static NpgsqlParameter Board(String board)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_board", NpgsqlDbType.Text);
                p.Value = board;
                return p;
            }
            public static NpgsqlParameter Bote(Double bote)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_bote", NpgsqlDbType.Double);
                p.Value = bote;
                return p;
            }
            public static NpgsqlParameter Ronda(Int32 ronda)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_ronda", NpgsqlDbType.Integer);
                p.Value = ronda;
                return p;
            }
            public static NpgsqlParameter Posicion(Int32 posicion)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_posicion", NpgsqlDbType.Integer);
                p.Value = posicion;
                return p;
            }
        }

        public DataTable ManoById(Double idMano)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.IdMano(idMano);
             return executeSelectProcedure("manobyid_torneo", npgsqlParameters);
        }

        public DataTable cbet(String jugador)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Jugador(jugador);
            return executeSelectProcedure("cbet_torneo", npgsqlParameters);
        }
        public Boolean insertManos(Double idmano, Int32 movimiento, String tipo,Double cantidad,String jugador,String board,Double bote,Int32 ronda,Int32 posicion)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[9];
            npgsqlParameters[0] = parameter.IdMano(idmano);
            npgsqlParameters[1] = parameter.Movimiento(movimiento);
            npgsqlParameters[2] = parameter.Tipo(tipo);
            npgsqlParameters[3] = parameter.Cantidad(cantidad);
            npgsqlParameters[4] = parameter.Jugador(jugador);
            npgsqlParameters[5] = parameter.Board(board);
            npgsqlParameters[6] = parameter.Bote(bote);
            npgsqlParameters[7] = parameter.Ronda(ronda);
            npgsqlParameters[8] = parameter.Posicion(posicion);
            return executeInsertProcedure("insertmanos_torneo", npgsqlParameters);
        }
 
    }
}
