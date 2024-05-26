using Microsoft.AspNetCore.Mvc;
using NLayer.Architecture.Bussines.Services;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonApiService _pokemonApiService;

        public PokemonController(IPokemonApiService pokemonApiService)
        {
            _pokemonApiService = pokemonApiService;
        }

        [HttpGet("{pokemonName}")]
        public async Task<ActionResult> GetPokemon(string pokemonName)
        {
            try
            {
                PokemonResponse pokemonData = await _pokemonApiService.GetPokemonData(pokemonName);
                return Ok(pokemonData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}