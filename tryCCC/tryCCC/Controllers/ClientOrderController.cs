using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tryCCC.Controllers
{
    public class ClientOrderController : ApiController
    {
        public string Get(string client_id)
        {
            var reader = new SqlCommand($"SELECT [order_id] FROM [ClientOrderTable] where [Order_id] = \'{client_id}\'", WebApiConfig.BaseConnection).ExecuteReader();
            reader.Read();
            var res = $"{{ \'status\': \'{(reader.HasRows ? "ok" : "fail")}\', \'order_id\': [";
            do
            {
                res += $"'{(reader.HasRows ? reader.GetString(0) : "")}, ";
            } while (reader.Read());
            res = res.Remove(res.Length - 2);
            res += "] }";
            reader.Close();
            return res;
        }

        public string Post(string order_id, string client_id)
        {
            new SqlCommand($"Insert into [ClientOrderTable] ([order_id], [client_id]) values ('{order_id}', '{client_id}')", WebApiConfig.BaseConnection).ExecuteNonQuery();
            return "{ \'status\':\'ok\' }";
        }
    }
}
