using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace UD18
{
    class BD
    {
        public static SqlConnection Abrir(string nombre)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-8C4SS5C\SQLEXPRESS;Initial Catalog=" + nombre + ";Persist Security Info=True;User ID=arnau;Password=arnau1234");
            try
            {
                conexion.Open();
                Console.WriteLine("Se abrió la conexión con el servidor 8C4SS5C y la base de datos "+nombre);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return conexion;
            
        }
        public static SqlConnection Abrir()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-8C4SS5C\SQLEXPRESS;Persist Security Info=True;User ID=arnau;Password=arnau1234");
            try
            {
                conexion.Open();
                Console.WriteLine("Se abrió la conexión con el servidor 8C4SS5C");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return conexion;

        }
        public static void Cerrar(SqlConnection conexion)
        {
            try
            {
                conexion.Close();
                Console.WriteLine("Se cerró la conexión con el servidor");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void CrearDB (SqlConnection conexion, string nombreDB)
        {
            string nombreDB2 = "create database " + nombreDB;
            SqlCommand comando = new SqlCommand(nombreDB2, conexion);
            try
            {
                comando.ExecuteNonQuery();
                Console.WriteLine("La base de datos se ha creado correctamente");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Console.WriteLine("La base de datos" + nombreDB + " ya existe");
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void CrearTabla(SqlConnection conexion, string nombreDB, string comandoCreateTableSql)
        {
            //conexion.Close();
            conexion = BD.Abrir(nombreDB);
            SqlCommand comando = new SqlCommand(comandoCreateTableSql, conexion);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //conexion = BD.Abrir();
        }
        public static void BorrarDB (SqlConnection conexion, string nombreDB)
        {
            SqlCommand comando = new SqlCommand("DROP DATABASE " + nombreDB + ";", conexion);
            comando.ExecuteNonQuery();
        }
        public static void InsertarValor(string nombreBD, string nombreTabla, string codigoValor)
        {
            // método para insertar un string pasado por parámetro en una taba

            // conectamos a la base de datos
            SqlConnection conexion = BD.Abrir(nombreBD);

            // codigoSQL
            string cadena = "INSERT INTO " + nombreTabla + " VALUES " + codigoValor;

            try
            {
                // creamos el objeto con el codigo sql y la conexion
                SqlCommand comando = new SqlCommand(cadena, conexion);

                // ejecutamos el codigo sql en el objeto comando
                comando.ExecuteNonQuery();
                Console.WriteLine("Registro insertado con éxito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // cerramos la conexión con la base de datos creada
                conexion.Close();
            }
        }
    }
}
