using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Entities
{
    [FirestoreData]
    public class Participant
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string BetColor { get; set; }
        [FirestoreProperty]
        public double BetMoney { get; set; }
        [FirestoreProperty]
        public int BetNumber { get; set; }
        [FirestoreProperty]
        public bool IsWinner { get; set; }
        [FirestoreProperty]
        public double MoneyEarned { get; set; }
        [FirestoreProperty]
        public string BetType { get; set; }
    }
}
