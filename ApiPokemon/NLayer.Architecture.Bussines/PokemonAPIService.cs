
using PokemonAPI.Models;


namespace NLayer.Architecture.Bussines.Services
{
    public class PokemonApiService : IPokemonApiService
    {
        private readonly HttpClient _httpClient;

        public PokemonApiService()
        {
            _httpClient = new HttpClient();

        }

        public async Task<PokemonResponse> GetPokemonData(string pokemonName)
        {


            HttpResponseMessage response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}");

            if (response.IsSuccessStatusCode)
            {
                string pokemonData = await response.Content.ReadAsStringAsync();
                var pokemonResponse = new PokemonResponse();
                pokemonResponse.FromJson(pokemonData);

                return pokemonResponse;
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve data: {response.StatusCode}");
            }
        }
    }
}