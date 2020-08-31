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
    public class KorisniciUlogeController : ControllerBase
    {
        private readonly IKorisniciUlogeService _service;
        public KorisniciUlogeController(IKorisniciUlogeService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.KorisniciUloge> Get()
        {
            return _service.Get();
        }
    }
}