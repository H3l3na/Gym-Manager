using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.Services
{
    public interface IRecommendService
    {
        List<Model.treneri> RecommendTrainer(int trenerId);
    }
}
