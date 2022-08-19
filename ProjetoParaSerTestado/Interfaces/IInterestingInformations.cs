using ProjetoParaSerTestado.Models;
using System.Collections.Generic;

namespace ProjetoParaSerTestado.Interfaces
{
    public interface IInterestingInformations
    {
        decimal GetPercentageGamesWithMoreThan120Points(List<Game> games);

        decimal GetPercentageHomeTeamWins(List<Game> games);

        List<Game> GetGamesHomeTeamWins(List<Game> games);

        Dictionary<string, string> GenerateClashesRandomly(List<Team> teams);
    }
}
