using backend.Domain;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        public ExpenseController()
        {
            _expenseService = new ExpenseService();
        }

        ExpenseService _expenseService;

        [HttpGet]
        public List<Expense> Get()
        {
            return _expenseService.List();
        }

        [HttpGet("filter-period")]
        public List<Expense> GetFilterDate(DateTime initial, DateTime end)
        {
            return _expenseService.FilterPeriod(initial, end);
        }

        [HttpGet("filter-type")]
        public List<Expense> GetFilterType(int type)
        {
            return _expenseService.FilterType(type);
        }

        [HttpPost]
        public void Save([FromBody] Expense expenseSave)
        {
            _expenseService.Create(expenseSave);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _expenseService.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Expense expenseUpdate, int id)
        {
            _expenseService.Update(expenseUpdate, id);
        }
    }
}
