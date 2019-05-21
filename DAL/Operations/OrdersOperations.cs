using System;
using System.Data;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Core;
using System.Data.Common;
using DAL.Interfaces;

namespace DAL.Operations
{
    public class OrdersOperations : IOperations<Order>
    {
        string databaseTable = "Orders";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public void Insert(Order order)
        {
            string commandText = "Insert into " + databaseTable + "(Id, UserId, Status, CreateAt)" +
                                 "values (@Id, @UserId, @Status, @CreateAt);";
            var parameters = GetParametrs(order);
            dbManager.CommandExecuteNonQuery(commandText, parameters);

        }
        public void Update(Order order)
        {
            string commandText = "Update" + databaseTable +
                "UserId = @UserId, " +
                "Status = @Status " +
                "CreateAt = @CreateAt" +
                "Where Id = @Id;";
            var parameters = GetParametrs(order);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(Order order)
        {
            string commandText = "Delete from" + databaseTable + "where Id = @Id";
            var parameters = GetParametrs(order);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public void Delete(long id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt64));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public List<Order> GetAll()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<Order> orders = new List<Order>();

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order();
                    order.Id = Convert.ToInt32(reader["Id"]);
                    order.UserId = Convert.ToInt32(reader["UserId"]);
                    order.Status = reader["Status"].ToString();
                    order.CreatedAt = Convert.ToDateTime(reader["UserID"]);
                    orders.Add(order);
                }
                return orders;
                //}
            }
        }

        public Order GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from " + databaseTable + " where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText);
            try
            {
                var order = new Order();
                while (dataReader.Read())
                {
                    order.Id = Convert.ToInt64(dataReader["Id"]);

                }
                return order;
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
        public List<DbParameter> GetParametrs(Order order)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", order.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@UserId", order.UserId, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Status", 50, order.Status, DbType.String));
            parameters.Add(dbManager.CreateParameter("@CreatedAt", order.CreatedAt, DbType.DateTime));

            return parameters;
        }
    }
}