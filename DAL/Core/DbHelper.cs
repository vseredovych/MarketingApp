using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace DAL.Core
{
    public class DbHelper
    {
        private static string invariant = "MySql.Data.MySqlClient";
        public DbConnection CreateConnection()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(invariant);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MarketingApp"].ConnectionString;

            return connection;
        }
        public void CloseConnection(DbConnection connection)
        {
            connection.Close();
        }
        public DbDataAdapter CreateDataAdapter(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateDataAdapter();
        }
        public DbCommandBuilder CreateDbCommandBuilder(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateCommandBuilder();
        }
        public DbParameter CreateDbParameter(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateParameter();
        }
        public DbCommand CreateDbCommand(DbConnection connection)
        {
            return DbProviderFactories.GetFactory(connection).CreateCommand();
        }
        public DbCommand CreateDbCommand(DbConnection connection, string commandText)
        {
            var command = CreateDbCommand(connection);
            command.Connection = connection;
            command.CommandText = commandText;
            return command;
        }
        //
        public DbParameter CreateParameter(string name, object value, DbType dbType)
        {
            return CreateParameter(name, 0, value, dbType, ParameterDirection.Input);
        }

        public DbParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return CreateParameter(name, size, value, dbType, ParameterDirection.Input);
        }

        public DbParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            DbParameter parameter = CreateDbParameter(CreateConnection());
            parameter.DbType = dbType;
            parameter.ParameterName = name;
            parameter.Size = size;
            parameter.Direction = direction;
            parameter.Value = value;
            return parameter;
        }

        public DbDataReader GetDataReader(string commandText, List<DbParameter> parameters)
        {
            DbDataReader reader = null;

            var connection = this.CreateConnection();

            connection.Open();

            var command = this.CreateDbCommand(connection, commandText);


            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            reader = command.ExecuteReader();
            return reader;



        }
        public void CommandExecuteNonQuery(string commandText, List<DbParameter> parameters)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();

                using (var command = this.CreateDbCommand(connection, commandText))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
        }
        public void CommandExecuteNonQuery(string commandText)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();

                using (var command = this.CreateDbCommand(connection, commandText))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public object GetScalarValue(string commandText, List<DbParameter> parameters = null)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();

                using (var command = this.CreateDbCommand(connection, commandText))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }
        public IDataReader GetDataReader(string commandText)
        {
            IDataReader reader = null;
            //try
            //{
            var connection = this.CreateConnection();
                    connection.Open();

            var command = this.CreateDbCommand(connection, commandText);

            reader = command.ExecuteReader();
            return reader;
            //}
            //catch ()
            //{

            //}
        }
    }
}
