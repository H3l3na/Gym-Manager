using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager3.Model;
using GymManager3.Model.Requests;

namespace GymManager3.WebAPI.Services
{
    public interface ITreneriService
    {
        List<Trener> Get(TreneriSearchRequest request);
        Model.Trener GetById(int id);
        Model.Trener Insert(TreneriInsertRequest request);
        Model.Trener Authenticiraj(string username, string pass);
        Model.Trener Update(int id, TrenerUpdateRequest request);

        Model.Trener Delete(int id);

    }
}
