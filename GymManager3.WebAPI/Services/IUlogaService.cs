using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IUlogaService
    {
        List<Model.Uloge> Get();
        Model.Uloge GetById(int id);
    }
}
