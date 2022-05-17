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
            string user = "root";
            string password = "1234";
            string database = "System_Users";
            string connectionString = "server=" + server + ";port=" + port + ";user id=" + user +
                ";password=" + password + ";database=" + database;
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
