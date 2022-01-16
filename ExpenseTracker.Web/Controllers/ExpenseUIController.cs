using ExpenseTracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExpenseTracker.Web.Controllers
{
    public class ExpenseUIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var expense = new List<ExpenseDTO>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5000/api/Expense");

                string result = response.Content.ReadAsStringAsync().Result;
                expense = JsonConvert.DeserializeObject<List<ExpenseDTO>>(result);
            }
            return View(expense);
        }
    }
}
