using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IVrstaSubskripcijeService
    {
        List<Model.VrstaSubskripcije> Get();
    }
}
