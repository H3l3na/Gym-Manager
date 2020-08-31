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
    public class VrstaSubskripcijeController : ControllerBase
    {
        private readonly IVrstaSubskripcijeService _service;
        public VrstaSubskripcijeController(IVrstaSubskripcijeService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.VrstaSubskripcije>> Get()
        {
            return _service.Get();
        }
    }
}