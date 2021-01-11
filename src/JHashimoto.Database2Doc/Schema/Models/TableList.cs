using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Models {
    public record TableList {
        public IEnumerable<Table> tableList { get; init; }

        public IEnumerable<Table> GetViews() {
            return tableList.Where(t => t.TableType == "VI");
        }

        public IEnumerable<Table> GetTables() {
            return tableList.Where(t => t.TableType == "BASE TABLE");
        }
    }
}
