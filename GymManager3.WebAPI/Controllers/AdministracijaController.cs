using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model.Requests;
using GymManager3.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManager3.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministracijaController : ControllerBase
    {
        private readonly IAdministracijaService _service;
        public AdministracijaController(IAdministracijaService service)
        {
            _service = service;
        }
       // [Authorize(Roles ="Administrator")]
        [HttpPost]
        public Model.Administracija Insert(AdministracijaInsertRequest request)
        {
            return _service.Insert(request);
        }

        
        [HttpGet]
        public ActionResult<List<Model.Administracija>> Get([FromQuery] AdministracijaSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Administracija GetById(int id)
        {
            return _service.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public Model.Administracija Update(int id, AdministracijaInsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}