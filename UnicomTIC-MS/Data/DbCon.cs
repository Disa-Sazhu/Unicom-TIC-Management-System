using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_MS.Data
{
    public static class DbCon
    {
        private static string connStr = "Data Source=SchoolDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}
