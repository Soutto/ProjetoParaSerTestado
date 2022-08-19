using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoParaSerTestado.Models
{
    public class Game
    {
        [JsonProperty("full_name")]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("home_team_score")]
        public int HomeTeamScore { get; set; }

        public int Period { get; set; }

        public bool Postseason { get; set; }

        public int Season { get; set; }

        public string Status { get; set; }

        [JsonProperty("visitor_team")]
        public Team VisitorTeam { get; set; }

        [JsonProperty("visitor_team_score")]
        public int VisitorTeamScore { get; set; }
    }
}
