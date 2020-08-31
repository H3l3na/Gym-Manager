using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IAuthService
    {
        string Auth(/*string username, string password, int? roleId*/);
    }
}
