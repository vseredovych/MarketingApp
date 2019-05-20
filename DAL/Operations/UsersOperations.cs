﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DAL.Entities;
using DAL.Core;
using DAL.Interfaces;

namespace DAL.Operations
{
    class UsersOperations : IOperations<User>
    {
        string databaseTable = "Users";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public void Insert(User user)
        {
            string commandText = "Insert into " + databaseTable + " (Id, FirstName, LastName, Dob, CurrentSity)" +
                                 "values (@Id, @FirstName, @LastName, @Dob, @CurrentSity);";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
         
        }
        public void Update(User user)
        {
            string commandText = "Update " + databaseTable + " Set FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Dob = @Dob, "           +
                "CurrentSity = @CurrentSity " +
                "Where Id = @Id;";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(User user)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public void Delete(long id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt32));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public List<User> GetAll()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<User> users = new List<User>();

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Dob = Convert.ToDateTime(reader["Dob"]);
                    user.CurrentSity = Convert.ToString(reader["CurrentSity"]);
                    users.Add(user);
                }
                return users;
                //}
            }
        }
        public User GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from " + databaseTable + " where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText);
            try
            {
                var user = new User();
                while (dataReader.Read())
                {
                    user.Id = Convert.ToInt64(dataReader["Id"]);

                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataReader.Close();
            }
        }
        public long GetScalarValue(string commandText)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            object scalarValue = dbManager.GetScalarValue(commandText, parameters);
            return Convert.ToInt64(scalarValue);
        }
        public List<DbParameter> GetParametrs(User user)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", user.Id, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@FirstName", 50, user.FirstName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@LastName", 50, user.LastName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Dob", user.Dob, DbType.DateTime));
            parameters.Add(dbManager.CreateParameter("@CurrentSity", user.CurrentSity, DbType.String));
            return parameters;
        }
    }
}