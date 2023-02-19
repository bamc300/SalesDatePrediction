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
    public class AddNewOrderController : ControllerBase
    {
        private readonly string cadenaSQL;
        public AddNewOrderController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] AddNewOrder objeto)
        {
            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("AddNewOrder", conexion);
                    cmd.Parameters.AddWithValue("empid", objeto.empid);
                    cmd.Parameters.AddWithValue("shipperid", objeto.shipperid);
                    cmd.Parameters.AddWithValue("shipname", objeto.shipname);
                    cmd.Parameters.AddWithValue("shipaddress", objeto.shipaddress);
                    cmd.Parameters.AddWithValue("shipcity", objeto.shipcity);
                    cmd.Parameters.AddWithValue("orderdate", objeto.orderdate);
                    cmd.Parameters.AddWithValue("requireddate", objeto.requireddate);
                    cmd.Parameters.AddWithValue("shippeddate", objeto.shippeddate);
                    cmd.Parameters.AddWithValue("freight", objeto.freight);
                    cmd.Parameters.AddWithValue("shipcountry", objeto.shipcountry);
                    cmd.Parameters.AddWithValue("productid", objeto.productid);
                    cmd.Parameters.AddWithValue("unitprice", objeto.unitprice);
                    cmd.Parameters.AddWithValue("qty", objeto.qty);
                    cmd.Parameters.AddWithValue("discount", objeto.discount);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "agregado" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }
    }
}
