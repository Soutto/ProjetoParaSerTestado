using ProjetoParaSerTestado.Models;
using System.Collections.Generic;
using System.Linq;
using ProjetoParaSerTestado.Interfaces;
using System;

namespace ProjetoParaSerTestado
{
    public class InterestingInformations : IInterestingInformations
    {
        public decimal GetPercentageGamesWithMoreThan120Points(List<Game> games)
        {
            if (games.Any())
            {
                decimal totalGames = games.Count();
                decimal gamesWithMoreThan120Points = games.Where(g => g.HomeTeamScore > 120 || g.VisitorTeamScore > 120).Count();

                return gamesWithMoreThan120Points / totalGames * 100;
            }
            throw new ArgumentNullException();
        }

        public decimal GetPercentageHomeTeamWins(List<Game> games)
        {
            if (games.Any())
            {
                decimal totalGames = games.Count();
                decimal gamesHomeTeamWins = games.Where(g => g.HomeTeamScore > g.VisitorTeamScore).Count();

                return gamesHomeTeamWins / totalGames * 100;
            }
            throw new ArgumentNullException();
        }

        public List<Game> GetGamesHomeTeamWins(List<Game> games)
        {
            if (games.Any())
            {
                return games.Where(g => g.HomeTeamScore > g.VisitorTeamScore).ToList();
            }

            throw new ArgumentNullException();
        }

        public Dictionary<string, string> GenerateClashesRandomly(List<Team> teams)
        {
            if (teams.Count() != 30)
            {
                throw new Exception();
            }

            Dictionary<string, string> clashes = GenerateClashes(teams);
            return clashes;
        }

        private Dictionary<string, string> GenerateClashes(List<Team> teams)
        {
            Random random = new Random();
            Dictionary<string, string> clashes = new Dictionary<string, string>();

            for (int i = 0; i < 15; i++)
            {
                var homeTeam = teams[random.Next(teams.Count)];
                teams.Remove(homeTeam);

                var visitorTeam = teams[random.Next(teams.Count)];
                teams.Remove(visitorTeam);

                clashes.Add(homeTeam.FullName, visitorTeam.FullName);
            }

            return clashes;
        }
    }

}
