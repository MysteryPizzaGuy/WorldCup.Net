using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    public interface ITeamRepo
    {
        string TeamFifaDataTarget { get; set; }
        string TeamMatchesDataURL { get; set; }
        Task<IList<TeamFifaData>> FetchTeamsAsync();
        Task<IList<TeamMatchesData>> FetchTeamMatchesDataAsyc(string FifaCode);
        Dictionary<string, IList<TeamMatchesData>> TeamMatchesData { get; set; }
    }
}
