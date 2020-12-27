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
    public class UplateController : ControllerBase
    {
        private readonly IUplateService _service;
        public UplateController(IUplateService service)
        {
            _service = service;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public ActionResult<List<Model.uplate>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public Model.uplate GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}