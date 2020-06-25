using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroPrestamo.BLL;
using RegistroPrestamo.Models;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        // GET: api/Prestamo
        [HttpGet]
        public ActionResult<List<Prestamo>> Get()
        {
            return PrestamosBLL.GetPrestamos();
        }




    }
}
