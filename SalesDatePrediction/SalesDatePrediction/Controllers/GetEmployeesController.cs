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
    public class GetEmployeesController : ControllerBase
    {
        private readonly string cadenaSQL;
        public GetEmployeesController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpGet]
        [Route("Employees")]
        public IActionResult Lista()
        {
            List<Employees> lista = new List<Employees>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Get_employees", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Employees()
                            {
                                empid = Convert.ToInt32(rd["empid"]),
                                nombres = rd["nombres"].ToString(),
                               

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
