using System;
using Dapper;
using JHashimoto.Database2Doc.Schema.Models;
using JHashimoto.Database2Doc.Schema.Services;
using Microsoft.Data.SqlClient;

namespace JHashimoto.Database2Doc {
    class Program {
        static void Main(string[] args) {
            var s = new TableListService();
            var tableList = s.GetTableList();
            Console.WriteLine(tableList.Count);
        }
    }
}
