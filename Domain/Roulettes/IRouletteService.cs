using Infraestructure.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Roulettes
{
    public interface IRouletteService
    {
        Task<string> CreateRoulette();
        Task<RouletteResponseDTO> OpenRoulette(string idRoulette);
        Task<RouletteResponseDTO> BetOnRoulette(BetParticipantDTO participant, string idRoulette);
        Task<RouletteResponseDTO> CloseRoulette(string idRoulette);
        Task<RouletteDTO> GetById(string idRoulette);
        Task<List<RouletteDTO>> GetAllRoulettes();
    }
}
