using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradController : Controller
    {
        private readonly IGradService _service;
        public GradController(IGradService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Grad>> Get()
        {
            return _service.Get();
        }
    }
}