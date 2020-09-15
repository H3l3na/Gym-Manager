using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface ISlobodniTerminiService
    {
        List<Model.SlobodniTermini> Get();
        Model.SlobodniTermini GetById(int id);
    }
}
