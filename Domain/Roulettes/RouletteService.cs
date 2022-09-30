using AutoMapper;
using Domain.Bets;
using Infraestructure.Common.Constants;
using Infraestructure.Model.Models;
using Infraestructure.Repository.Entities;
using Infraestructure.Repository.Roulettes;
using Infraestructure.Repository.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Roulettes
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        private readonly IBetService _betService;
        private readonly IMapper _mapper;

        public RouletteService(IRouletteRepository rouletteRepository,
            IBetService betService,
            IMapper mapper)
        {
            _rouletteRepository = rouletteRepository;
            _betService = betService;
            _mapper = mapper;
        }

        async public Task<RouletteResponseDTO> BetOnRoulette(BetParticipantDTO betParticipantDTO, string idRoulette)
        {
            var rouletteResponse = new RouletteResponseDTO();
            var participant = _mapper.Map<ParticipantDTO>(betParticipantDTO);
            var errors = await _betService.BetValidate(participant);
            if (errors.Count <= 0)
                return await _rouletteRepository.AddParticipant(idRoulette, _mapper.Map<Participant>(participant));

            rouletteResponse.Errors = errors;
            rouletteResponse.IsSuccesful = false;

            return rouletteResponse;
        }
        
        async public Task<RouletteResponseDTO> CloseRoulette(string idRoulette)
        {
            var roulette = await _rouletteRepository.GetById(idRoulette);
            var betCalculate = await _betService.BetCalculate(_mapper.Map<List<ParticipantDTO>>(roulette.Participants));
            roulette.WinnerNumber = betCalculate.WinnerNumber;
            roulette.WinnerColor = betCalculate.WinnerColor;
            roulette.Participants =_mapper.Map<List<Participant>>(betCalculate.Participants);
            var rouletteResponse = await _rouletteRepository.CloseRoulette(idRoulette, _mapper.Map<Roulette>(roulette));

            return rouletteResponse;
        }

        async public Task<string> CreateRoulette() => await _rouletteRepository.Create();

        async public Task<List<RouletteDTO>> GetAllRoulettes() {    
            var roulettes = await _rouletteRepository.GetAll();
            return _mapper.Map<List<RouletteDTO>>(roulettes);
        }

        async public Task<RouletteDTO> GetById(string idRoulette)
        {
            var roulette = await _rouletteRepository.GetById(idRoulette);
            return _mapper.Map<RouletteDTO>(roulette);
        }

        async public Task<RouletteResponseDTO> OpenRoulette(string idRoulette) => await _rouletteRepository.OpenRoulette(idRoulette);

    }
}
