using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Entities
{
    [FirestoreData]
    public class Rules
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public int BoxesNumber { get; set; }
        [FirestoreProperty]
        public double MaxBetMoney { get; set; }
        [FirestoreProperty]
        public double MultipleEarningColor { get; set; }
        [FirestoreProperty]
        public double MultipleEarningNumber { get; set; }
        [FirestoreProperty]
        public bool IsActive { get; set; }
    }
}
