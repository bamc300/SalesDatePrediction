using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace SalesDatePrediction.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductsController : ControllerBase
    {
        private readonly string cadenaSQL;
        public GetProductsController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpGet]
        [Route("Products")]
        public IActionResult Lista()
        {
            List<Products> lista = new List<Products>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Get_Products", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Products()
                            {
                                productid = Convert.ToInt32(rd["productid"]),
                                productname = rd["productname"].ToString(),


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

