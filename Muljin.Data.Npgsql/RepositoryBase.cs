using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Muljin.Data.Postgres
{
    public class RepositoryBase<T>
    {
        private readonly string _connectionString;

        public RepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteAsync(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            await ExceptionConverter.CallAsync(async () =>
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    await conn.ExecuteAsync(sql, commandType: commandType);
                }
            });
        }

        public async Task ExecuteAsync(string sql, object parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            await ExceptionConverter.CallAsync(async () =>
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    var res = await conn.ExecuteAsync(sql, parameters, commandType: commandType);
                    return res;
                }
            });
        }

        public async Task<T2> GetAsync<T2>(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            var res = await ExceptionConverter.CallAsync(async () =>
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    var res = await conn.QuerySingleAsync<T2>(sql, commandType: commandType);
                    return res;
                }
            });

            return res;
        }

        public async Task<T2> GetAsync<T2>(string sql, object parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            var res = await ExceptionConverter.CallAsync(async () =>
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    var res = await conn.QuerySingleAsync<T2>(sql, parameters, commandType: commandType);
                    return res;
                }
            });

            return res;
        }

        /// <summary>
        /// Get a single item from the database of type T
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            return await GetAsync<T>(sql, commandType);
        }


        public async Task<T> GetAsync(string sql, object parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return await GetAsync<T>(sql, parameters, commandType);
        }

        /// <summary>
        /// Get a list of items of type T from the database
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            return await GetListAsync<T>(sql, commandType);
        }

        /// <summary>
        /// Get a list of items of type T from the database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync(string sql, object parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            return await GetListAsync<T>(sql, parameters, commandType);
        }

        public async Task<IEnumerable<T2>> GetListAsync<T2>(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            var res = await ExceptionConverter.CallAsync(async () =>
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    var res = await conn.QueryAsync<T2>(sql, commandType: commandType);
                    return res;
                }
            });

            return res;
        }

        public async Task<IEnumerable<T2>> GetListAsync<T2>(string sql, object parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            var res = await ExceptionConverter.CallAsync(async () =>
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    var res = await conn.QueryAsync<T2>(sql, parameters, commandType: commandType);
                    return res;
                }
            });

            return res;
        }
    }
}
