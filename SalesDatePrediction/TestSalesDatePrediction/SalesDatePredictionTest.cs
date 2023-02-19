using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Controllers;
using SalesDatePrediction.Models;

namespace TestSalesDatePrediction
{
    public class SalesDatePredictionTest
    {
        private readonly GetShippersController _controllerS;
        private readonly GetEmployeesController _controllerE;
        private readonly DatePredictionController _controllerD;
        private readonly ClientOrdersController _controllerC;
        private readonly GetProductsController _controllerP;
        private IConfiguration _config;
        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }
        public SalesDatePredictionTest()
        {
            _controllerS = new GetShippersController(Configuration);
            _controllerE = new GetEmployeesController(Configuration);
            _controllerD = new DatePredictionController(Configuration);
            _controllerC = new ClientOrdersController(Configuration);
            _controllerP = new GetProductsController(Configuration);
        }
        [Fact]
        public async Task GetShippers_OK()
        {
            var response = _controllerS.Lista();
            var result = Assert.IsType<ObjectResult>(response);
            var resultado = result;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetEmployees_OK()
        {
            var response = _controllerE.Lista();
            var result = Assert.IsType<ObjectResult>(response);
            var resultado = result;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetDatePrediction_OK()
        {
            var response = _controllerS.Lista();
            var result = Assert.IsType<ObjectResult>(response);
            var resultado = result;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetClientOrders_OK()
        {
            var response = _controllerD.Lista();
            var result = Assert.IsType<ObjectResult>(response);
            var resultado = result;
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public async Task GetProduct_OK()
        {
            var response = _controllerP.Lista();
            var result = Assert.IsType<ObjectResult>(response);
            var resultado = result;
            Assert.Equal(200, result.StatusCode);
        }
    }
}