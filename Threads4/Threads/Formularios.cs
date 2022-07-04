using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class Formularios:dbConnection
    {
        private static class parameter
        {
            public static NpgsqlParameter num_jugador(int num_jugador)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_num_jugador", NpgsqlDbType.Integer);
                p.Value = num_jugador;
                return p;
            }
            public static NpgsqlParameter posicion_form_x(Double posicion_form_x)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_posicion_form_x", NpgsqlDbType.Bigint);
                p.Value = posicion_form_x;
                return p;
            }
            public static NpgsqlParameter posicion_form_y(Double posicion_form_y)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_posicion_form_y", NpgsqlDbType.Bigint);
                p.Value = posicion_form_y;
                return p;
            }
            public static NpgsqlParameter Jugadores_mesa(String jugadores_mesa)
            {
                NpgsqlParameter p = new NpgsqlParameter("@p_jugadores_mesa", NpgsqlDbType.Text);
                p.Value = jugadores_mesa;
                return p;
            }
        }

        public Boolean updateFormulario(int num_jugador, Double posicion_form_x, Double posicion_form_y, String jugadores_mesa)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[4];
            npgsqlParameters[0] = parameter.num_jugador(num_jugador);
            npgsqlParameters[1] = parameter.posicion_form_x(posicion_form_x);
            npgsqlParameters[2] = parameter.posicion_form_y(posicion_form_y);
            npgsqlParameters[3] = parameter.Jugadores_mesa(jugadores_mesa);
            return executeInsertProcedure("formulariosupdateposicion", npgsqlParameters);
        }
        public DataTable posicionformbynumjugador(int num_jugador, String jugadores_mesa)
        {
            NpgsqlParameter[] npgsqlParameters = new NpgsqlParameter[2];
            npgsqlParameters[0] = parameter.num_jugador(num_jugador);
            npgsqlParameters[1] = parameter.Jugadores_mesa(jugadores_mesa);
            return executeSelectProcedure("posicionformbynumjugador", npgsqlParameters);
        }

        public Boolean createTempTable(string nombreTabla)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("CREATE TABLE " + nombreTabla + "(posicion_form_x bigint,posicion_form_y bigint,jugadores_mesa text,num_jugador integer);", conn );
                command.ExecuteReader();
                conn.Close();
                return true;
            }
            catch (NpgsqlException e)
            {
                //MessageBox.Show(e.ToString());
                //Console.Write("Error - Connection.executeSelectQuery - Query: " + _procedure + " \nException: " + e.StackTrace.ToString());
                return false;
            }
        }
        public Boolean addPKey(string nombreTabla)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand ("ALTER TABLE "+ nombreTabla +  " ADD CONSTRAINT "+Convert.ToChar(34) + nombreTabla  + Convert.ToChar(34) + " PRIMARY KEY (jugadores_mesa,num_jugador);", conn);
                //NpgsqlCommand command = new NpgsqlCommand("ALTER TABLE " + nombreTabla + " ADD CONSTRAINT 'ID_PKEY' PRIMARY KEY (jugadores_mesa,num_jugador);", conn);

                command.ExecuteReader();
                conn.Close();
                return true;
            }
            catch (NpgsqlException e)
            {
                //MessageBox.Show(e.ToString());
                //Console.Write("Error - Connection.executeSelectQuery - Query: " + _procedure + " \nException: " + e.StackTrace.ToString());
                return false;
            }
        }
        public Boolean insertDatos(string nombreTabla)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO "+ nombreTabla + "(posicion_form_x,posicion_form_y,jugadores_mesa,num_jugador) VALUES(0,0,'5-max',1)," +
                                                                                                                                                            "(0,0,'5-max',2)," +
                                                                                                                                                            "(0,0,'5-max',3)," +
                                                                                                                                                            "(0,0,'5-max',4)," +
                                                                                                                                                            "(0,0,'5-max',5)", conn);
                command.ExecuteReader();
                conn.Close();
                return true;
            }
            catch (NpgsqlException e)
            {
                //MessageBox.Show(e.ToString());
                //Console.Write("Error - Connection.executeSelectQuery - Query: " + _procedure + " \nException: " + e.StackTrace.ToString());
                return false;
            }
        }
        public DataTable executeSelectTabla(string nombreTabla)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                
                NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand("Select * from "+ nombreTabla, conn);
                NpgsqlDataAdapter myAdapter = new NpgsqlDataAdapter();
                myAdapter.SelectCommand = command;
                DataTable = new DataTable();
                myAdapter.Fill(_dataTable);
                conn.Close();
            }
            catch (NpgsqlException e)
            {
               // Console.Write("Error - Connection.executeSelectQuery - Query: " + _procedure + " \nException: " + e.StackTrace.ToString());
            }
            return _dataTable;
        }

    }
}
