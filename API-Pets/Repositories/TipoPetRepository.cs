using API_Pets.Context;
using API_Pets.Domains;
using API_Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Repositories
{
    public class TipoPetRepository : ITipoPet

    {
        //Chamando a classe de conexao do banco 
        PetsContext conexao = new PetsContext();

        //Chamamos o objeto que recebe e executa os comandos do banco
        SqlCommand cmd = new SqlCommand();

        //ALTERAR
        public TipoPet Alterar(int id, TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoPet SET " +
                "Descricao = @descricao WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        //BUSCAR POR ID
        public TipoPet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoPet WHERE IdTipoPet = @id ";

            //Atribuindo variaveis que vem como argumento 
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoPet a = new TipoPet();

            while (dados.Read())
            {
                a.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();
            return a;
        }

        //CADASTRAR
        public TipoPet Cadastrar(TipoPet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO TipoPet (Descricao)" +
                "VALUES (@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            //coamndo para injetar dados no banco
            cmd.ExecuteNonQuery();

            //DML > ExecuteNonQuery

            conexao.Desconectar();
            return a;
        }

        //EXCLUIR
        public void Deletar(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoPet WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        //LER TODOS
        public List<TipoPet> LerTodos()
        {
            //Abrindo conexao
            cmd.Connection = conexao.Conectar();

            //Preparando consulta(query)
            cmd.CommandText = "SELECT * FROM TipoPet";

            SqlDataReader dados = cmd.ExecuteReader();

            //Lista para guardar os tipospet
            List<TipoPet> tipoPets = new List<TipoPet>();

            while (dados.Read())
            {
                tipoPets.Add(
                        new TipoPet()
                        {
                            IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                            Descricao = dados.GetValue(1).ToString()
                        }
                );
            }

            //Fechando conexao 
            conexao.Desconectar();

            return tipoPets;
        }
    }
}
