using System;
using System.Data;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Helper;
using System.Data.Common;


namespace DAL.Operations
{
    class OOrder
    {
        string databaseTable = "Orders";
        SqlHelper dbManager = new SqlHelper();
        //CRUD
        public void Insert(EOrder order)
        {
            string commandText = "Insert into" + databaseTable + "(Id, UserId, Status, CreateAt)" +
                                 "values (@Id, @UserId, @Status, @CreateAt);";
            var parameters = GetParametrs(order);
            dbManager.CommandExecuteNonQuery(commandText, parameters);

        }
        public void Update(EOrder order)
        {
            string commandText = "Update" + databaseTable +
                "UserId = @UserId, " +
                "Status = @Status " +
                "CreateAt = @CreateAt" +
                "Where Id = @Id;";
            var parameters = GetParametrs(order);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(EOrder order)
        {
            string commandText = "Delete from" + databaseTable + "where Id = @Id";
            var parameters = GetParametrs(order);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public void Delete(int id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt32));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public List<EOrder> Select()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<EOrder> orders = new List<EOrder>();

            using (var connection = dbManager.createConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EOrder order = new EOrder();
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

        public List<DbParameter> GetParametrs(EOrder order)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", order.Id, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@UserId", order.UserId, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Status", 50, order.Status, DbType.String));
            parameters.Add(dbManager.CreateParameter("@CreatedAt", order.CreatedAt, DbType.DateTime));

            return parameters;
        }
    }
}