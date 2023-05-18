using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _222157.Models
{
    internal class Cliente
    {
        public int id { get; set; }

        public string nome { get; set; }
        public int idCidade { get; set; }
        public DateTime dataNasc { get; set; }
        public double renda { get; set; }
        public string cpf { get; set; }
        public string foto { get; set; }
        public Boolean venda { get; set; }

        public void Alterar()
        {
            try
            {   //Abre a conexão com o banco
                Banco.AbrirConexao();
                //Alimenta o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("Update clientes set nome = @nome, idCidade = @idCidade, dataNasc = @dataNasc, renda = @renda, cpf = @cpf, foto = @foto, venda = @venda where id = @id", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo
                Banco.Comando.Parameters.AddWithValue("@nome", nome); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@renda", renda); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@foto", foto); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@venda", venda); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@id", id);
                //Executa o Comando, no MYSQL, tem a função do Raio do Worlbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void Excluir()
        {
            try
            {   //Abre a conexão com o banco    
                Banco.AbrirConexao();
                //Alimenta o método Command com a intstrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("delete from clientes where id = @id", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo
                Banco.Comando.Parameters.AddWithValue("@id", id);
                //Executa o comando, no MYSQL, tem a função do Raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("SELECT cl.*, ci.nome cidade, ci.uf " +
                    "From Clientes cl inner join Cidades ci on (ci.id = cl.idCidade)" +
                    "where cl.nome like ?Nome order by cl.nome", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@Nome", nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();

                return Banco.datTabela;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void Incluir()
        {
            try
            {   //Abre a conexão com o banco
                Banco.AbrirConexao();
                //Alimenta o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("INSERT INTO Clientes (nome, idCidade, dataNasc, renda, cpf, foto, venda) VALUES (@nome, @idCidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo
                Banco.Comando.Parameters.AddWithValue("@nome", nome); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@renda", renda); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@foto", foto); //Parâmetro String
                Banco.Comando.Parameters.AddWithValue("@venda", venda); //Parâmetro String
                //Executa o Comando, no MYSQL, tem a função do Raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

