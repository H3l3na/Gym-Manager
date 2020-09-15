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
    public class SlobodniTerminiController : ControllerBase
    {
        private readonly ISlobodniTerminiService _service;
        public SlobodniTerminiController(ISlobodniTerminiService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.SlobodniTermini>> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public Model.SlobodniTermini GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}