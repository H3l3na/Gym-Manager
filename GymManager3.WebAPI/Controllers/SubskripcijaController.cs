using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubskripcijaController : ControllerBase
    {
        private readonly ISubskripcijaService _service;
        public SubskripcijaController(ISubskripcijaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Subskripcija>> Get()
        {
            return _service.Get();
        }
    }
}