using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BibliotecaGames.DAL
{
    public class JogodDao
    {

        public List<Jogo> ObterTodosOsJogos()
        {
            try
            {

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM jogos";

                Conexao.Conectar();
                var reader = command.ExecuteReader();

                var jogos = new List<Jogo>();

                while (reader.Read())
                {
                    var jogo = new Jogo();
                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Imagem = reader["imagem"].ToString();
                    jogo.DataCompra = reader["data_compra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["data_compra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valor_pago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valor_pago"]);
                    jogos.Add(jogo);
                }
                return jogos;
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
        public Jogo ObterJogoPeloId(int id)
        {
            try
            {

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM jogos where id = @id";
                command.Parameters.AddWithValue("@id", id);

                Conexao.Conectar();
                var reader = command.ExecuteReader();

                Jogo jogo = null;


                while (reader.Read())
                {
                    jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Imagem = reader["imagem"].ToString();
                    jogo.DataCompra = reader["data_compra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["data_compra"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = reader["valor_pago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valor_pago"]);
                    jogo.IdEditor = Convert.ToInt32(reader["id_editor"]);
                    jogo.IdGenero = Convert.ToInt32(reader["id_genero"]);

                }

                return jogo;


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
        public int InserirJogo(Jogo jogo)
        {
            try
            {

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO[dbo].[jogos]
                                       ([titulo]
                                       ,[valor_pago]
                                       ,[data_compra]
                                       ,[id_genero]
                                       ,[id_editor]
                                       ,[imagem])
                                  VALUES
                                       (@titulo, 
                                       @valor_pago,
                                       @data_compra, 
                                       @id_genero, 
                                       @id_editor,
                                       @imagem)";
                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@valor_pago", jogo.ValorPago);
                command.Parameters.AddWithValue("@data_compra", jogo.DataCompra);
                command.Parameters.AddWithValue("@id_genero", jogo.IdGenero);
                command.Parameters.AddWithValue("@id_editor", jogo.IdEditor);
                command.Parameters.AddWithValue("@imagem", jogo.Imagem);

                Conexao.Conectar();

                return command.ExecuteNonQuery();


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
        public int  AtualizarJogo(Jogo jogo)
        {
            try
            {

                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = @"UPDATE[dbo].[jogos]
                                        SET([titulo] = @titulo
                                       ,[valor_pago] = @valor_pago
                                       ,[data_compra] = @data_compra 
                                       ,[id_genero] =  @id_genero
                                       ,[id_editor] =  @id_editor
                                       ,[imagem]) = @imagem
                                      WHERE id = @id";

                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@valor_pago", jogo.ValorPago);
                command.Parameters.AddWithValue("@data_compra", jogo.DataCompra);
                command.Parameters.AddWithValue("@id_genero", jogo.IdGenero);
                command.Parameters.AddWithValue("@id_editor", jogo.IdEditor);
               // command.Parameters.AddWithValue("@imagem", jogo.Imagem);

                Conexao.Conectar();

                return command.ExecuteNonQuery();


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
    



