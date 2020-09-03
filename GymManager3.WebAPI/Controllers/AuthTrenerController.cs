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
    public class AuthTrenerController : ControllerBase
    {
        private readonly IAuthTrenerService _service;
        public AuthTrenerController(IAuthTrenerService service)
        {
            _service = service;
        }
        [HttpGet("{username},{pass}")]
        public int Auth(string username, string pass)
        {
            return _service.Auth(username, pass);
        }
    }
}