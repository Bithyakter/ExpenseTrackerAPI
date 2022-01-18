using ExpenseTracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace ExpenseTracker.Web.Controllers
{
    public class ExpenseUIController : Controller
    {
        #region Index
        public async Task<IActionResult> Index()
        {
            var expense = new List<ExpenseDTO>();

           using (var client = new HttpClient())
           {
               var response = await client.GetAsync("http://localhost:60228/api/Expense");

                string result = response.Content.ReadAsStringAsync().Result;
                expense = JsonConvert.DeserializeObject<List<ExpenseDTO>>(result);
            }
            return View(expense);
        }
        #endregion

        #region HttpGet-Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var expenseCategory = new List<ExpenseCategoryDTO>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:60228/api/ExpenseCategory");

                string result = response.Content.ReadAsStringAsync().Result;
                expenseCategory = JsonConvert.DeserializeObject<List<ExpenseCategoryDTO>>(result);
            }

            var expense = new ExpenseDTO();
            expense.CategoryDropDownList = expenseCategory;

            return View(expense);
        }
        #endregion

        #region HttpPost-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseDTO expense)
        {
            var expenseJson = JsonConvert.SerializeObject(expense);
            using (var client = new HttpClient())
            {
                HttpContent httpContent = new StringContent(expenseJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:60228/api/Expense", httpContent);

                string result = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region HttpGet-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ExpenseCategory = new List<ExpenseCategoryDTO>();
            var expenseD = new ExpenseDTO();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:60228/api/ExpenseCategory");
                string result = response.Content.ReadAsStringAsync().Result;
                ExpenseCategory = JsonConvert.DeserializeObject<List<ExpenseCategoryDTO>>(result);

                var exResponse = await client.GetAsync("http://localhost:60228/api/Expense/getbyid?id=" + id);
                string result2 = exResponse.Content.ReadAsStringAsync().Result;
                expenseD = JsonConvert.DeserializeObject<ExpenseDTO>(result2);
            }

            expenseD.CategoryDropDownList = ExpenseCategory;
            return View(expenseD);
        }
        #endregion

        #region HttpPost-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExpenseDTO expense)
        {
            var expenseJson = JsonConvert.SerializeObject(expense);
            using (var client = new HttpClient())
            {
                HttpContent httpContent = new StringContent(expenseJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:60228/api/Expense", httpContent);

                string result = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
