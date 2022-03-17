using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XandaDeck.Core.Interfaces;
using XandaDeck.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XandaDeck.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IRepository<Device> _repository;

        public DeviceController(IRepository<Device> repository)
        {
            _repository = repository;
        }

        // GET: api/<DeviceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        // GET api/<DeviceController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetByIdAsync(id)); 
        }

        // POST api/<DeviceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeviceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeviceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
