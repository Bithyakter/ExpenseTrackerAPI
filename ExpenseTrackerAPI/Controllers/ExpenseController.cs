using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IRepository<Expense> _exRepo;
        public ExpenseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int id)    //FromQuery=fixed size 32
        {
            var getExpense = _unitOfWork.ExpenseRepository.GetAll();

            return Ok(getExpense);
        }


        [HttpPost]
        public IActionResult AddExpenseAndCategory()
        {
            var expense = new Expense
            {
                //ExpenseDate = 2022/01/01,
                Amount = 12000
            };

            var exCategory = new ExpenseCategory
            {
                CategoryName = "House-Rent"
            };

            _unitOfWork.ExpenseRepository.Add(expense);
            _unitOfWork.ExpenseCategoryRepository.Add(exCategory);
            _unitOfWork.SaveChanges();

            return Ok();
        }
    }
}
