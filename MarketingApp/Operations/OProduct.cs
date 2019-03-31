using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DAL.Entities;
using DAL.Helper;

namespace DAL.Operations
{
    class OProducts
    {
        string databaseTable = "Products";
        SqlHelper dbManager = new SqlHelper();
        //CRUD
        public void Insert(EProduct products)
        {
            string commandText = "Insert into" + databaseTable + "(Id, MerchantId, Name, Price, Status, CreateAt)" +
                                 "values (@Id, @MerchantId, @Name, @Price, @Status, @CreatedAt);";
            var parameters = GetParametrs(products);
            dbManager.CommandExecuteNonQuery(commandText, parameters);

        }
        public void Update(EProduct products)
        {
            string commandText = "Update" + databaseTable + "Set MerchantId = @MerchantId, " +
                "Name = @Name, " +
                "Price = @Price, " +
                "Status = @Status " +
                "CreateAt = @CreateAt" +
                "Where Id = @Id;";
            var parameters = GetParametrs(products);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(EProduct products)
        {
            string commandText = "Delete from" + databaseTable + "where Id = @Id";
            var parameters = GetParametrs(products);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public void Delete(int id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt32));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public List<EProduct> Select()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<EProduct> products = new List<EProduct>();

            using (var connection = dbManager.createConnection())
            {
                connection.Open();
                //using (var command = dbManager.CreateDbCommand(connection, commandText))
                //{
                //foreach (var parameter in GetParametrs(user))
                //{
                //    command.Parameters.Add(parameter);
                //}
                DbDataReader reader;
                var command = dbManager.CreateDbCommand(connection, commandText);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EProduct product = new EProduct();
                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.Name = reader["Name"].ToString();
                    product.Price = Convert.ToInt32(reader["Price"]);
                    product.Status = reader["Status"].ToString();
                    product.MerchantId = Convert.ToInt32(reader["MerchantId"]);
                    products.Add(product);
                }
                return products;
                //}
            }

        }

        public List<DbParameter> GetParametrs(EProduct product)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", product.Id, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@MerchantId", product.MerchantId, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Name", 50, product.Name, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Price", product.Price, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Status", 50, product.Status, DbType.String));
            parameters.Add(dbManager.CreateParameter("@CreatedAt", product.CreatedAt, DbType.DateTime));

            return parameters;
        }
    }
}
