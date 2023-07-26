using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTesting
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=5eDB";
            string sqlQuery = "SELECT Id, NumberOfDice, DamageDice, Bonus FROM Spell;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Process the data returned by the query
                        while (reader.Read())
                        {
                            // Access data using column names or indexes
                            int spellId = (int)reader["Id"];
                            var NumberOfDice = reader["NumberOfDice"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NumberOfDice")) : 0;
                            var DamageDice = reader["DamageDice"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DamageDice")) : 0;
                            string bonusString = reader["Bonus"] != DBNull.Value ? reader["Bonus"].ToString() : "0";
                            int bonus;
                            if (int.TryParse(bonusString, out bonus))
                            {
                                // Conversion successful
                                // "bonus" contains the int value from the string
                            }
                            else
                            {
                                // Conversion failed, set "bonus" to 0
                                bonus = 0;
                            }
                            // ... (and so on for other columns)
                            Console.WriteLine($"{spellId} - {NumberOfDice} - {DamageDice} - {bonus}");
                        }
                    }
                }
            }
        }
    }
}
