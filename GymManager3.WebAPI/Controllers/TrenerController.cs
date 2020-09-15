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
    public class TrenerController : ControllerBase
    {
        private readonly ITrenerService _service;
        public TrenerController(ITrenerService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.treneri>> Get()
        {
            return _service.Get();
        }
    }
}