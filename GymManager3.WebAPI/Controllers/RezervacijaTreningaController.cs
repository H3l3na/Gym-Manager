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
    public class RezervacijaTreningaController : ControllerBase
    {
        private readonly IRezervacijaTreningaService _service;
        public RezervacijaTreningaController(IRezervacijaTreningaService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.RezervacijaTreninga> Get()
        {
            return _service.Get();
        }
    }
}