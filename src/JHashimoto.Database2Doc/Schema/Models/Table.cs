using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Models {
    
    // TODO:エラーメッセージ日本語化
    public record Table {
        public string Database { get; init; }
        public string Schema { get; init; }
        public string TableName { get; init; }
        public string TableType { get; init; }
    }
}
