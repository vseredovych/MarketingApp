using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using DAL.Core;
using MarketingApp.Database.Migration;

namespace MarketingApp

{
    public class Authentication
    {

        public static bool userAuthentication(string user, string password)
        {
            DbHelper dbMabager = new DbHelper();
            MigrationHelper migrationHelper = new MigrationHelper();


            migrationHelper.Update();

            string querry = "SELECT * FROM Merchants";
            DbDataReader reader = (DbDataReader)dbMabager.GetDataReader(querry);

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
