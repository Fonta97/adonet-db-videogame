using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public static class VideogiocoManager
    {
        static string connessioneDatabase = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True;";
        public static void InserisciVideogame(int id, string name, string overview, DateTime release_date, DateTime created_at, DateTime update_at, int sofware_house)
        {
            Videogioco NuovoAereoporto = new Videogioco(id, name, overview, release_date, created_at, update_at, sofware_house);

            string query = "INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id) VALUES (@name, @overview, @release_date, @created, @update, @software_house_id)";

            try
            {
                using (SqlConnection connessione = new SqlConnection(connessioneDatabase))
                {
                    connessione.Open();
                    SqlCommand cmd = new SqlCommand(query, connessione);

                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@overview", overview));
                    cmd.Parameters.Add(new SqlParameter("@release_date", release_date));
                    cmd.Parameters.Add(new SqlParameter("@created", created_at));
                    cmd.Parameters.Add(new SqlParameter("@update", update_at));
                    cmd.Parameters.Add(new SqlParameter("@software_house_id", sofware_house));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void GetVideogiocoById(int id)
        {

            string query = "SELECT * FROM videogames WHERE id = @id";
            using SqlConnection connessione = new SqlConnection(connessioneDatabase);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand(query, connessione);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"\nID: {reader["id"]}, \nName: {reader["name"]}, \nOverview: {reader["overview"]}, \nRilasciato il: {reader["release_date"]}, \nCreato il: {reader["created_at"]}, \nAggiornato il: {reader["updated_at"]} ");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void GetVideogiocoByName(string name)
        {

            string query = "SELECT * FROM videogames WHERE name LIKE @nome";
            using SqlConnection connessione = new SqlConnection(connessioneDatabase);

            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand(query, connessione);
                cmd.Parameters.AddWithValue("@nome", "%" + name + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"\nID: {reader["id"]}, \nName: {reader["name"]}, \nOverview: {reader["overview"]}, \nRilasciato il: {reader["release_date"]}, \nCreato il: {reader["created_at"]}, \nAggiornato il: {reader["updated_at"]} ");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Delete(int id)
        {
            using (SqlConnection connessione = new SqlConnection(connessioneDatabase))
            {
                try
                {
                    connessione.Open();

                    string query = "DELETE FROM videogames where id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connessione))
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Videogioco eliminato con successo!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}