using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.Database2Doc.Schema.Models {
    
    public record Table() {
        [AllowNull]
        public string Database { get; init; }
        [AllowNull]
        public string Schema { get; init; }
        [AllowNull]
        public string TableName { get; init; }
        [AllowNull]
        public string TableType { get; init; }
    }
}
