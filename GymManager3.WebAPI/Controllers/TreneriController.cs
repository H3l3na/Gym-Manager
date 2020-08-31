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
    public class TreneriController : ControllerBase
    {
        private readonly ITreneriService _service;
        public TreneriController(ITreneriService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Trener>> Get([FromQuery] TreneriSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Trener GetById(int id)
        {
            return _service.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Model.Trener>Insert (TreneriInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}