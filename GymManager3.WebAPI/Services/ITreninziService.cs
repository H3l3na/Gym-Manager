using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface ITreninziService
    {
       List<Model.Trening> Get(TreninziSearchRequest request);
        Model.Trening Insert(TreninziInsertRequest request);
        Model.Trening GetById(int id);
        Model.Trening Update(int id, TreninziInsertRequest request);
        Model.Trening Delete(int id);
    }
}
