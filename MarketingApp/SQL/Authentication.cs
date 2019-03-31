using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using DAL.Helper;

namespace DAL.Authentication

{
    class Authentication
    {

        public static bool userAuthentication(string user, string password)
        {
            SqlHelper dbMabager = new SqlHelper();
            string querry = "SELECT * FROM Users";

            DbDataReader reader = dbMabager.GetDataReader(querry);
            return true;
            
            while (reader.Read())
            {
                if (user == reader["User"].ToString())
                {
                    if (password == reader["Password"].ToString())
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
