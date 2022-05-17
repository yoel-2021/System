using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class Users
    {
        int id, id_type;
        string user,password, conPassword, name;

        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string ConPassword { get => conPassword; set => conPassword = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int Id_type { get => id_type; set => id_type = value; }
    }
}
