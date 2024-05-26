using PokemonAPI.Models;

namespace NLayer.Architecture.Bussines.Services;


public interface IPokemonApiService
{
     Task<PokemonResponse> GetPokemonData(string pokemonName);
}