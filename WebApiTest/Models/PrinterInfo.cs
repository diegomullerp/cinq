using System.Collections.Generic;

namespace WebApiTest.Models
{
    public class PrinterInfo
    {
        public string Name { get; set; }
        public string SerialKey { get; set; }
        public Customer Customer { get; set; }

        public PrinterInfo() { }

        public PrinterInfo(string name, string serialKey, Customer customer)
        {
            this.Name = name;
            this.SerialKey = serialKey;
            this.Customer = customer;
        }
    }
}