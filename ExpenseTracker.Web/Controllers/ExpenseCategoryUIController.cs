using ExpenseTracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Controllers
{
    public class ExpenseCategoryUIController : Controller
    {
        #region Index
        public async Task<IActionResult> Index(string filter, int pageIndex = 1, string sortExpression = "CategoryName")
        {
            var category = new List<ExpenseCategoryDTO>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:60228/api/ExpenseCategory");

                string result = response.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<List<ExpenseCategoryDTO>>(result);
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {

                category = category.Where(p => p.CategoryName.Contains(filter)).ToList();

            }
            var pagedCategory = PagingList.Create(category, 3, pageIndex, sortExpression, "CompanyName");

            pagedCategory.RouteValue = new RouteValueDictionary {
                { "filter", filter}
                };

            return View(pagedCategory);
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

                if(response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    category.IsDuplicateFound = true;
                    ModelState.AddModelError("CategoryName", "Duplicate Found!");
                    return View(category);
                }
            }
            TempData["Success"] = "Data Created Successfully!";
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

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    category.IsDuplicateFound = true;
                    ModelState.AddModelError("CategoryName", "Duplicate Found!");
                    return View(category);
                }

            }
            TempData["Success"] = "Data Updated Successfully!";

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

        //#region HttpPost-Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(ExpenseCategoryDTO dto)
        //{
        //    var expenseJson = JsonConvert.SerializeObject(dto);
        //    using (var client = new HttpClient())
        //    {
        //        HttpContent httpContent = new StringContent(expenseJson, Encoding.UTF8, "application/json");
        //        var response = await client.PostAsync("http://localhost:60228/api/ExpenseCategory/delete", httpContent);

        //        string result = response.Content.ReadAsStringAsync().Result;
        //    }
        //    return RedirectToAction("Index");
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
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    ModelState.AddModelError("CategoryID", "You can't Delete this!");
                    TempData["DeleteError"] = "You can't Delete!";

                    return RedirectToAction("Index");
                }
            }
            TempData["Success"] = "Data Deleted Successfully!";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
