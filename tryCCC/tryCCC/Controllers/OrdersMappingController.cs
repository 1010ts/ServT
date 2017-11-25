using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tryCCC.Controllers
{
    public class OrdersMappingController : ApiController
    {
        // GET: api/OrdersMapping
        public IEnumerable<string> Get(string order_id)
        {
            var tco = new OrdersController();
            List<string> Rez = new List<string>();
            foreach (var id in order_id.Split(' '))
            {
                var Q = new JArray();
                foreach (var token in Q)
                {
                    Q.Remove("measurements");
                    Q.Remove("time");
                }

                Rez.Add(Q.ToString());
            }

            return Rez;
        }

    }
}
