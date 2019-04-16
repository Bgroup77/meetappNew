using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using meetapp.Models;

namespace meetapp.Controllers
{
    public class BusinessController : ApiController
    {
        [HttpGet]
        [Route("api/businesses")]
        public IEnumerable<Business> Get()
        {
            Business b = new Business();
            return b.ReadBusinesses();

        }
    }
}
