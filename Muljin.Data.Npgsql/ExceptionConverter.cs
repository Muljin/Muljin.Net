using Muljin.Exceptions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Muljin.Data.Postgres
{
    internal static class ExceptionConverter
    {
        public static async Task CallAsync(Func<Task> action)
        {
            try
            {
                await action.Invoke();
            }
            catch (Npgsql.PostgresException e) // cathc PostresqlException
            {
                var exception = ConvertException(e);
                if (exception == null)
                {
                    throw;
                }
                else
                {
                    throw exception;
                }
            }
            catch
            {
                throw;
            }

        }

        public static async Task<T> CallAsync<T>(Func<Task<T>> action)
        {
            try
            {
                var res = await action.Invoke();
                return res;
            }
            catch (PostgresException e) // cathc PostresqlException
            {
                var exception = ConvertException(e);
                if (exception == null)
                {
                    throw;
                }
                else
                {
                    throw exception;
                }
            }
            catch
            {
                throw;
            }

        }

        private static Exception ConvertException(PostgresException e)
        {
            switch (e.Message)
            {
                case ErrorCodes.UserNotFound:
                    return new UserNotFoundException("Selected user not found");
                case ErrorCodes.RecordNotFound:
                    return new RecordNotFoundException("Record not found");
                case ErrorCodes.Conflict:
                    return new ConflictException("Conflict");
                default:
                    return null;
            }
        }
    }
}
