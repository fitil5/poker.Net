using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class CartasCash:dbConnection
    {
        private static class parameter
        {
            public static NpgsqlParameter IdMano(Double idmano)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_idmano", NpgsqlDbType.Numeric);
                p.Value = idmano;
                return p;
            }
            public static NpgsqlParameter Cartas(String cartas)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_cartas", NpgsqlDbType.Text);               
                    p.Value = cartas;                
                return p;
            }
            public static NpgsqlParameter Posicion(Int32 posicion)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_posicion", NpgsqlDbType.Integer);
                p.Value = posicion;
                return p;
            }

        }
        public Boolean insertCartas(Double idmano, String cartas, Int32 posicion)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[3];
            npgsqlParameters[0] = parameter.IdMano(idmano);
            npgsqlParameters[1] = parameter.Cartas(cartas);
            npgsqlParameters[2] = parameter.Posicion(posicion);
            
            return executeInsertProcedure("insertcartas_cash", npgsqlParameters);
        }

    }
}
