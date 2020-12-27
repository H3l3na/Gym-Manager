using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreninziController : ControllerBase
    {
        private readonly ITreninziService _service;
        public TreninziController(ITreninziService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Trening> Get([FromQuery] TreninziSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpPost]
        public ActionResult<Model.Trening> Insert (TreninziInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpGet("{id}")]
        public Model.Trening GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPut("{id}")]
        public Model.Trening Update(int id, TreninziInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public Model.Trening Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}