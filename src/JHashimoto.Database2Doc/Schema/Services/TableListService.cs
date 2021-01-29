using Dapper;
using JHashimoto.Database2Doc.Schema.Models;
using JHashimoto.Database2Doc.Schema.Repositories;
using JHashimoto.Repositories.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Services {
    public class TableListService {

        public TableList GetTableList() {

            using (DatabaseRepositoryContext queryContext = new DatabaseRepositoryContext(DbProviderTypes.SqlServer, "Server=(local);Database=master;User Id=sa;Password=t6Eww7lL4teE;")) {
                var rep = new TableListRepository(queryContext);
                return rep.GetTableList();
            }

        }
    }
}
