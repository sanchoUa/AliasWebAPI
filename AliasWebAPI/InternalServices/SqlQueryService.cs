using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.Common;
using System.Threading;

namespace AliasWebAPI.InternalServices
{
    public sealed class SqlQueryService
    {
        private const int _commandTimeout = 3600;
        private readonly string _connectionString;

        public SqlQueryService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object parameters, CommandType? commandType = null, int commandTimeout = _commandTimeout, CancellationToken cancellationToken = default(CancellationToken))
        {
            SqlMapper.SetTypeMap(typeof(TEntity), null);
            return await ExeQueryAsync((connection) => connection.QueryAsync<TEntity>(new CommandDefinition(sql, parameters, null, commandTimeout, commandType: commandType, cancellationToken: cancellationToken)));
        }

        public async Task<object> ExecuteScalarAsync(string sql, object parameters, CommandType? commandType = null, int commandTimeout = _commandTimeout, CancellationToken cancellationToken = default(CancellationToken))
        {
               return await ExeQueryAsync((connection) => connection.ExecuteScalarAsync(new CommandDefinition(sql, parameters, null, commandTimeout, commandType: commandType, cancellationToken: cancellationToken)));
        }

        public async Task<TEntity> ExecuteScalarAsync<TEntity>(string sql, object parameters, CommandType? commandType = null, int commandTimeout = _commandTimeout, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExeQueryAsync((connection) => connection.ExecuteScalarAsync<TEntity>(new CommandDefinition(sql, parameters, null, commandTimeout, commandType: commandType, cancellationToken: cancellationToken)));
        }

        private async Task<TEntity> ExeQueryAsync<TEntity>(Func<SqlConnection, Task<TEntity>> execute, DbTransaction transaction = null, bool keepConnectionOpen = false)
        {
            SqlConnection connection = null;
            try
            {
                if (transaction != null)
                {
                    connection = (SqlConnection)transaction.Connection;
                }
                connection = new SqlConnection(_connectionString);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var result = await execute(connection);

                return result;
            }
            catch
            {
                if (connection != null)
                {
                    if (connection.State != ConnectionState.Closed && transaction == null)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
                throw;
            }
            finally
            {
                if (connection != null && transaction == null && !keepConnectionOpen) {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }
        }
    }
}
