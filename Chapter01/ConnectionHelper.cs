using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter01
{
    public static class ConnectionHelper
    {
        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> f)
            where TDisp : IDisposable
        {
            using (disposable) return f(disposable);
        }

        public static R Connect<R>(string connString, Func<IDbConnection, R> f)
            => Using(new SqlConnection(connString), c => { c.Open(); return f(c); });
    }
}
