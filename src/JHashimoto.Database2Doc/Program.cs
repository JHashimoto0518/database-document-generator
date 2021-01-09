using System;
using Dapper;
using Microsoft.Data.SqlClient;

namespace JHashimoto.Database2Doc {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            using (var con = new SqlConnection("Server=(local);Database=master;User Id=sa;Password=t6Eww7lL4teE;")) {
                con.Open();

                var rows = con.Query("select name from sys.databases").AsList();
                Console.WriteLine(rows[0].name);
            }
            
        }
    }
}
