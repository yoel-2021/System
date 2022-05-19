using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class ProductsController: ConnectionProducts
    {
        public List<Object> ask(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<Object>();
            string sql;

            if (data == null)
            {
                sql = "SELECT id, code, name, description, public_price, stock  FROM products ORDER BY name ASC";
            }
            else
            {
                sql = "SELECT id, code, name, description, public_price, stock FROM products WHERE code LIKE '%" + data + "%' OR name LIKE '%" + data + "%' OR description LIKE '%" + data + "%' OR public_price LIKE '%" + data + "%' OR stock LIKE '%" + data + "%'ORDER BY name ASC";
            }
            try {

                MySqlConnection connectionBd = ConnectionProducts.getConnectionProducts();

                connectionBd.Open();

                MySqlCommand command = new MySqlCommand(sql, connectionBd);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Products _products = new Products();
                    _products.Id = int.Parse(reader.GetString(0));
                    _products.Code = reader[1].ToString();
                    _products.Name = reader.GetString("name");
                    _products.Description = reader[3].ToString();
                    _products.Public_price = double.Parse(reader[4].ToString());
                    _products.Stock = int.Parse(reader.GetString(5));

                    list.Add(_products);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return list;
         } 
    } 
}
