using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoFotoMVC.Models
{
    public class HelperLogin
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
        public HelperLogin()
        {
            String cadena = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
            this.con = new SqlConnection(cadena);
            this.com = new SqlCommand();
            this.com.Connection = this.con;
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
        }
        public bool GetLogin(String nick, String pwd)
        {
            if(nick.Trim() == "" || pwd.Trim() == "")
            {
                return false;
            } else
            {
               String cadena =  CreateMD5Hash(pwd);
               this.com.CommandText = "GETLOGIN";
               SqlParameter pamNick = new SqlParameter("@NICK", nick);
               SqlParameter pamPwd = new SqlParameter("@PWD", cadena);
               this.com.Parameters.Add(pamNick);
               this.com.Parameters.Add(pamPwd);
               this.con.Open();
               this.reader = this.com.ExecuteReader();
                this.reader.Read();
               if (int.Parse(this.reader["EXISTE"].ToString()) == 1)
               {
                    return true;
               }
            }
            return false;
        }

        public string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}