using GymManager3.Model.Requests;
using GymManager3.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IRezervacijaTreningaService
    {
        List<Model.RezervacijaTreninga> Get();
        Model.RezervacijaTreninga Insert(RezervacijaTreningaInsertRequest request);
        bool Delete(int id);
    }
   
}
