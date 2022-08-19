using Newtonsoft.Json;
using ProjetoParaSerTestado.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoParaSerTestado
{
    public static class FreeNbaApiClient
    {
        //513 centenas para vir todos os jogos
        public static List<Game> GetAllGames(int centenas)
        {
            List<Game> games = new List<Game>();

            for (int i = 1; i <= centenas; i++)
            {
                string jsonResult = DoRequest($"https://free-nba.p.rapidapi.com/games?page={i}&per_page=100");
                games.AddRange(JsonConvert.DeserializeObject<DataGame>(jsonResult).Games);
            }
            return games;
        }

        //38 centenas para vir todos os jogadores
        public static List<Player> GetAllPlayers(int centenas)
        {
            List<Player> players = new List<Player>();

            for (int i = 1; i <= 38; i++)
            {
                string jsonResult = DoRequest($"https://free-nba.p.rapidapi.com/players?page={i}&per_page=100");
                players.AddRange(JsonConvert.DeserializeObject<DataPlayer>(jsonResult).Players);
            }

            return players;
        }

        public static List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();

            for (int i = 1; i <= 1; i++)
            {
                string jsonResult = DoRequest($"https://free-nba.p.rapidapi.com/teams?page={i}&per_page=100");
                teams.AddRange(JsonConvert.DeserializeObject<DataTeam>(jsonResult).Teams);
            }

            return teams;
        }

        private static string DoRequest(string uri)
        {
            var client = new RestClient(uri);

            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "131468409amshaddbc53c0e4aee9p146158jsnb12bf1d1defe");
            request.AddHeader("X-RapidAPI-Host", "free-nba.p.rapidapi.com");

            RestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
