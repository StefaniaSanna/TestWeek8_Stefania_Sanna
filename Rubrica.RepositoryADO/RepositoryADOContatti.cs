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
   
    public class RepositoryADOContatti : IRepositoryContatti
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Contatto Add(Contatto item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Contatto values (@n,@c)";

                command.Parameters.AddWithValue("@n", item.Nome);
                command.Parameters.AddWithValue("@c", item.Cognome);

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

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "delete Contatto where IdContatto=@i";
                command.Parameters.AddWithValue("@i", id);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public List<Contatto> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Contatto";
                SqlDataReader reader = command.ExecuteReader();
                List<Contatto> contatti = new List<Contatto>();

                while (reader.Read())
                {
                    var id = reader["IdContatto"];
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];

                    Contatto nuovoContatto = new Contatto()
                    {
                        IdContatto = (int)id,
                        Nome = (string)nome,
                        Cognome = (string)cognome
                    };
                    contatti.Add(nuovoContatto);
                }
                connection.Close();
                return contatti;
            }
        }

        public Contatto GetByCode(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Contatto where IdContatto=@id";
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                Contatto nuovoContatto = new Contatto();

                while (reader.Read())
                {
                    var Id = reader["IdContatto"];
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];

                    nuovoContatto.IdContatto = (int)Id;
                    nuovoContatto.Nome = (string)nome;
                    nuovoContatto.Cognome = (string)cognome;
                }
                if (nuovoContatto.IdContatto != 0)
                {
                    connection.Close();
                    return nuovoContatto;
                }
                return null;
            }
        }
    }
}
