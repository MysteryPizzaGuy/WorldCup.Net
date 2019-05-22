using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WorldCup.Net
{
    class JSONTeamRepo : ITeamRepo
    {
        public string Target { get; set; }
        RestSharp.RestClient client;
        public async Task<IList<Team>> FetchTeamsAsync()
        {

            if (Target != String.Empty)
            {
                client = new RestClient(Target);
            }
            else
            {
                throw new Exception("Target not determined!");
            }
            var response =await client.ExecuteTaskAsync<List<Team>>(new RestRequest());

            return response.Data;
            
        }
    }
}
