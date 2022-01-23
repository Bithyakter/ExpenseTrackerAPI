using ExpenseTracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Controllers
{
    public class ExpenseCategoryUIController : Controller
    {
        #region Index
        public async Task<IActionResult> Index()
        {
            var category = new List<ExpenseCategoryDTO>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:60228/api/ExpenseCategory");

                string result = response.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<List<ExpenseCategoryDTO>>(result);
            }
            return View(category);
        }
        #endregion

        #region HttpGet-Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var category = new ExpenseCategoryDTO();
            return View(category);
        }
        #endregion

        #region HttpPost-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseCategoryDTO category)
        {
            var expenseJson = JsonConvert.SerializeObject(category);
            using (var client = new HttpClient())
            {
                HttpContent httpContent = new StringContent(expenseJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:60228/api/ExpenseCategory", httpContent);

                string result = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region HttpGet-Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var expenseD = new ExpenseCategoryDTO();
            using (var client = new HttpClient())
            {
                var exResponse = await client.GetAsync("http://localhost:60228/api/ExpenseCategory/getbyid?id=" + id);
                string result2 = exResponse.Content.ReadAsStringAsync().Result;
                expenseD = JsonConvert.DeserializeObject<ExpenseCategoryDTO>(result2);
            }

            return View(expenseD);
        }
        #endregion

        #region HttpPost-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExpenseCategoryDTO category)
        {
            var expenseJson = JsonConvert.SerializeObject(category);
            using (var client = new HttpClient())
            {
                HttpContent httpContent = new StringContent(expenseJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:60228/api/ExpenseCategory", httpContent);

                string result = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }
        #endregion

        //#region HttpGet-Delete
        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var category = new ExpenseCategoryDTO();
        //    using (var client = new HttpClient())
        //    {
        //        var response = await client.GetAsync("http://localhost:60228/api/ExpenseCategory/getbyid?id=" + id);
        //        string result = response.Content.ReadAsStringAsync().Result;
        //        category = JsonConvert.DeserializeObject<ExpenseCategoryDTO>(result);
        //    }
        //    return View(category);
        //}
        //#endregion

        #region HttpPost-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ExpenseCategoryDTO dto)
        {
            var expenseJson = JsonConvert.SerializeObject(dto);
            using (var client = new HttpClient())
            {
                HttpContent httpContent = new StringContent(expenseJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:60228/api/ExpenseCategory/delete", httpContent);

                string result = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
