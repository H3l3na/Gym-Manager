using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface ITerminService
    {
        List<Termin> Get();
        Model.Termin Update(int id, TerminInsertRequest request);
        Model.Termin Insert(TerminInsertRequest request);
        Model.Termin GetById(int id);
    }
}
