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

        public string TeamFifaDataTarget { get; set; } = "http://worldcup.sfg.io/teams/results";
        public string TeamMatchesDataURL { get; set; } = "http://worldcup.sfg.io/matches/country?fifa_code=";

        public async Task<IList<TeamFifaData>> FetchTeamsAsync()
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
            var response =await client.ExecuteTaskAsync<List<TeamFifaData>>(request);

            return response.Data;
            
        }
        public async Task<IList<TeamMatchesData>> FetchTeamMatchesDataAsyc(string FifaCode)
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
            IList<TeamMatchesData> deser = await  Task.Run(() =>Newtonsoft.Json.JsonConvert.DeserializeObject<IList<TeamMatchesData>>(response.Content));
            return deser;
        }

      
    }
}
