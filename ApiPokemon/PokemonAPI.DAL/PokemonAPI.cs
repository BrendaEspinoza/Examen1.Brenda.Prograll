using Newtonsoft.Json;
using PokemonAPI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonAPI.DAL
{
    public class PokeAPIClient
    {
        private readonly HttpClient _httpClient;

        public PokeAPIClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<PokemonResponse> GetPokemonDataAsync(string pokemonName)
        {
            string endpoint = $"pokemon/{pokemonName.ToLower()}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string pokemonData = await response.Content.ReadAsStringAsync();
                return PokemonResponse.FromJson(pokemonData);
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve data: {response.StatusCode}");
            }
        }
    }
}