using Newtonsoft.Json.Linq;
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
            var reader = new SqlCommand($"SELECT [Client_id] FROM [ClientsTable] where [Name] = \'{name}\' AND [Phone] = \'{phone}\' ", WebApiConfig.BaseConnection).ExecuteReader();
            reader.Read();
            var res = $"{{ \'status\': \'{(reader.HasRows ? "ok" : "fail")}\', \'client_id\': \'{(reader.HasRows ? reader.GetGuid(0).ToString() : "")}\' }}";
            reader.Close();
            return res;
        }

        public string Get(string client_id)
        {
            var reader = new SqlCommand($"SELECT [Name], [Phone], [Email] FROM [ClientsTable] where [Client_id] = \'{client_id}\'", WebApiConfig.BaseConnection).ExecuteReader();
            reader.Read();
            var res = $"{{ \'status\': \'{(reader.HasRows ? "ok" : "fail")}\', \'name\': \'{(reader.HasRows ? reader.GetString(0) : "")}\', \'phone\': \'{(reader.HasRows ? reader.GetString(1) : "")}\', \'email\': \'{(reader.HasRows ? reader.GetString(2) : "")}\' }}";
            reader.Close();
            return res;
        }

        public string Post(string name, string phone, string email = "")
        {
            new SqlCommand($"Insert into [ClientsTable] ([Name], [Phone], [Email]) values ('{name}', '{phone}', '{email}')", WebApiConfig.BaseConnection).ExecuteNonQuery();
            return "{ \'status\':\'ok\' }";
        }
    }
}
