using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class Connection
    {
        public static MySqlConnection getConnection()
        {
            string server = "localhost";
            string port = "3306";
            string user = "user1";
            string password = "123456";
            string database = "system_users";
            string connectionString = "server=" + server + ";port=" + port + ";user id=" + user +
                ";password=" + password + ";database=" + database;
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }

    class ConnectionProducts
    {
        public static MySqlConnection getConnectionProducts()
        {
            string server = "localhost";
            string port = "3306";
            string user = "user1";
            string password = "123456";
            string database = "store_database";
            string connectionString = "server=" + server + ";port=" + port + ";user id=" + user +
                ";password=" + password + ";database=" + database;

            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

    }
}
