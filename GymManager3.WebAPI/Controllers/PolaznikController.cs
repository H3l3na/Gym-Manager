using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolaznikController : Controller
    {
        private readonly IPolaznikService _service;
        public PolaznikController(IPolaznikService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<List<Model.Polaznik>> Get([FromQuery] PolazniciSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{username}")]
        public int GetByUsername(string username)
        {
            return _service.GetByUsername(username);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Model.Polaznik Insert (PolazniciInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpGet("{id}")]
        public Model.Polaznik GetById(int id)
        {
            return _service.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public Model.Polaznik Update(int id, PolazniciInsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}