using Microsoft.AspNetCore.Mvc;
using PokemonAPI.DAL;
using PokemonAPI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokeAPIClient _pokeAPIClient;

        public PokemonController(PokeAPIClient pokeAPIClient)
        {
            _pokeAPIClient = pokeAPIClient;
        }

        [HttpGet("{pokemonName}")]
        public async Task<ActionResult> GetPokemon(string pokemonName)
        {
            try
            {
                string pokemonData = await _pokeAPIClient.GetPokemonDataAsync(pokemonName);
                var pokemonResponse = PokemonResponse.FromJson(pokemonData);

                return Ok(pokemonResponse);
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