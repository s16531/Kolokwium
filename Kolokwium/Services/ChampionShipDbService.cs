using System;
using System.Collections.Generic;
using System.Linq;
using Kolokwium.Models;
using Kolokwium.RequestExeptions;
using Kolokwium.Requests;

namespace Kolokwium.Services
{
    public class ChampionShipDbService : IChampionshipDbService
    {
        private readonly CDbContext _context;
        public ChampionShipDbService()
        {
        }

     

        public Dictionary<int, float> GetTeamsSorted(int id)
        {
            var sortedTeams = _context.ChampionshipTeams
                                .Where(championshipteams => championshipteams.IdTeam == id).ToList();

            if (sortedTeams == null)
            {
                throw new NoTeamsFoundException($"There is no Teams with id: {id} in database");
            }

            var response = new Dictionary<int, float>();

            foreach (var team in sortedTeams)
            {
                response.Add(team.IdTeam, team.Score);
            }

            return response;
        }

        public void AddPlayer(AddPlayerRequest addPlayerRequest, int teamId)
        {
            var playerToAdd = _context.Players.First(p => p.FirstName == addPlayerRequest.FirstName && p.LastName == addPlayerRequest.LastName);
            if (playerToAdd == null)
            {
                throw new PlayerNotFoundException($"Not founded player with this data");
            }
            var team = _context.Teams.First(team => team.IdTeam == teamId);
            if (team == null)
            {
                throw new NoTeamsFoundException($"Team not founded with id: {teamId}");
            }
            if ((DateTime.Today.Year - playerToAdd.DateOfBirth.Year) > team.MaxAge)
            {
                throw new Exception("Players have to be younger for this team");
            }
            var validatedPlayer = new PlayerTeam
            {
                IdPlayer = playerToAdd.IdPlayer,
                IdTeam = team.IdTeam,
                NumOnShirt = addPlayerRequest.NumOnShirt,
                Comment = addPlayerRequest.Comment
            };
            _context.PlayerTeams.Add(validatedPlayer);
            _context.SaveChanges();
        }
    }
}
