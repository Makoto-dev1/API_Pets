using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Context
{
    public class PetsContext
    {
        SqlConnection con = new SqlConnection();

        public PetsContext() 
        {
            con.ConnectionString = @"Data Source=desktop-19b9jic\sqlexpress;Initial Catalog=Clinica;User ID=sa;Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}      
