using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IUplataService
    {
        List<Uplata> Get(UplataSearchRequest request);
        Model.Uplata GetById(int id);
        Model.Uplata Insert(UplataInsertRequest request);
    }
}
