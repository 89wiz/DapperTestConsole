using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTestConsole
{
    class Program
    {
        static string cnString = @"Data Source=iris.arvixe.com;Initial Catalog=LogicalMinds_Quiz;Persist Security Info=True;User ID=LogicalMinds;Password=logicaldb@2014";

        static void Main(string[] args)
        {
            using (var cn = new SqlConnection(cnString))
            {
                var list = cn.Query("select * from Quiz where Nome like '%' + @busca + '%'", new { busca = "t" });

                Console.WriteLine("Id\tNome\tAtivo");
                Console.WriteLine(string.Empty.PadLeft(30, '='));

                foreach (var q in list)
                {
                    Console.WriteLine($"{q.QuizID}\t{q.Nome}\t{q.Ativo}");
                }
            }
            Console.ReadKey();
        }
    }
}
