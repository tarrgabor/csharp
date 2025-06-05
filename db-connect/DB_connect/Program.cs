using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB_connect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connection string to the database
            string connectionString = "Server=localhost;Database=adatbazis;User Id=root;Password='';";

            // Kapcsolat létrehozása
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Kapcsolat megnyitása
                    connection.Open();
                    Console.WriteLine("Sikeresen csatlakozott az adatbázishoz.");

                    // Adatbázis műveletek itt
                }
                catch (Exception ex)
                {
                    // Hibakezelés
                    Console.WriteLine($"Hiba történt: {ex.Message}");
                }
                finally
                {
                    // Kapcsolat bezárása
                    connection.Close();
                    Console.WriteLine("Kapcsolat bezárva.");
                }
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Kapcsolat megnyitása
                    connection.Open();
                    Console.WriteLine("Sikeresen csatlakozott az adatbázishoz.");
                    
                    // CREATE művelet (rekord hozzáadása)
                    string insertQuery = "INSERT INTO asd (name) VALUES ('Zsolt')";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                       // insertCommand.Parameters.AddWithValue("@ertek2", "Zsolt");
                        int rowsInserted = insertCommand.ExecuteNonQuery();
                        Console.WriteLine($"{rowsInserted} rekord hozzáadva.");
                    }

                    // UPDATE művelet (rekord módosítása)
                    string updateQuery = "UPDATE asd SET name = 'Peti' WHERE id = 2";
                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                    {
                        //updateCommand.Parameters.AddWithValue("@ujErtek", "UjAdat");
                        //updateCommand.Parameters.AddWithValue("@feltetel", "Adat2");
                        int rowsUpdated = updateCommand.ExecuteNonQuery();
                        Console.WriteLine($"{rowsUpdated} rekord módosítva.");
                    }
                    
                    // DELETE művelet (rekord törlése)
                    string deleteQuery = "DELETE FROM asd WHERE id = 3";
                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                    {
                        //deleteCommand.Parameters.AddWithValue("@feltetel", "UjAdat");
                        int rowsDeleted = deleteCommand.ExecuteNonQuery();
                        Console.WriteLine($"{rowsDeleted} rekord törölve.");
                    }

                }
                catch (Exception ex)
                {
                    // Hibakezelés
                    Console.WriteLine($"Hiba történt: {ex.Message}");
                }
                finally
                {
                    // Kapcsolat bezárása
                    connection.Close();
                    Console.WriteLine("Kapcsolat bezárva.");
                }
            }
        }
    }
}
