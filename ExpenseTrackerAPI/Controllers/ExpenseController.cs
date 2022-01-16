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
        public IExpenseRepository _expenseRepo { get; }
        public ExpenseController(IUnitOfWork unitOfWork, IExpenseRepository expenseRepository)
        {
            _unitOfWork = unitOfWork;
            _expenseRepo = expenseRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var expense = _unitOfWork.ExpenseRepository.GetAll();
            var expense = _expenseRepo.getAllEnpenses();

            return Ok(expense);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int Id)
        {
            var expense = _unitOfWork.ExpenseRepository.Get(Id)
;
            _unitOfWork.ExpenseRepository.Delete(expense);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpGet("id")]
        public IActionResult GET(int id)
        {
            var expense = _unitOfWork.ExpenseRepository.Get(id)
;
            return Ok(expense);
        }

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
    }
}
