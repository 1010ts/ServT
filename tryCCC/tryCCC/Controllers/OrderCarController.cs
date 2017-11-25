using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tryCCC.Controllers
{
    public class OrderCarController : ApiController
    {


        //Car_params: 
        // { 'temperature': [      -20,      36    ], 'humidity': [      40,      60    ],     'preassure': [       1212,      1213    ] }

        public string Post(
            string Car_id,          
            string Department_time,
            string Department_place,
            string Department_coords,
            string Destination_place,
            string Destination_coords,
            string Requirements,  
            string Description = ""     
            )
        {
            new SqlCommand($"Insert into [OrderCarTable] ([Car_id], [Department_time], [Department_place], [Department_coords], [Destination_place], [Destination_coords], [Requirements], [Description]) values " +
                $"('{Car_id}', '{Department_time}', '{Department_place}', '{Department_coords}', '{Destination_place}', '{Destination_coords}', '{Requirements}', '{Description}')", WebApiConfig.BaseConnection).ExecuteNonQuery();
            return "{ \'status\':\'ok\' }";
        }

        public string Get(string order_id)
        {
            var reader = new SqlCommand($"SELECT [Car_id] " +
                $"[Department_time], [Department_place], [Department_coords], " +
                $"[Destination_place], [Destination_coords], [Requirements], " +
                $"[Description] FROM [OrderCarTable] where [Order_id] = \'{order_id}\'", WebApiConfig.BaseConnection).ExecuteReader();
            reader.Read();
            var res = $"{{ \'status\': \'{(reader.HasRows ? "ok" : "fail")}\', " +
                $"\'Car_id\': \'{(reader.HasRows ? reader.GetString(0) : "")}\', " +
                $"\'Department_time\': \'{(reader.HasRows ? reader.GetString(1) : "")}\', " +
                $"\'Department_place\': \'{(reader.HasRows ? reader.GetString(2) : "")}\', " +
                $"\'Department_coords\': \'{(reader.HasRows ? reader.GetString(3) : "")}\', " +
                $"\'Destination_place\': \'{(reader.HasRows ? reader.GetString(4) : "")}\', " +
                $"\'Destination_coords\': \'{(reader.HasRows ? reader.GetString(5) : "")}\', " +
                $"\'Requirements\': \'{(reader.HasRows ? reader.GetString(6) : "")}\', " +
                $"\'Description\': \'{(reader.HasRows ? reader.GetString(7) : "")}\' }}";
            reader.Close();
            return res;
        }

        public string Get(string car_id, int i = 0)
        {
            var reader = new SqlCommand($"SELECT [order_id], " +
                $"[Department_time], [Department_place], [Department_coords], " +
                $"[Destination_place], [Destination_coords], [Requirements], " +
                $"[Description] FROM [ClientsTable] where [Car_id] = \'{car_id}\'", WebApiConfig.BaseConnection).ExecuteReader();
            reader.Read();
            var res = $"{{ \'status\': \'{(reader.HasRows ? "ok" : "fail")}\', " +
                $"\'order_id\': \'{(reader.HasRows ? reader.GetString(0) : "")}\', " +
                $"\'Department_time\': \'{(reader.HasRows ? reader.GetString(1) : "")}\', " +
                $"\'Department_place\': \'{(reader.HasRows ? reader.GetString(2) : "")}\', " +
                $"\'Department_coords\': \'{(reader.HasRows ? reader.GetString(3) : "")}\', " +
                $"\'Destination_place\': \'{(reader.HasRows ? reader.GetString(4) : "")}\', " +
                $"\'Destination_coords\': \'{(reader.HasRows ? reader.GetString(5) : "")}\', " +
                $"\'Requirements\': \'{(reader.HasRows ? reader.GetString(6) : "")}\', " +
                $"\'Description\': \'{(reader.HasRows ? reader.GetString(7) : "")}\' }}";
            reader.Close();
            return res;
        }
    }
}
