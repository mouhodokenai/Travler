using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using GMap.NET;

namespace WinFormsApp3
{
    public class DatabaseManager
    {
        private string host = "localhost"; // Имя хоста
        private string database = "traveler"; // Имя базы данных
        private string user = "root"; // Имя пользователя
        private string password = "MA58sh62."; // Пароль пользователя

        private string connectionString;

        // Инициализируйте строку подключения в конструкторе
        public DatabaseManager()
        {
            // Укажите свою строку подключения здесь
            connectionString = $"Server={host};Database={database};User ID={user};Password={password};";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void TestConnection()
        {
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    MessageBox.Show("Connection Open!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Cannot open connection! Error: " + ex.Message);
                }
            }
        }

        public void InsertTrip(string country, string city, string landmark, string note, DateTime tripDate, bool isPlan)
        {
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "INSERT INTO trips (countries_name, cities_name, attractions, notes, trip_date, isPlan) VALUES (@country, @city, @landmark, @note, @tripDate, @isPlan)";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@landmark", landmark);
                        cmd.Parameters.AddWithValue("@note", note);
                        cmd.Parameters.AddWithValue("@tripDate", tripDate);
                        cmd.Parameters.AddWithValue("@isPlan", isPlan);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.Message);
                }
            }
        }

        public void EditTrip(int id, string country, string city, string landmark, string note, DateTime tripDate, bool isPlan)
        {
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "UPDATE trips SET countries_name = @country, cities_name = @city, attractions = @landmark, notes = @note, trip_date = @tripDate, isPlan = @isPlan WHERE id = @id;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@landmark", landmark);
                        cmd.Parameters.AddWithValue("@note", note);
                        cmd.Parameters.AddWithValue("@tripDate", tripDate);
                        cmd.Parameters.AddWithValue("@isPlan", isPlan);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.Message);
                }
            }
        }

        public void TransTrip()
        {
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();

                    // Проверка наличия запланированных путешествий с истекшей датой
                    string countQuery = "SELECT COUNT(*) FROM trips WHERE isPlan = 1 AND trip_date < CURDATE();";
                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, cnn))
                    {
                        int count = Convert.ToInt32(countCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            // Если такие путешествия существуют, показываем сообщение и выполняем обновление
                            MessageBox.Show("Дата запланированных путешествий истекла, перемещены в завершенные путешествия", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string updateQuery = "UPDATE trips SET isPlan = 0 WHERE trip_date < CURDATE();";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, cnn))
                            {
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error updating data: " + ex.Message);
                }
            }
        }


        public void DeleteTrip(int id)
        {
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "delete from trips where id = @id;";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.Message);
                }
            }
        }

        // Метод для получения списка стран
        public List<string> GetCountries()
        {
            List<string> countries = new List<string>();
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "SELECT name FROM countries";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            countries.Add(reader["name"].ToString());
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }
            return countries;
        }

        // Метод для получения списка городов по имени страны
        public List<string> GetCities(string countryName)
        {
            List<string> cities = new List<string>();
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "SELECT name FROM cities WHERE countries_name = @countryName";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@countryName", countryName);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cities.Add(reader["name"].ToString());
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }
            return cities;
        }
        public List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip>();
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "SELECT id, trip_date, countries_name, cities_name, attractions, notes FROM trips where isPlan = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Trip trip = new Trip
                            {
                                TripDate = reader.GetDateTime("trip_date"),
                                Country = reader.GetString("countries_name"),
                                City = reader.GetString("cities_name"),
                                Landmark = reader.GetString("attractions"),
                                Note = reader.GetString("notes"),
                                Id = reader.GetInt32("id")
                            };
                            trips.Add(trip);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }
            return trips;
        }

        public List<Trip> GetPlans()
        {
            List<Trip> plans = new List<Trip>();
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "SELECT id, trip_date, countries_name, cities_name, attractions, notes FROM trips where isPlan = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Trip trip = new Trip
                            { 
                                TripDate = reader.GetDateTime("trip_date"),
                                Country = reader.GetString("countries_name"),
                                City = reader.GetString("cities_name"),
                                Landmark = reader.GetString("attractions"),
                                Note = reader.GetString("notes"),
                                Id = reader.GetInt32("id")
                            };
                            plans.Add(trip);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }
            return plans;
        }
        public string GetPlansStat()
        {
            string stat = "Вы планируете посетить 0 стран 0 городов";
            int cities;
            int countries;
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "SELECT COUNT(DISTINCT countries_name) AS страны, COUNT(DISTINCT cities_name) AS города FROM trips where isPlan = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            {
                                cities = reader.GetInt32("города");
                                countries = reader.GetInt32("страны");
                            };
                            stat = "Вы планируете посетить " + countries + " стран " + cities + " городов";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }
            return stat;
        }

        public string GetTripsStat()
        {
            string stat = "Вы посетили 0 стран 0 городов";
            int cities;
            int countries;
            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    cnn.Open();
                    string query = "SELECT COUNT(DISTINCT countries_name) AS страны, COUNT(DISTINCT cities_name) AS города FROM trips where isPlan = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            {
                                cities = reader.GetInt32("города");
                                countries = reader.GetInt32("страны");
                            };
                            stat = "Вы посетили " + countries + " стран " + cities + " городов";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }
            return stat;
        }
        public Dictionary<string, PointLatLng> GetCitiesWithCoordinates(bool isPlan)
        {
            Dictionary<string, PointLatLng> citiesWithCoordinates = new Dictionary<string, PointLatLng>();

            using (MySqlConnection cnn = GetConnection())
            {
                try
                {
                    string query;
                    cnn.Open();
                    if (isPlan)
                    {
                        query = "SELECT DISTINCT cities.name, lat, lng from cities join trips where cities.name = trips.cities_name and trips.isPlan = 1;";
                    }
                    else
                    {
                        query = "SELECT DISTINCT cities.name, lat, lng from cities join trips where cities.name = trips.cities_name and trips.isPlan = 0;";
                    }
                  
                    using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string cityName = reader["name"].ToString();
                            double latitude = Convert.ToDouble(reader["lat"]);
                            double longitude = Convert.ToDouble(reader["lng"]);
                            PointLatLng coordinates = new PointLatLng(latitude, longitude);
                            citiesWithCoordinates.Add(cityName, coordinates);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }

            return citiesWithCoordinates;
        }


    }



    // Класс Trip для хранения данных о путешествиях
    public class Trip
    {
        public int Id { get; set; }
        public DateTime TripDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public string Note { get; set; }
        public bool isPlan { get; set; }
        public Trip(int Id, DateTime TripDate, string Country, string City, string Landmark, string Note, bool isPlan)
        {
            this.Id = Id;
            this.TripDate = TripDate;
            this.Country = Country;
            this.City = City;
            this.Landmark = Landmark;
            this.Note = Note;
            this.isPlan = isPlan;
        }

        public Trip()
        {

        }

    }


}

