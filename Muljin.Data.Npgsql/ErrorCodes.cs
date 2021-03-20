using System;

namespace Muljin.Data.Postgres
{
    internal static class ErrorCodes
    {
        /// <summary>
        /// A user being searched for does not exist
        /// </summary>
        public const string UserNotFound = "user_not_found";

        /// <summary>
        /// A record searched for does not exist
        /// </summary>
        public const string RecordNotFound = "record_not_found";

        /// <summary>
        /// Conflict occured in db
        /// </summary>
        public const string Conflict = "conflict";
    }
}
