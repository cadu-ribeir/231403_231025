using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17273
{
    public class Banco
    {
        // Criando as variaveis publicas para conexão e consulta serão usadas em todo o projeto
        // Connection responsável pela conexão com o MySQL
        public static MySqlConnection Conexao;
        // Command responsável pelas instruções SQL a serem exwcutadas
        public static MySqlCommand Comando;
        // Adapter responsavel por inserir dados em uma dataTable
        public static MySqlDataAdapter Adaptador;
        // DataTable responsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;



        public static void AbrirConexao()
        {
            try
            {
                // Estabelece os parametros para a conexao  com o banco.
                Conexao = new MySqlConnection("server=localhost;port=3306;uid=root;pwd= ");

                // Abre a conexão com o banco de dados.
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public static void FecharConexao()
        {
            try
            {
                // Fecha a conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void CriarBanco()
        {
            try
            {
                // Chama a função para abertura de conexão com o banco
                AbrirConexao();

                // Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);

                //Executa a Query no MySQL (Raio do Workbench)
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades" +
                                            "(id integer auto_increment primary key, " + "nome char(40), " +
                                            "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();

                //  Chama a função para o fechamento de conexão com o banco
                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXIST cidades" +
                "(id ibteger auto_increment primary key, " + "nome char(40). " +
                "uf char(02))", Conexao);
            Comando.ExecuteNonQuery();

            Comando = new MySqlCommand("CREATE TABLE IF NOT EXIST Marcas" +
                "(id ibteger auto_increment primary key, " + 
                "marca char(20))", Conexao);
            Comando.ExecuteNonQuery();
        }


    }

    
}
