using InternationalCitySearch.Core.DataInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InternationalCitySearch.DataAccess.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        public List<string> GetCities(string searchString)
        {
            List<string> cities = new List<string>();
            /* something like...

            // SQL query
            string query = "SELECT * FROM cities WHERE city_name LIKE @searchString + '%'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter for the prefix
                    command.Parameters.AddWithValue("@prefix", prefix);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the city_name column is of type varchar or nvarchar
                            string cityName = reader.GetString(reader.GetOrdinal("city_name"));
                            cities.Add(cityName);
                        }
                    }
                }
            }
            or if too slow trie search query, elasticsearch/lucene query, etc
            */

            return cities;
        }
    }
}
