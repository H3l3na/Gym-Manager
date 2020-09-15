using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcjeneController : ControllerBase
    {
        private readonly IOcjeneService _service;

        public OcjeneController(IOcjeneService service)
        {
            _service = service;
        }

       // [Authorize]
        [HttpGet]
        public List<Model.Ocjene> Get([FromQuery]OcjeneSearchRequest request)
        {
            return _service.Get(request);
        }

        //[Authorize]
        [HttpPost]
        public Model.Ocjene InsertRatingByUser(OcjeneUpsertRequest request)
        {
            return _service.InsertRatingByUser(request);
        }
    }
}