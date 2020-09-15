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
    public class RezervacijaTreneraController : ControllerBase
    {
        private readonly IRezervacijaTreneraService _service;
        public RezervacijaTreneraController(IRezervacijaTreneraService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.RezervacijaTrenera> Get()
        {
            return _service.Get();
        }

        [HttpPost]
        public Model.RezervacijaTrenera Insert(RezervacijaTreneraInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}