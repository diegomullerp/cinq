using System.Collections.Generic;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public static class PrinterService
    {
        public static List<PrinterInfo> GetAll()
        {
            List<PrinterInfo> printers = new List<PrinterInfo>();
            printers.Add(new PrinterInfo("HP 330C", "65487987321", new Customer(1, "Leandro")));
            printers.Add(new PrinterInfo("Xerox C-100", "12354687", new Customer(1, "Tiago")));
            printers.Add(new PrinterInfo("Canon C-70", "3223444423", new Customer(1, "Diego")));
            printers.Add(new PrinterInfo("Epson D-120", "2346777442", new Customer(1, "Ana Paula")));
            printers.Add(new PrinterInfo("HP XT-100", "12246221574", new Customer(1, "Melissa")));

            return printers;
        }
    }
}