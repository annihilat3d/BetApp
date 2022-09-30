using Google.Cloud.Firestore;
using Infraestructure.Common.Constants;
using Infraestructure.Common.Helper;
using Infraestructure.Model.Models;
using Infraestructure.Repository.Entities;
using Infraestructure.Repository.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Roulettes
{
    public class RouletteRepository : IRouletteRepository
    {
        private readonly FirestoreDb db;

        public RouletteRepository()
        {
            db = new FirebaseDBContext().fireStoreDb;
        }

        async public Task<string> Create()
        {
            var roulette = new Roulette();
            CollectionReference collection = db.Collection(FirestoreConstant.Roulette);
            roulette.CreationDate = Timestamp.GetCurrentTimestamp();
            roulette.IsFinished = false;
            roulette.IsOpen = false;
            var result = await collection.AddAsync(roulette);

            return result.Id;
        }

        async public Task<RouletteResponseDTO> OpenRoulette(string idRoulette)
        {
            DocumentReference requestDoc = db.Collection(FirestoreConstant.Roulette).Document(idRoulette);
            DocumentSnapshot querySnapshot = await requestDoc.GetSnapshotAsync();
            var rouletteResponse = new RouletteResponseDTO();
            if (querySnapshot.Exists)
            {
                Roulette roulette = querySnapshot.ConvertTo<Roulette>();
                if (roulette.IsFinished)
                {
                    rouletteResponse.IsSuccesful = false;
                    rouletteResponse.Errors = new List<string>() { String.Format(ErrorMessageConstant.CloseRouletteError, idRoulette) };

                    return rouletteResponse;
                }
                roulette.IsOpen = true;
                await requestDoc.SetAsync(roulette, SetOptions.MergeFields(nameof(Roulette.IsOpen)));
                rouletteResponse.IsSuccesful = true;
            }
            else
            {
                rouletteResponse.IsSuccesful = false;
                rouletteResponse.Errors = new List<string>() { String.Format(ErrorMessageConstant.NotFoundRouletteError, idRoulette) };
            }

            return rouletteResponse;
        }

        async public Task<RouletteResponseDTO> AddParticipant(string idRoulette, Participant participant)
        {
            DocumentReference requestDoc = db.Collection(FirestoreConstant.Roulette).Document(idRoulette);
            DocumentSnapshot querySnapshot = await requestDoc.GetSnapshotAsync();
            var rouletteResponse = new RouletteResponseDTO();
            if (querySnapshot.Exists)
            {
                Roulette roulette = querySnapshot.ConvertTo<Roulette>();
                if (roulette.IsFinished || !roulette.IsOpen)
                {
                    rouletteResponse.IsSuccesful = false;
                    rouletteResponse.Errors = new List<string>() { ErrorMessageConstant.CloseRouletteError };

                    return rouletteResponse;
                }
                if (roulette.Participants != null)
                    roulette.Participants.Add(participant);
                else
                    roulette.Participants = new List<Participant>() { participant };
                await requestDoc.SetAsync(roulette, SetOptions.MergeFields(nameof(Roulette.Participants)));
                rouletteResponse.IsSuccesful = true;
            }
            else
            {
                rouletteResponse.IsSuccesful = false;
                rouletteResponse.Errors = new List<string>() { String.Format(ErrorMessageConstant.NotFoundRouletteError, idRoulette) };
            }

            return rouletteResponse;
        }

        async public Task<RouletteResponseDTO> CloseRoulette(string idRoulette, Roulette oldRoulette)
        {
            DocumentReference requestDoc = db.Collection(FirestoreConstant.Roulette).Document(idRoulette);
            DocumentSnapshot querySnapshot = await requestDoc.GetSnapshotAsync();
            var rouletteResponse = new RouletteResponseDTO();
            if (querySnapshot.Exists)
            {
                if (oldRoulette.IsFinished)
                {
                    rouletteResponse.IsSuccesful = false;
                    rouletteResponse.Errors = new List<string>() { ErrorMessageConstant.CreatedRouletteError };

                    return rouletteResponse;
                }
                oldRoulette.IsFinished = true;
                oldRoulette.IsOpen = false;
                oldRoulette.ClosingDate = Timestamp.GetCurrentTimestamp();
                var fields = ReflectionHelper.SetFilesUpdate(oldRoulette);
                await requestDoc.SetAsync(oldRoulette, SetOptions.MergeFields(fields));
                rouletteResponse.IsSuccesful = true;
            }
            else
            {
                rouletteResponse.IsSuccesful = false;
                rouletteResponse.Errors = new List<string>() { String.Format(ErrorMessageConstant.NotFoundRouletteError, idRoulette) };
            }

            return rouletteResponse;
        }

        async public Task<List<Roulette>> GetAll()
        {
            Query requestQuery = db.Collection(FirestoreConstant.Roulette);
            QuerySnapshot requestQuerySnapshot = await requestQuery.GetSnapshotAsync();
            List<Roulette> roulettes = new List<Roulette>();
            foreach (var snapshot in requestQuerySnapshot)
            {
                if (snapshot.Exists)
                {
                    Roulette roulette = snapshot.ConvertTo<Roulette>();
                    roulette.Id = snapshot.Id;
                    roulettes.Add(roulette);
                }
            }
            return roulettes.ToList();
        }

        async public Task<Roulette> GetById(string idRoulette)
        {
            var snapshot = await db.Collection(FirestoreConstant.Roulette).Document(idRoulette).GetSnapshotAsync();
            Roulette roulette = snapshot.ConvertTo<Roulette>();
            roulette.Id = snapshot.Id;

            return roulette;
        }
    }
}
