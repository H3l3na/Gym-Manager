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
    public class RecommendController : ControllerBase
    {
        public IRecommendService _service { get; set; }

        public RecommendController(IRecommendService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.treneri> RecommendTrainer([FromQuery]RecommendedSearchRequest trener)
        {
            return _service.RecommendTrainer(trener.TrenerID);
        }
    }
}