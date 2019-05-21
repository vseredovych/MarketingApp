using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Core;

namespace MarketingApp.Database.Migration
{
    public class MigrationHelper
    {
        string tableName = "DbVersions";
        const int LAST_VERSION = 3;

        public bool Update()
        {
            DbHelper dbHelper = new DbHelper();

            if (!CheckIfDatabaseExists())
            {
                CreateDb();
            }
            else
            {
                UpdateDb();
            }
            return true;
        }
        private bool CheckIfDatabaseExists() {
            bool exists = false;
            DbHelper dbHelper = new DbHelper();
            string commandText = "select case when exists((select * from information_schema.tables where table_name = '" + tableName + "')) then 1 else 0 end";
            using (DbConnection connection = dbHelper.CreateConnection())
            {
                try
                {
                    connection.Open();
                    // ANSI SQL way.  Works in PostgreSQL, MSSQL, MySQL.  
                    var cmd = dbHelper.CreateDbCommand(connection,
                      "select case when exists((select * from information_schema.tables where table_name = '" + tableName + "')) then 1 else 0 end");
                    int i = (int)cmd.ExecuteScalar();
                    if (i == 1)
                    {
                        exists = true;
                    }
                }
                catch
                {
                    try
                    {
                        // Other RDBMS.  Graceful degradation
                        exists = true;
                        var cmdOthers = dbHelper.CreateDbCommand(connection, "select 1 from " + tableName + " where 1 = 0");
                        cmdOthers.ExecuteNonQuery();
                    }
                    catch
                    {
                        exists = false;
                    }
                }
            }
            return exists;
        }
        private bool CreateDb()
        {
            DbHelper dbHelper = new DbHelper();
            using (DbConnection connection = dbHelper.CreateConnection())
            {
                connection.Open();
                dbHelper.CommandExecuteNonQuery("SET GLOBAL max_allowed_packet = 32 * 1024 * 1024");

                for (int i = 1; i <= LAST_VERSION; i++)
                {
                    string script = File.ReadAllText(@"C:\Users\vsere\Desktop\files\Code\Programms\Marketing\DAL\Migration\scripts\" + "db_v" + i + ".0.sql");
                    dbHelper.CommandExecuteNonQuery(script);
                }
            }
            return true;
        }
        private bool UpdateDb()
        {
            DbHelper dbHelper = new DbHelper();
            string lastVersionCommand = "SELECT MAX(Id) FROM " + tableName + ";";
            //string script = File.ReadAllText(@"C:\Merchants\vsere\Desktop\files\Code\Programms\Marketing\DAL\Migration\scripts\" + "db_v" + LAST_VERSION + ".0.sql");

            int lastVersion;
            using (DbConnection connection = dbHelper.CreateConnection())
            {
                connection.Open();
                DbCommand cmd = dbHelper.CreateDbCommand(connection, lastVersionCommand);
                lastVersion = (int)cmd.ExecuteScalar();
            }

            if (lastVersion < LAST_VERSION)
            {
                using (DbConnection connection = dbHelper.CreateConnection())
                {
                    for (int i = lastVersion + 1; i <= LAST_VERSION; i++)
                    {
                        string script = File.ReadAllText(@"C:\Users\vsere\Desktop\files\Code\Programms\Marketing\DAL\Migration\scripts\" + "db_v" + i + ".0.sql");
                        dbHelper.CommandExecuteNonQuery(script);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
