using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface ISubskripcijaService
    {
        List<Model.Subskripcija> Get();
    }
}
