using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Contracts;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ExpenseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var expense = _unitOfWork.ExpenseRepository.getAllExpenses();

            return Ok(expense);
        }

        [HttpGet("getbyid")]
        public IActionResult GET(int id)
        {
            var expense = _unitOfWork.ExpenseRepository.Get(id);
            return Ok(expense);
        }

        #region HttpPost-Delete
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] Expense expense)
        {
            var expenseInDb = _unitOfWork.ExpenseRepository.Get(expense.ExpenseID);
            _unitOfWork.ExpenseRepository.Delete(expenseInDb);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        #endregion

        #region SaveOrUpdate
        [HttpPost]
        public IActionResult SaveOrUpdate([FromBody] Expense expense)
        {
            if (expense.ExpenseID == 0)
            {
                var expenseAdd = _unitOfWork.ExpenseRepository.Add(expense);
                _unitOfWork.SaveChanges();
                return Ok(expenseAdd);
            }
            else
            {
                var expenseUp = _unitOfWork.ExpenseRepository.Update(expense);
                _unitOfWork.SaveChanges();

                return Ok(expenseUp);
            }
        }
        #endregion
    }
}
