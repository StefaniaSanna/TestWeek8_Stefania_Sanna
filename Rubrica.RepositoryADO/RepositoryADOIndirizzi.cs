using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryADO
{
    public class RepositoryADOIndirizzi : IRepositoryIndirizzi
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Indirizzo Add(Indirizzo item)  
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Indirizzo values (@t,@v,@c,@cap,@p,@n,@i)";

                command.Parameters.AddWithValue("@t", item.Tipologia);
                command.Parameters.AddWithValue("@v", item.Via);
                command.Parameters.AddWithValue("@c", item.Citta);
                command.Parameters.AddWithValue("@cap", item.Cap);
                command.Parameters.AddWithValue("@p", item.Provincia);
                command.Parameters.AddWithValue("@n", item.Nazione);
                command.Parameters.AddWithValue("@i", item.IdContatto);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return item;
                }
                connection.Close();
                return null;
            }
        }

        public bool IsThereAdress(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Indirizzo where IdContatto=@id";
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                Indirizzo indirizzoEsistente = new Indirizzo();

                while (reader.Read())
                {
                    var idContatto = reader["IdContatto"];
                    indirizzoEsistente.IdContatto = (int)idContatto;
                }
                if (indirizzoEsistente.IdContatto != 0)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
        }
    }
}
