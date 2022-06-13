using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace DespieceArmarios.Clases
{
    public static class Bd
    {
        // Cadenas de conexion de dos servidores diferentes 
        private static string MySqlConnectionString = "Server=localhost;Port=3307;Database=lansaque;Uid=root;Pwd=root;";
        private static string SqlServerConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=baloncesto;Integrated Security=True";

        //ejemplo de dos formas de definir el get. Si solo es una linea.
        //public static int Numero { get { return 6; } }
        //public static int NumeroLoMismo => 6;
        public static DbProviderFactory Factory => MySql.Data.MySqlClient.MySqlClientFactory.Instance;
        // Cambiar el metodo de llamada dependiendo de la base de datos que usemos
        public static DbConnection GetConnection(bool open = true) => GetMySqlConnection(open);
        private static DbConnection GetMySqlConnection(bool open = true, bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {

            //try
            //{
            //    System.IO.StreamReader file = new System.IO.StreamReader("./mysql.conn");
            //    string linea = "";
            //    while ((linea += file.ReadLine()).Equals("")) { }
            //    Console.WriteLine(linea);
            //    MySqlConnectionString = linea.Trim();
            //    file.Close();
            //}
            //catch (FileNotFoundException ffe)
            //{
            //    MessageBox.Show($"Error en la ubicacion del archivo mysql.conn");
            //    Console.WriteLine($"Error Bd.GetMySqlConnection: {ffe.Message }");
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Error en la cadena de conexion para MySQL");
            //    Console.WriteLine($"Error Bd.GetMySqlConnection: {e.Message }");
            //}

            var csb = Factory.CreateConnectionStringBuilder();
            csb.ConnectionString = MySqlConnectionString;
            ((dynamic)csb).AllowZeroDateTime = allowZeroDatetime;
            ((dynamic)csb).ConvertZeroDateTime = convertZeroDatetime;
            var conn = Factory.CreateConnection();
            conn.ConnectionString = csb.ConnectionString;
            if (open) conn.Open();
            return conn;
        }

        private static DbConnection GetSqlServerConnection(bool open = true)
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader("./sqlserver.conn");
                string linea = "";
                while ((linea += file.ReadLine()).Equals("")) { }
                Console.WriteLine(linea);
                SqlServerConnectionString = linea.Trim();
                file.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la cadena de conexion para SQL Server");
            }

            var conn = new SqlConnection(SqlServerConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}
