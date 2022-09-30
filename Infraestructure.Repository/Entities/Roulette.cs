using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Entities
{
    [FirestoreData]
    public class Roulette
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public bool IsOpen { get; set; }
        [FirestoreProperty]
        public bool IsFinished { get; set; }
        [FirestoreProperty]
        public Timestamp CreationDate { get; set; }
        [FirestoreProperty]
        public List<Participant> Participants { get; set; }
        [FirestoreProperty]
        public string WinnerColor { get; set; }
        [FirestoreProperty]
        public int WinnerNumber { get; set; }
        [FirestoreProperty]
        public Timestamp ClosingDate { get; set; }

    }
}
