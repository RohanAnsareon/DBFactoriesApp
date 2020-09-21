using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactoriesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Достаем все провайдеры доступные на данном компьютере

            //var factories = DbProviderFactories.GetFactoryClasses();

            //foreach (DataRow row in factories.Rows)
            //{

            //    foreach (DataColumn column in factories.Columns)
            //    {
            //        Console.WriteLine(row[column]);
            //    }
            //}

            //Console.ReadLine();

            // ==============================================================

            // Достаем ConnectionString из кофигурационного файла

            //var connectionStrings = ConfigurationManager.ConnectionStrings;

            //if (connectionStrings != null)
            //{
            //    foreach (ConnectionStringSettings connectionString in connectionStrings)
            //    {
            //        Console.WriteLine(connectionString.ProviderName + "\n\t" + connectionString.ConnectionString + '\n');
            //    }
            //}

            //Console.ReadLine();

            // ===============================================================
        }
    }
}
