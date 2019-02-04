using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTest;
using WebApiTest.Models;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    public class PrintersController : ApiController
    {
        // GET api/printers
        public IEnumerable<PrinterInfo> Get()
        {
            return PrinterService.GetAll();
        }
    }
}
