using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Models;
using System.Data;
using System.Data.SqlClient;

namespace SalesDatePrediction.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class DatePredictionController : ControllerBase
    {
        private readonly string cadenaSQL;
        public DatePredictionController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista() { 
            List<DatePrediction> lista = new List<DatePrediction>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Date_Prediction", conexion);
                    cmd.CommandType= CommandType.StoredProcedure;
                    using (var rd= cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new DatePrediction()
                            {
                                custid = Convert.ToInt32(rd["custid"]),
                                contactname = rd["contactname"].ToString(),
                                LastOrderDate = rd["LastOrderDate"].ToString(),
                                NextPredictedOrder = rd["NextPredictedOrder"].ToString()

                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { response = lista });
            }
            catch(Exception error) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }


        }

    }
}
