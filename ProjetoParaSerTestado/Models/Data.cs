using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjetoParaSerTestado.Models
{
    public class DataPlayer
    {
        [JsonProperty("data")]
        public List<Player> Players;
    }
    public class DataGame
    {
        [JsonProperty("data")]
        public List<Game> Games;
    }
    public class DataTeam
    {
        [JsonProperty("data")]
        public List<Team> Teams;
    }
}
