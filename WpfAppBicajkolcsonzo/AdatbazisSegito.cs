using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppBicajkolcsonzo
{
    internal class DatabaseHelper
    {
        string connectionString = "server=localhost;user=root;database=biziglikolcsonzorendszer;port=3306;";


        public List<BicajJargany> GetBicajJarganyList()
        {
            List<BicajJargany> bicajJarganyList = new List<BicajJargany>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BicajJargany";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BicajJargany bicajJargany = new BicajJargany();
                    bicajJargany.BicajAzon = (int)reader["bicajAzon"];
                    bicajJargany.GyartoAdatok = (int)reader["gyartoAdatok"];
                    bicajJargany.Tipus = (bool)reader["tipus"];
                    bicajJargany.BicikliNeve = reader["bicikliNeve"].ToString();
                    bicajJargany.BerlesiArOrankent = (int)reader["berlesiArOrankent"];

                    bicajJarganyList.Add(bicajJargany);
                }
            }

            return bicajJarganyList;
        }

        public List<BerloEmber> GetBerloEmberList()
        {
            List<BerloEmber> berloEmberList = new List<BerloEmber>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BerloEmber";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BerloEmber berloEmber = new BerloEmber();
                    berloEmber.BerloAzon = (int)reader["berloAzon"];
                    berloEmber.BerloNeve = reader["berloNeve"].ToString();
                    berloEmber.BerloCime = reader["berloCime"].ToString();

                    berloEmberList.Add(berloEmber);
                }
            }

            return berloEmberList;
        }

        public List<KolcsonzesCucc> GetKolcsonzesCuccList()
        {
            List<KolcsonzesCucc> kolcsonzesCuccList = new List<KolcsonzesCucc>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KolcsonzesCucc";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KolcsonzesCucc kolcsonzesCucc = new KolcsonzesCucc();
                    kolcsonzesCucc.KolcsonzesAzon = reader["kolcsonzesAzon"].ToString();
                    kolcsonzesCucc.BicajAzon = (int)reader["bicajAzon"];
                    kolcsonzesCucc.BerloAzon = (int)reader["berloAzon"];
                    kolcsonzesCucc.BerlesOraszama = (int)reader["berlesOraszama"];

                    kolcsonzesCuccList.Add(kolcsonzesCucc);
                }
            }

            return kolcsonzesCuccList;
        }
    }
}
