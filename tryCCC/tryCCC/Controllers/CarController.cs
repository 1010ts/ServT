using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tryCCC.Controllers
{
    public class CarController : ApiController
    {
        public string Get(string car_id)
        {
            var reader = new SqlCommand($"SELECT [Phone], " +
                        $"[Capabilities] FROM [CarTable] where [Car_id] = \'{car_id}\'", WebApiConfig.BaseConnection).ExecuteReader();
            reader.Read();
            var res = $"{{ \'status\': \'{(reader.HasRows ? "ok" : "fail")}\', " +
                $"\'phone\': \'{(reader.HasRows ? reader.GetString(0) : "")}\', " +
                $"\'capabilities\': \'{(reader.HasRows ? reader.GetString(1) : "")}\' }}";
            reader.Close();
            return res;
        }
    }
}