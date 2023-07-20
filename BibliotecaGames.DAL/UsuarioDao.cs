using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
   public class UsuarioDao
    {
        public Usuario ObterUsuarioPeloUsuarioESenha(string nomeUsuario, string senha)
        {
            try
            {

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM usuarios WHERE usuario = @USUARIO AND senha = @SENHA";
                command.Parameters.AddWithValue("@USUARIO", nomeUsuario);
                command.Parameters.AddWithValue("@SENHA", senha);

                Conexao.Conectar();


                var reader = command.ExecuteReader();

                Usuario usuarios = null;

                while (reader.Read())
                {
                    usuarios = new Usuario();
                    usuarios.Id = Convert.ToInt32(reader["id"]);
                    usuarios.NomeUsuario = reader["usuario"].ToString();
                    usuarios.Senha = reader["senha"].ToString();
                    usuarios.Perfil = Convert.ToChar(reader["perfil"]);
                }
                return usuarios;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
