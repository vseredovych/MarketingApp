using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DAL.Entities;
using DAL.Core;
using DAL.Interfaces;

namespace DAL.Operations
{
    class MerchantsOperations : IOperations<Merchant>
    {
        string databaseTable = "Merchants";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public void Insert(Merchant user)
        {
            string commandText = "Insert into " + databaseTable + " (Id, FirstName, LastName, Salary, CurrentCity)" +
                                 "values (@Id, @FirstName, @LastName, @Salary, @CurrentCity);";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
         
        }
        public void Update(Merchant user)
        {
            string commandText = "Update " + databaseTable + " Set FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Salary = @Salary, " +
                "CurrentCity = @CurrentCity " +
                "Where Id = @Id;";
            var parameters = GetParametrs(user);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(Merchant user)
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

        public List<Merchant> GetAll()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<Merchant> users = new List<Merchant>();

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Merchant user = new Merchant();
                    user.Id = Convert.ToInt64(reader["Id"]);
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Salary = Convert.ToInt64(reader["Salary"]);
                    user.CurrentCity = Convert.ToString(reader["CurrentCity"]);
                    users.Add(user);
                }
                return users;
                //}
            }
        }
        public List<Merchant> GetInRange(long start, long end)
        {
            string commandText = "Select * from " + databaseTable + " group by Salary having Salary > @Start and Salary < @End;";
            List<DbParameter> parameters = new List<DbParameter>();
            List<Merchant> users = new List<Merchant>();

            parameters.Add(dbManager.CreateParameter("@Start", start, DbType.UInt32));
            parameters.Add(dbManager.CreateParameter("@End", end, DbType.UInt32));


            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = dbManager.GetDataReader(commandText, parameters);

                while (reader.Read())
                {
                    Merchant user = new Merchant();
                    user.Id = Convert.ToInt64(reader["Id"]);
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Salary = Convert.ToInt64(reader["Salary"]);
                    user.CurrentCity = Convert.ToString(reader["CurrentCity"]);
                    users.Add(user);
                }
                return users;
                //}
            }
        }
        public List<Merchant> GetMoreThenAverage()
        {


            string commandText = "Select * from " + databaseTable + " group by Salary having Salary > (SELECT AVG(Salary) FROM Merchants);";
            List<DbParameter> parameters = new List<DbParameter>();
            List<Merchant> users = new List<Merchant>();

            //parameters.Add(dbManager.CreateParameter("@Start", start, DbType.UInt32));
            //parameters.Add(dbManager.CreateParameter("@End", end, DbType.UInt32));


            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = dbManager.GetDataReader(commandText, parameters);

                while (reader.Read())
                {
                    Merchant user = new Merchant();
                    user.Id = Convert.ToInt64(reader["Id"]);
                    user.FirstName = reader["FirstName"].ToString();
                    user.LastName = reader["LastName"].ToString();
                    user.Salary = Convert.ToInt64(reader["Salary"]);
                    user.CurrentCity = Convert.ToString(reader["CurrentCity"]);
                    users.Add(user);
                }
                return users;
                //}
            }
        }
        public Merchant GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from " + databaseTable + " where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText);
            try
            {
                var user = new Merchant();
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
        public List<DbParameter> GetParametrs(Merchant user)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", user.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@FirstName", 50, user.FirstName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@LastName", 50, user.LastName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Salary", user.Salary, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@CurrentCity", user.CurrentCity, DbType.String));
            return parameters;
        }
    }
}