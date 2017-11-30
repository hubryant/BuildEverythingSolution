using BuildEverything.Common.Helper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildEverything.Model
{
    /// <summary>
    /// 物理表
    /// </summary>
    public class DbTable
    {
        public string TableName { get; private set; }

        public List<TableColumn> Columns { get; set; }

        private readonly string _conn;

        public DbTable(string conn)
        {
            _conn = conn;
        }

        public DbTable(string tableName, List<TableColumn> columns)
        {
            TableName = tableName;
            Columns = columns;
        }

        public List<string> QueryTablesName()
        {
            var result = new SqlHelper(_conn).ExecuteDataTable(@"SELECT  name FROM    sysobjects WHERE  xtype IN ( 'u','v' ); ");

            return (from DataRow row in result.Rows select row[0].ToString()).ToList();
        }
    }
}
