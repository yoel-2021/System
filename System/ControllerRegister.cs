using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class ControllerRegister
    { 
        public string ctrlRegister(Users user)
        {
            Model model = new Model();
            string response = "Suceed Register";

            if (string.IsNullOrEmpty(user.User)|| string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConPassword) || string.IsNullOrEmpty(user.Name))
            {
                response = "Please, Fill out all fields";
            }
            else
            {
                if (user.Password== user.ConPassword)
                {
                    if (model.existUser(user.User))
                    {
                        response = "User is exist yet";
                    }
                    else
                    {
                        user.Password = generateSHA1(user.Password);
                        model.register(user);
                    }
                }
                else
                {
                    response = "Passwords are not same";
                }
            }
            return response;
            
        }

        public string ctrlLogin(string user, string password)
        {
            Model model=new Model();
            string response = "";
            Users userData = null;
           
            if (string.IsNullOrEmpty(user)|| string.IsNullOrEmpty(password))
            {
                response = "Please fill out all fields";
            }
            else
            {
                userData = model.byUser(user);
            }
            if (userData==null)
            {
                response = "User not exist";
            }
            else
            {
                if (userData.Password!= generateSHA1(password))
                {
                    response = "Password or User are wrongs";
                }
            }return response;
        }

   
        private string generateSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider  sha = new SHA1CryptoServiceProvider();
            
            result = sha.ComputeHash(data);
            
            StringBuilder sb = new StringBuilder();
            for (int i =0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));

            }

            return sb.ToString();
        }

        



    }
}
