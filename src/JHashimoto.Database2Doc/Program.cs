using System;
using Dapper;
using Microsoft.Data.SqlClient;

namespace JHashimoto.Database2Doc {
    class Program {
        static void Main(string[] args) {
//            const string TableListQuery = @"SELECT
//	DatabaseName = TABLE_CATALOG
//	,SchemaName = TABLE_SCHEMA
//	,TableName = TABLE_NAME
//	,TableType = TABLE_TYPE
//FROM
//	INFORMATION_SCHEMA.TABLES
//WHERE
//	(
//		TABLE_CATALOG = @DatabaseName OR(@DatabaseName IS NULL)
//	) AND(
//		TABLE_SCHEMA = @SchemaName OR(@SchemaName IS NULL)
//	)AND(
//		TABLE_TYPE = @TableType OR(@TableType IS NULL)
//	)";

				const string TableListQuery = @"SELECT
	DatabaseName = TABLE_CATALOG
	,SchemaName = TABLE_SCHEMA
	,TableName = TABLE_NAME
	,TableType = TABLE_TYPE
FROM
	INFORMATION_SCHEMA.TABLES
WHERE
     TABLE_CATALOG = @DatabaseName AND
     TABLE_SCHEMA = @SchemaName AND
     TABLE_TYPE = @TableType
 ";


            Console.WriteLine("Hello World!");
            using (var con = new SqlConnection("Server=(local);Database=master;User Id=sa;Password=t6Eww7lL4teE;")) {
                con.Open();

				var rows = con.Query(TableListQuery, new { DatabaseName = "master", SchemaName = "dbo", TableType = "BASE TABLE" }).AsList();

				Console.WriteLine(rows[0].TableName);
            }
        }
    }
}
