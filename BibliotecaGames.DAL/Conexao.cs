using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
  public class Conexao
    {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexaoSql"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connectionString);



        public static void Conectar()
        {

            if (connection.State == System.Data.ConnectionState.Closed)
            {

                connection.Open();

            }
        }
        public static void Desconectar()
        {

            if (connection.State == System.Data.ConnectionState.Open)
            {

                connection.Close();

            }
        }
    }
}
