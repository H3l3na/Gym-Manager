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
    public class UlogaController : ControllerBase
    {
        private readonly IUlogaService _service;
        public UlogaController(IUlogaService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Uloge> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public Model.Uloge GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}