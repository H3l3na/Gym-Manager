using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplataController : Controller
    {
        
            private readonly IUplataService _service;
            public UplataController(IUplataService service)
            {
                _service = service;
            }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult<List<Model.Uplata>> Get([FromQuery] UplataSearchRequest request)
            {
                return _service.Get(request);
            }
        [HttpGet("{id}")]
        public Model.Uplata GetById(int id)
        {
            return _service.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Model.Uplata Insert (UplataInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}