using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infraestructure.Common.Constants;
using Infraestructure.Repository.Roulettes;
using Domain.Roulettes;
using Infraestructure.Repository.Rules;
using Domain.Bets;

namespace Infraestructure.Config.Dependencies
{
    public class Container
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            #region Mapper           

            // AutoMapper
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region Implementations

            services.AddTransient<IEnvironmentConstant, EnvironmentConstant>();

            #region Repositories

            services.AddTransient<IRouletteRepository, RouletteRepository>();
            services.AddTransient<IRulesRepository, RulesRepository>();

            #endregion

            #region Services

            services.AddTransient<IRouletteService, RouletteService>();
            services.AddTransient<IBetService, BetService>();

            #endregion

            #endregion

        }

    }
}
