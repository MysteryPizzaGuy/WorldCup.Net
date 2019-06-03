using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WorldCup.Net
{
    class JSONTeamRepo : ITeamRepo
    {
        RestSharp.RestClient client;
        List<TeamFifaData> TeamList = null;
        public Dictionary<string, IList<TeamMatchesData>> TeamMatchesData { get; set; } = null;

        public string TeamFifaDataTarget { get; set; } = "http://worldcup.sfg.io/teams/results";
        public string TeamMatchesDataURL { get; set; } = "http://worldcup.sfg.io/matches/country?fifa_code=";

        public async Task<IList<TeamFifaData>> FetchTeamsAsync()
        {

            if (TeamList ==null)
            {
                if (TeamFifaDataTarget != String.Empty)
                {
                    client = new RestClient(TeamFifaDataTarget);
                }
                else
                {
                    throw new Exception("Target not determined!");
                }
                var request = new RestRequest();
                var response = await client.ExecuteTaskAsync<List<TeamFifaData>>(request);
                this.TeamList = response.Data;
            }
            return this.TeamList;
        }
        public async Task<IList<TeamMatchesData>> FetchTeamMatchesDataAsyc(string FifaCode)
        {
            if (TeamMatchesData == null)
            {
                TeamMatchesData = new Dictionary<string, IList<Net.TeamMatchesData>>();
            }
            if (!TeamMatchesData.ContainsKey(FifaCode))
            {
                if (TeamMatchesDataURL != String.Empty)
                {
                    var AimedTarget = TeamMatchesDataURL + FifaCode;
                    client = new RestClient(AimedTarget);
                }
                else
                {
                    throw new Exception("Target not determined!");
                }
                var request = new RestRequest();
                var response = await client.ExecuteTaskAsync(request);
                IList<TeamMatchesData> deser = await Task.Run(() => Newtonsoft.Json.JsonConvert.DeserializeObject<IList<TeamMatchesData>>(response.Content));
                TeamMatchesData[FifaCode] = deser;
                var firstmatch = TeamMatchesData[FifaCode].First();
                TeamStatistics teamstatistics;
                if (firstmatch.HomeTeam.Code == FifaCode)
                {
                    teamstatistics = firstmatch.HomeTeamStatistics;
                }
                else
                {
                    teamstatistics = firstmatch.AwayTeamStatistics;
                }
                var allplayers =teamstatistics.StartingEleven.Union(teamstatistics.Substitutes);
                allplayers.ToList().ForEach((x)=>LoadSavedFavPlayers(x,FifaCode));
            }

            return TeamMatchesData[FifaCode];
        }

        void LoadSavedFavPlayers(TeamMatchesDataPlayer player,string FifaCode)
        {
            if (Configuration.FavoritePlayers.ContainsKey(FifaCode))
            {
                if (Configuration.FavoritePlayers[FifaCode].Contains(player.Name))
                {
                    player.isFavorite = true;
                }
            }

        }

      
    }
}
