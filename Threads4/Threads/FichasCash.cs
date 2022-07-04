using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class FichasCash:dbConnection
    {
        private static class parameter
        {
            public static NpgsqlParameter IdMano(Double idmano)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_idmano", NpgsqlDbType.Numeric);
                p.Value = idmano;
                return p;
            }
            public static NpgsqlParameter Inicio(Double inicio)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_inicio", NpgsqlDbType.Double);
                p.Value = inicio;
                return p;
            }
            public static NpgsqlParameter Final(Double final)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_final", NpgsqlDbType.Double);
                p.Value = final;
                return p;
            }
            public static NpgsqlParameter Posicion(int posicion)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_posicion", NpgsqlDbType.Integer);
                p.Value = posicion;
                return p;
            }

        }
        public Boolean insertFichas(Double idmano, Double inicio, Double final, int posicion)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[4];
            npgsqlParameters[0] = parameter.IdMano(idmano);
            npgsqlParameters[1] = parameter.Inicio(inicio);
            npgsqlParameters[2] = parameter.Final(final);
            npgsqlParameters[3] = parameter.Posicion(posicion);

            return executeInsertProcedure("insertfichas_cash", npgsqlParameters);
        }
    }
}
