using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminController : ControllerBase
    {
        private readonly ITerminService _service;
        public TerminController(ITerminService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Model.Termin>> Get()
        {
            return _service.Get();
        }

        [HttpPut("{id}")]
        public Model.Termin Update(int id, TerminInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpPost]
        public Model.Termin Insert(TerminInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpGet("{id}")]
        public Model.Termin GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}