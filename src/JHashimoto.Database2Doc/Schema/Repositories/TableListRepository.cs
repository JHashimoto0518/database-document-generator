using JHashimoto.Database2Doc.Schema.Models;
using JHashimoto.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Repositories {
    public class TableListRepository : DatabaseRepositoryBase {
        public TableListRepository(DatabaseRepositoryContext context) : base(context) {
        }

        public TableList GetTableList() {
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

            var e = Context.QuerySql<Table>(TableListQuery, new { DatabaseName = "master", SchemaName = "dbo", TableType = "BASE TABLE" });
            var tableList = new TableList(Items: e);
            return tableList;
        }
    }
}
