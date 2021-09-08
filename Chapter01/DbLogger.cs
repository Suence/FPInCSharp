using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter01.ConnectionHelper;

namespace Chapter01
{
    public class DbLogger
    {
        private string _connString;

        public void Log(LogMessage msg)
        {
            using (var conn = new SqlConnection(_connString))
            {
                int affectedRows = conn.Execute("sp_create_log", msg, null, null, CommandType.StoredProcedure);
            }
        }

        public IEnumerable<LogMessage> GetLogs(DateTime since)
        {
            var sqlGetLogs = "SELECT * FROM [Logs] WHERE [Timestamp] > @since";
            using (var conn = new SqlConnection(_connString))
            {
                return conn.Query<LogMessage>(sqlGetLogs, new { since = since });
            }
        }
    }

    public class DbLoggerUseHelper
    {
        private string _connString;

        public void Log(LogMessage msg)
            => Connect(_connString, c => c.Execute("sp_create_log", msg, null, null, CommandType.StoredProcedure));

        public IEnumerable<LogMessage> GetLogs(DateTime since)
            => Connect(_connString, c => c.Query<LogMessage>("SELECT * FROM [Logs] WHERE [Timestamp] > @since", new { since = since }));
    }

    public class LogMessage
    {
    }
}
