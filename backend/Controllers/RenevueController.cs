using backend.Domain;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RenevueController : ControllerBase
    {
        public RenevueController()
        {
            _renevueService = new RenevueService();
        }

        RenevueService _renevueService;

        [HttpGet]
        public List<Renevue> Get()
        {
            return _renevueService.List();
        }

        [HttpGet("filter-period")]
        public List<Renevue> GetFilterDate(DateTime initial, DateTime end)
        {
            return _renevueService.FilterPeriod(initial, end);
        }

        [HttpGet("filter-type")]
        public List<Renevue> GetFilterType(int type)
        {
            return _renevueService.FilterType(type);
        }

        [HttpPost]
        public void Save([FromBody] Renevue renevueSave)
        {
            _renevueService.Create(renevueSave);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _renevueService.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Renevue renevueUpdate, int id)
        {
            _renevueService.Update(renevueUpdate, id);
        }
    }
}