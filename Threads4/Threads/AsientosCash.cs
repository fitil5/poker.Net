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
    class AsientosCash:dbConnection
    {
        private static class parameter
        {
            public static NpgsqlParameter IdMano(Double idmano)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_idmano", NpgsqlDbType.Numeric);
                p.Value = idmano;
                return p;
            }
            public static NpgsqlParameter Jugador(String jugador)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_jugador", NpgsqlDbType.Text);
                p.Value = jugador;
                return p;
            }
            public static NpgsqlParameter Posicion(Int32 posicion)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_posicion", NpgsqlDbType.Integer);
                p.Value = posicion;
                return p;
            }
        }
        public Boolean insertAsientos(Double idmano,String jugador,Int32 posicion)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[3];
            npgsqlParameters[0] = parameter.IdMano(idmano);
            npgsqlParameters[1] = parameter.Jugador(jugador);
            npgsqlParameters[2] = parameter.Posicion(posicion);
            return executeInsertProcedure("insertasientos_cash", npgsqlParameters);
        }
        public DataTable asientosById(Double idmano)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.IdMano(idmano);
            return executeSelectProcedure("asientosbyid_cash", npgsqlParameters);
        }
        public DataTable evmasjugador(String jugador)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[1];
            npgsqlParameters[0] = parameter.Jugador(jugador);
            return executeSelectProcedure("evmasjugador_cash", npgsqlParameters);
        }
        public DataTable jugadoresall()
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[0];
            return executeSelectProcedure("jugadoresall_cash", npgsqlParameters);
        }



        // idmano, juagador, posicion
    }
}
