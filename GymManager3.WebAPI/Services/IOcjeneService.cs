using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IOcjeneService
    {
        List<Model.Ocjene> Get(OcjeneSearchRequest request);
        Model.Ocjene InsertRatingByUser(OcjeneUpsertRequest request);
    }
}
