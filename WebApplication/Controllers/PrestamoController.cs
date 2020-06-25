using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroPrestamo.BLL;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        // GET: api/Prestamo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Prestamo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return PrestamosBLL.Buscar(id).concepto;
        }

        // POST: api/Prestamo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Prestamo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
