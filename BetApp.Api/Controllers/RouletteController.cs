using Domain.Roulettes;
using Infraestructure.Common.Classes;
using Infraestructure.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BetApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;
        private readonly ILogger<RouletteController> _logger;
        public RouletteController(IRouletteService rouletteService,
            ILogger<RouletteController> logger)
        {
            _rouletteService = rouletteService;
            _logger = logger;
        }

        [HttpPost("Create")]
        async public Task<IActionResult> Create()
        {
            try
            {
                var data = await _rouletteService.CreateRoulette();
                return Ok(data.AsResponse((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Roulette/Create - " + ex.Message);
                return BadRequest(ResponseExtension.AsResponse<string>(null, (int)HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPut("Open/{idRoulette}")]
        async public Task<IActionResult> Open(string idRoulette)
        {
            try
            {
                var data = await _rouletteService.OpenRoulette(idRoulette);
                return Ok(data.AsResponse((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Roulette/Open/{idRoulette} - " + ex.Message);
                return BadRequest(ResponseExtension.AsResponse<string>(null, (int)HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPut("Bet/{idRoulette}")]
        async public Task<IActionResult> Bet(BetParticipantDTO participant, string idRoulette)
        {
            try
            {
                var data = await _rouletteService.BetOnRoulette(participant, idRoulette);
                return Ok(data.AsResponse((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Roulette/Bet/{idRoulette} - " + ex.Message);
                return BadRequest(ResponseExtension.AsResponse<string>(null, (int)HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPut("Close/{idRoulette}")]
        async public Task<IActionResult> Close(string idRoulette)
        {
            try
            {
                var data = await _rouletteService.CloseRoulette(idRoulette);
                return Ok(data.AsResponse((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Roulette/Close/{idRoulette} - " + ex.Message);
                return BadRequest(ResponseExtension.AsResponse<string>(null, (int)HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet("GetById/{idRoulette}")]
        async public Task<IActionResult> GetById(string idRoulette)
        {
            try
            {
                var data = await _rouletteService.GetById(idRoulette);
                return Ok(data.AsResponse((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Roulette/GetById/{idRoulette} - " + ex.Message);
                return BadRequest(ResponseExtension.AsResponse<string>(null, (int)HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpGet("GetAll")]
        async public Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _rouletteService.GetAllRoulettes();
                return Ok(data.AsResponse((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Roulette/GetAll - " + ex.Message);
                return BadRequest(ResponseExtension.AsResponse<string>(null, (int)HttpStatusCode.InternalServerError, ex.Message));
            }
        }


    }
}
