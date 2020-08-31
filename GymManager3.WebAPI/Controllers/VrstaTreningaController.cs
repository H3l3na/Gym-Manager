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
    public class VrstaTreningaController : ControllerBase
    {
        private readonly IVrstaTreningaService _service;
        public VrstaTreningaController(IVrstaTreningaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.VrstaTreninga>> Get()
        {
            return _service.Get();
        }
    }
}