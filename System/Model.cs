using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class Model
    {
        public int register(Users user)
        {
            MySqlConnection connection = Connection.getConnection();
            connection.Open();

            string sql = "INSERT INTO users(user,password, name, id_type)VALUES(@user, @password,@name, @id_type)";
            MySqlCommand command = new MySqlCommand (sql, connection);
            command.Parameters.AddWithValue("@user",user.User);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@name", user.Name);
            command.Parameters.AddWithValue("@id_type", 1);

            int result = command.ExecuteNonQuery();
            return result;
        }
        public bool existUser(string user)
        {
            MySqlDataReader reader;
            MySqlConnection connection = Connection.getConnection();
            connection.Open();

            string sql = "SELECT id from users WHERE user LIKE @user";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@user", user);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public Users byUser(string user)
        {
            MySqlDataReader reader;
            MySqlConnection connection = Connection.getConnection();
            connection.Open();

            string sql = "SELECT id, password, name, id_type from users WHERE user LIKE @user";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@user", user);

            reader = command.ExecuteReader();

            Users usr = null;

            while (reader.Read())
            {
                usr = new Users();
                usr.Id = int.Parse(reader["id"].ToString());
                usr.Password = reader["password"].ToString();
                usr.Name = reader["name"].ToString();
                usr.Id_type = int.Parse(reader["id_type"].ToString());
            }
           return usr;
        }
    }

}
