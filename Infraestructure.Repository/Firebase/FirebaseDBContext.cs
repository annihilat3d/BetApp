using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Firebase
{
    public class FirebaseDBContext
    {
        readonly string PROJECTID = Environment.GetEnvironmentVariable("ProjectId") ?? "betsapp-b0157";
        public FirestoreDb fireStoreDb;
        public FirebaseDBContext()
        {
            fireStoreDb = FirestoreDb.Create(PROJECTID);
        }
    }
}
