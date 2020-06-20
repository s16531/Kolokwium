using System;
using System.Collections.Generic;
using Kolokwium.Requests;

namespace Kolokwium.Services
{
    public interface IChampionshipDbService
    {
        public Dictionary<int, float> GetTeamsSorted(int id);

        public void AddPlayer(AddPlayerRequest addPlayerRequest, int teamId);
    }
}
