using Dapper;
using JHashimoto.Database2Doc.Schema.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Services {
    public class TableListService {

        public List<Table> GetTableList() {

            const string TableListQuery = @"SELECT
	[Database] = TABLE_CATALOG
	,[Schema] = TABLE_SCHEMA
	,TableName = TABLE_NAME
	,TableType = TABLE_TYPE
FROM
	INFORMATION_SCHEMA.TABLES
WHERE
     TABLE_CATALOG = @DatabaseName AND
     TABLE_SCHEMA = @SchemaName AND
     TABLE_TYPE = @TableType
 ";

            using (var con = new SqlConnection("Server=(local);Database=master;User Id=sa;Password=t6Eww7lL4teE;")) {
                con.Open();

                var rows = con.Query<Table>(TableListQuery, new { DatabaseName = "master", SchemaName = "dbo", TableType = "BASE TABLE" }).AsList();
                return rows;
            }
        }
    }
}
