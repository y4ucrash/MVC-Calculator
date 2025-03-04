using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return Json(new { success = false, result = "Error: Empty Expression!" });
            }
            try
            {
                var result = EvaluateException(expression);
                return Json(new { success = true, result });
            }
            catch
            {
                return Json(new { success = false, result = "Error: Invalid Expression!" });
            }
        }
        private static double EvaluateException(string expression)
        {
            var table = new DataTable();
            return Convert.ToDouble(table.Compute(expression, ""));
        }
    }
}