using Newtonsoft.Json;

namespace ProjetoParaSerTestado.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Abbreviation { get; set; }

        public string City { get; set; }

        public string Conference { get; set; }

        public string Division { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        public string Name { get; set; }
    }
}
