using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public class PokemonResponse
    {
        public string Name { get; set; }
        public List<Move> Moves { get; set; }
        public List<Type> Types { get; set; }


        public static PokemonResponse FromJson(string json)
        { 
            var pokemonObject = JObject.Parse(json);

            // Extracting the name
            string name = pokemonObject["name"].ToString();

            // Extracting moves
            var moves = new List<Move>();
            foreach (var move in pokemonObject["moves"])
            {
                moves.Add(new Move { Name = move["move"]["name"].ToString() });
            }

            // Extracting types
            var types = new List<Type>();
            foreach (var type in pokemonObject["types"])
            {
                types.Add(new Type { Name = type["type"]["name"].ToString() });
            }

            return new PokemonResponse
            {
                Name = name,
                Moves = moves,
                Types = types
            };
        }
    }
}