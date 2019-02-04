using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            SaveAllData();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void SaveAllData()
        {
            try
            {
                List<Printer> printers = new Printer().GetPrinters();
                foreach (Printer printer in printers)
                {
                    printer.ExpireDate = DateTime.Now;
                    printer.Save();
                }

                Console.WriteLine("SUCESS! All printers are saved in the database!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! " + ex.Message);
            }
        }
    }
}
