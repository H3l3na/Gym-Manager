using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager3.WebAPI.ML
{
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 2000)]
        public uint ProductID { get; set; }

        [KeyType(count: 2000)]
        public uint CoPurchaseProductID { get; set; }
    }
}
