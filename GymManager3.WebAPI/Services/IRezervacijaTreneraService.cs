using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IRezervacijaTreneraService
    {
        List<Model.RezervacijaTrenera> Get();
        Model.RezervacijaTrenera Insert(RezervacijaTreneraInsertRequest request);
        bool Delete(int id);
    }
}
