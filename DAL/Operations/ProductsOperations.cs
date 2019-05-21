using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DAL.Entities;
using DAL.Core;
using DAL.Interfaces;

namespace DAL.Operations
{
    class ProductsOperations : IOperations<Product>
    {
        string databaseTable = "Products";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public void Insert(Product products)
        {
            string commandText = "Insert into " + databaseTable + "(Id, MerchantId, Name, Price, Status, CreatedAt)" +
                                 "values (@Id, @MerchantId, @Name, @Price, @Status, @CreatedAt);";
            var parameters = GetParametrs(products);
            dbManager.CommandExecuteNonQuery(commandText, parameters);

        }
        public void Update(Product products)
        {
            string commandText = "Update" + databaseTable + "Set MerchantId = @MerchantId, " +
                "Name = @Name, " +
                "Price = @Price, " +
                "Status = @Status " +
                "CreatedAt = @CreatedAt" +
                "Where Id = @Id;";
            var parameters = GetParametrs(products);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(Product products)
        {
            string commandText = "Delete from" + databaseTable + "where Id = @Id";
            var parameters = GetParametrs(products);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public void Delete(long id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt32));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public List<Product> GetAll()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<Product> products = new List<Product>();

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                DbDataReader reader;
                var command = dbManager.CreateDbCommand(connection, commandText);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
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

        public List<Product> GetInRange(int limit, int offset)
        {

            string commandText = "Select * from " + databaseTable + " LIMIT @Limit OFFSET @Offset;";
            List<Product> products = new List<Product>();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Limit", limit, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Offset", offset, DbType.Int64));

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                DbDataReader reader;
                //var command = dbManager.CreateDbCommand(connection, commandText);
                reader = dbManager.GetDataReader(commandText, parameters);
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt64(reader["Id"]);
                    product.Name = reader["Name"].ToString();
                    product.Price = Convert.ToInt32(reader["Price"]);
                    product.Status = reader["Status"].ToString();
                    product.MerchantId = Convert.ToInt64(reader["MerchantId"]);
                    products.Add(product);
                }
                return products;
            }
        }

        public Product GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from " + databaseTable + " where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText);
            try
            {
                var product = new Product();
                while (dataReader.Read())
                {
                    product.Id = Convert.ToInt64(dataReader["Id"]);

                }
                return product;
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

        public List<DbParameter> GetParametrs(Product product)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", product.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@MerchantId", product.MerchantId, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Name", 50, product.Name, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Price", product.Price, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Status", 50, product.Status, DbType.String));
            parameters.Add(dbManager.CreateParameter("@CreatedAt", product.CreatedAt, DbType.DateTime));

            return parameters;
        }
    }
}
