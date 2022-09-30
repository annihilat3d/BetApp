using Google.Cloud.Firestore;
using Infraestructure.Common.Constants;
using Infraestructure.Repository.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Rules
{
    public class RulesRepository : IRulesRepository
    {
        private readonly FirestoreDb db;

        public RulesRepository()
        {
            db = new FirebaseDBContext().fireStoreDb;
        }

        async public Task<Entities.Rules> Get()
        {
            Query requestQuery = db.Collection(FirestoreConstant.Rules)
                 .WhereEqualTo(nameof(Entities.Rules.IsActive), true);
            QuerySnapshot requestQuerySnapshot = await requestQuery.GetSnapshotAsync();
            List<Entities.Rules> rules = new List<Entities.Rules>();
            foreach (var snapshot in requestQuerySnapshot)
            {
                if (snapshot.Exists)
                {
                    Entities.Rules rule = snapshot.ConvertTo<Entities.Rules>();
                    rule.Id = snapshot.Id;
                    rules.Add(rule);
                }
            }
            return rules.FirstOrDefault();
        }
    }
}
