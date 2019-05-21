using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using DAL.Core;
using MarketingApp.Database.Migration;
using System.Data;

namespace MarketingApp

{
    public class Authentication
    {

        public static long userAuthentication(string mail, string password)
        {
            DbHelper dbManager = new DbHelper();
            MigrationHelper migrationHelper = new MigrationHelper();


            migrationHelper.Update();

            string querryForPassword = "SELECT Password FROM Users WHERE Mail=@Mail";
            string querryForId = "SELECT Id FROM Users WHERE Mail=@Mail";

            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(dbManager.CreateParameter("@Mail", mail, DbType.String));


            if ((string)dbManager.GetScalarValue(querryForPassword, parameters) == password)
            {
                return (long)dbManager.GetScalarValue(querryForId, parameters);
            }
            return -1;
        }
    }
}
