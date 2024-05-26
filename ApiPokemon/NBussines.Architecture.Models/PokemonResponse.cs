using Newtonsoft.Json.Linq;


namespace PokemonAPI.Models
{
    public class PokemonResponse
    {
        public string Name { get; set; }
        public List<Move> Moves { get; set; }
        public List<Type> Types { get; set; }


        public void FromJson(string json)
        {
            var pokemonObject = JObject.Parse(json);

            Name = pokemonObject["name"].ToString();

            Moves = new List<Move>();
            foreach (var move in pokemonObject["moves"])
            {
                Moves.Add(new Move { Name = move["move"]["name"].ToString() });
            }

            Types = new List<Type>();
            foreach (var type in pokemonObject["types"])
            {
                Types.Add(new Type { Name = type["type"]["name"].ToString() });
            }
        }
    }
}