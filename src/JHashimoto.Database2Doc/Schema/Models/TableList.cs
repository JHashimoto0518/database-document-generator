using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Models {
    public record TableList(IEnumerable<Table> Items) {
        //public IEnumerable<Table> Items { get; init; }

        public IEnumerable<Table> GetViews() {
            return Items.Where(t => t.TableType == "VIEW");
        }

        public IEnumerable<Table> GetTables() {
            return Items.Where(t => t.TableType == "BASE TABLE");
        }
    }
}
