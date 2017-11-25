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
                JObject json = new JObject();
                json.Add("order_id", id);
                JArray coords = new JArray();
                var Q = new JArray(tco.Get(order_id));
                foreach (var token in Q)
                {
                    string loca = (string)token["coords"];
                    coords.Add(loca);
                }
                json.Add("coords", coords);
                Rez.Add(json.ToString());
            }

            return Rez;
        }

    }
}
