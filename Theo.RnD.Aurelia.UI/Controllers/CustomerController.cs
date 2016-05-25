using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theo.RnD.Aurelia.UI.Models;

namespace Theo.RnD.Aurelia.UI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var c1 = new Customer { FirstName = "Theo", LastName = "Sundeep" };
            var c2 = new Customer { FirstName = "MTSK", LastName = "MTSK" };

            return new List<Customer> { c1, c2 };


        }
    }
}
