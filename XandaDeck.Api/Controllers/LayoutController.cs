﻿using Microsoft.AspNetCore.Mvc;
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
    public class LayoutController : ControllerBase
    {
        private readonly IRepository<Layout> _repository;

        public LayoutController(IRepository<Layout> repository)
        {
            _repository = repository;
        }

        // GET: api/<LayoutController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LayoutController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LayoutController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LayoutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LayoutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
