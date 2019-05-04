using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DAL.Entities;
using DAL.Helper;

namespace DAL.Operations
{
    class OUser
    {
        string databaseTable = "Users";
        SqlHelper dbManager = new SqlHelper();
        //CRUD
        public void Insert(EUser user)
        {
            string commandText = "Insert into " + databaseTable + " (Id, FirstName, LastName, Dob, IsActive)" +
                                 "values (@Id, @FirstName, @LastName, @Dob, @IsActive);";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
         
        }
        public void Update(EUser user)
        {
            string commandText = "Update " + databaseTable + " Set FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Dob = @Dob, "           +
                "IsActive = @IsActive "  +
                "Where Id = @Id;";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(EUser user)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public void Delete(int id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt32));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public List<EUser> Select()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<EUser> users = new List<EUser>();

            using (var connection = dbManager.createConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EUser user = new EUser();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Dob = Convert.ToDateTime(reader["Dob"]);
                    user.IsRoot = Convert.ToBoolean(reader["IsRoot"]);
                    users.Add(user);
                }
                return users;
                //}
            }
        }

        public List<DbParameter> GetParametrs(EUser user)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", user.Id, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@FirstName", 50, user.FirstName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@LastName", 50, user.LastName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Dob", user.Dob, DbType.DateTime));
            parameters.Add(dbManager.CreateParameter("@IsActive", user.IsRoot, DbType.Boolean));
            return parameters;
        }
    }
}