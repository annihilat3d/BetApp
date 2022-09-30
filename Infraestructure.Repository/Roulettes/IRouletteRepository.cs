using Google.Cloud.Firestore;
using Infraestructure.Common.Constants;
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
    public interface IRouletteRepository
    {
        Task<string> Create();
        Task<RouletteResponseDTO> OpenRoulette(string idRoulette);
        Task<RouletteResponseDTO> AddParticipant(string idRoulette, Participant participant);
        Task<RouletteResponseDTO> CloseRoulette(string idRoulette, Roulette oldRoulette);
        Task<List<Roulette>> GetAll();
        Task<Roulette> GetById(string idRoulette);
    }
}
