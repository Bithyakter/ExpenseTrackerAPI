﻿using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.ViewModel;
using ExpenseTracker.Infrastructure.Contracts;
using ExpenseTracker.Infrastructure.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;

        private readonly DataContext _context;
       
        public ExpenseCategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _unitOfWork.ExpenseCategoryRepository.GetAll();

            return Ok(category);
        }

        [HttpGet("getbyid")]
        public IActionResult GET(int id)
        {
            var category = _unitOfWork.ExpenseCategoryRepository.Get(id);
            return Ok(category);
        }

        #region SaveOrUpdate
        [HttpPost]
        public IActionResult SaveOrUpdate([FromBody] ExpenseCategory category)
        {
            if (category.CategoryID == 0)
            {
                var IsExist = _unitOfWork.ExpenseCategoryRepository.IsExpenseCategoryDuplicate(category);

                if(!IsExist)
                {
                    var categoryAdd = _unitOfWork.ExpenseCategoryRepository.Add(category);
                    _unitOfWork.SaveChanges();
                    return Ok(categoryAdd);
                }
                else
                {
                    return BadRequest("Duplicate Found!");
                }
                
            }
            else
            {
                var categoryUp = _unitOfWork.ExpenseCategoryRepository.Update(category);
                _unitOfWork.SaveChanges();

                return Ok(categoryUp);
            }
        }
        #endregion

        #region HttpPost-Delete
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] ExpenseCategoryVM category)
        {
            var categoryInDb = _unitOfWork.ExpenseCategoryRepository.Get(category.CategoryID);
            _unitOfWork.ExpenseCategoryRepository.Delete(categoryInDb);
            _unitOfWork.SaveChanges();

            return Ok();
        }
        #endregion
    }
}
