using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace tryCCC.Controllers
{
    public class ClientController : ApiController
    {
        // GET api/Client
        public string Get(string name, string phone)
        { 
            var qw = new SqlCommand($"SELECT [Client_id] FROM [ClientsTable] where [Name] = \'{name}\' AND [Phone] = \'{phone}\' ", WebApiConfig.BaseConnection);
            var ed = qw.ExecuteReader();
            return ed.GetValue(0) as string ?? "NOTHING";
        }

        public string Post(string name, string phone, string email = "")
        {
            new SqlCommand($"Insert into [ClientsTable] ([Name], [Phone], [Email]) values ('{name}', '{phone}', '{email}')", WebApiConfig.BaseConnection).ExecuteNonQuery();
            return "{ \"status\":\"ok\" }";
        }
    }
}
