//using GymManager3.WebAPI.Database;
using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GymManager3.WebAPI.Services
{
    public interface IPolaznikService
    {
        List<Polaznik> Get(PolazniciSearchRequest request);
        Model.Polaznik Insert(Model.Requests.PolazniciInsertRequest request);
        Model.Polaznik GetById(int id);
        Model.Polaznik Update(int id, PolazniciUpdateRequest request);
        Model.Polaznik Authenticiraj(string username, string pass);

        Model.Polaznik Delete(int id);
        //Model.Polaznik GetByUsername(PolaznikUsernameSearchRequest request);
    }
}
