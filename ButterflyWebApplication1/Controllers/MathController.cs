using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ButterflyWebApplication1.Controllers
{
    public class MathController : ApiController
    {
        [HttpPost]
        [HttpGet]
        [ActionName("Calculate")]
        public IHttpActionResult Calculate([FromBody] string expression)
        {
            try
            {
                double result = CalculateExpression(expression);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error evaluating expression: {ex.Message}");
            }
        }

        private double CalculateExpression(string expression)
        {
            DataTable tempTable = new DataTable();
            var result = tempTable.Compute(expression, "");
            return Convert.ToDouble(result);
        }
    }
}