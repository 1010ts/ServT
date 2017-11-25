using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tryCCC.Controllers
{
    public class CarInfoController : ApiController
    {
        // GET api/CarInfo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> Get(string date)
        {
            return new string[] { "bydate", "value2" };
        }

        public IEnumerable<string> Get(string coords, int w = 1)
        {
            return new string[] { "bycoordswithw", "value2" };
        }
    }
}
