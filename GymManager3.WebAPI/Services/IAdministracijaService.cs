using GymManager3.Model;
using GymManager3.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IAdministracijaService
    {
        Model.Administracija Insert(Model.Requests.AdministracijaInsertRequest request);
        List<Administracija> Get(AdministracijaSearchRequest request);
        Model.Administracija GetById(int id);
        Model.Administracija Update(int id, AdministracijaInsertRequest request);
        Model.Administracija Authenticiraj(string username, string pass);
    }
}
