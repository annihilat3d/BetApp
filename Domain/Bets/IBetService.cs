using Infraestructure.Model.Models;
using Infraestructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bets
{
    public interface IBetService
    {
        Task<List<string>> BetValidate(ParticipantDTO participant);
        Task<BetCalculateDTO> BetCalculate(List<ParticipantDTO> roulette);

    }
}
