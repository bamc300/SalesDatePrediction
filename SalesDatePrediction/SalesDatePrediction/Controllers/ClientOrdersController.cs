using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using Microsoft.AspNetCore.Cors;

namespace SalesDatePrediction.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientOrdersController : ControllerBase
    {
        private readonly string cadenaSQL;
        public ClientOrdersController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpGet]
        [Route("Obtener/{Custid:int}")]
        public IActionResult Obtener(int Custid)
        {

            List<ClientOrders> lista = new List<ClientOrders>();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Client_Orders", conexion);
                    cmd.Parameters.AddWithValue("custid", Custid);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {

                            lista.Add(new ClientOrders
                            {
                                orderid = Convert.ToInt32(rd["orderid"]),
                                requireddate = rd["requireddate"].ToString(),
                                shippeddate = rd["shippeddate"].ToString(),
                                shipname = rd["shipname"].ToString(),
                                shipaddress = rd["shipaddress"].ToString(),
                                shipcity = rd["shipcity"].ToString()

                            });
                        }

                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });

            }
        }
    }
}
