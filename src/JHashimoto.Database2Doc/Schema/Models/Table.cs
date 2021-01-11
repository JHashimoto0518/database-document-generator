using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Models {
    
    // TODO:エラーメッセージ日本語化
    public class Table {
        public string Database { get; set; }
        public string Schema { get; set; }
        public string TableName { get; set; }
        public string TableType { get; set; }
    }
}
