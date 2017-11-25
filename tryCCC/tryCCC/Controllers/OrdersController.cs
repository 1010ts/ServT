using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tryCCC.Controllers
{
    public class OrdersController : ApiController
    {
        public string Post(string jsoned)
        {
            JArray json = JArray.Parse(jsoned.ToLower());
            foreach (JObject token in json)
            {
             new SqlCommand($"Insert into [OrdersTable] ([Order_id], [Coords], [Time], [Measurements]) values " +
                    $"('{(string)token["order_id"]}', '{(string)token["coords"]}', '{(string)token["time"]}', '{(string)token["measurements"]}')", WebApiConfig.BaseConnection).ExecuteNonQuery();

            }
            return "{ \'status\':\'ok\' }";
        }

        public string Get(string order_id)
        {
            var reader = new SqlCommand($"SELECT [Coords], [Time], [Measurements] FROM [OrdersTable] where [Order_id] = \'{order_id}\'", WebApiConfig.BaseConnection).ExecuteReader();
            reader.Read();
            var res = $"{{ \'status\': \'{(reader.HasRows ? "ok" : "fail")}\', " +
                $"\'Coords\': \'{(reader.HasRows ? reader.GetString(0) : "")}\', " +
                $"\'Time\': \'{(reader.HasRows ? reader.GetString(1) : "")}\', " +
                $"\'Measurements\': \'{(reader.HasRows ? reader.GetString(2) : "")}\' }}";
            reader.Close();
            return res;
        }

    }
}
