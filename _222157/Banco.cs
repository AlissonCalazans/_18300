using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _222157
{
    public class Banco
    {   //Criando as variáveis publicas para conexão e consulta serão usadas em todo o projeto
        //Connection responsável pela conexão com o MySQL
        public static MySqlConnection Conexao;
        //Command responsável pelas instruções SQL a serem executadas
        public static MySqlCommand Comando;
        //Adapter responsável por inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;
        //DataTable responsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;


        public static void AbrirConexao()
        {
            try
            {   //Estabelece os parâmetros para a conexão com o banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");
                //Abre a conexão com o banco de dados
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static void FecharConexao()
        {
            try
            {   
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static void CriarBanco()
        {
            try
            {
                AbrirConexao();
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " + "(id integer auto_increment primary key," + "nome char(40)," + "uf char(2))", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas " + "(id integer auto_increment primary key," + "marca char(20))", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categorias " + "(id integer auto_increment primary key," + "categoria char(20))", Conexao);

                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes " + "(id integer auto_increment primary key, " + 
                    "nome char(40), idCidade integer, dataNasc date, renda decimal (10,2), cpf char(14)," +
                    "foto varchar(100), venda boolean)", Conexao);

                Comando.ExecuteNonQuery();

                FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
    
}
