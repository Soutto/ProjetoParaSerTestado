using Newtonsoft.Json;

namespace ProjetoParaSerTestado.Models
{
    public class Player
    {
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("height_feet")]
        public double? HeightFeet { get; set; }

        [JsonProperty("height_inches")]
        public double? HeightInches { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Position { get; set; }

        public Team Team { get; set; }

        [JsonProperty("weight_pounds")] 
        public double? WeightPounds { get; set; }
    }
}
