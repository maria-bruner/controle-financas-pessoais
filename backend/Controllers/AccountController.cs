using backend.Domain;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {
        }
        AccountService _accountService = new AccountService();

        [HttpGet]
        public List<Account> Get()
        {
            return _accountService.List();
        }

        [HttpPost]
        public void Save([FromBody] Account accountSave)
        {
            _accountService.Create(accountSave);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _accountService.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Account accountUpdate, int id)
        {
            _accountService.Update(accountUpdate, id);
        }
    }
}
