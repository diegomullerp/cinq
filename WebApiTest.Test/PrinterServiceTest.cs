using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiTest;
using WebApiTest.Models;
using WebApiTest.Services;


namespace WebApiTest.Test
{
    [TestClass]
    public class PrinterServiceTest
    {
        [TestMethod]
        public void GetAllIsNotNull()
        {
            List<PrinterInfo> printers = PrinterService.GetAll();
            Assert.IsNotNull(printers);
        }
    }
}
