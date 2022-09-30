using AutoMapper;
using Google.Cloud.Firestore;
using Infraestructure.Model.Models;
using Infraestructure.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Config.Dependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Roulette, RouletteDTO>()
                .ForMember(dest => dest.CreationDate, o => o.MapFrom(src => src.CreationDate.ToDateTime()))
                .ForMember(dest => dest.ClosingDate, o => o.MapFrom(src => src.ClosingDate.ToDateTime()))
                .ForMember(dest => dest.Participants, o => o.MapFrom(src => src.Participants));

            CreateMap<Roulette, RouletteDTO>()
                 .ForMember(dest => dest.CreationDate, o => o.MapFrom(src => src.CreationDate.ToDateTime()))
                 .ForMember(dest => dest.ClosingDate, o => o.MapFrom(src => src.ClosingDate.ToDateTime()))
                 .ForMember(dest => dest.Participants, o => o.MapFrom(src => src.Participants));


            CreateMap<ParticipantDTO, Participant>()
                .ReverseMap();

            CreateMap<Participant, ParticipantDTO>()
                .ReverseMap();

            CreateMap<BetParticipantDTO, ParticipantDTO>()
                .ReverseMap();
        }
    }
}
