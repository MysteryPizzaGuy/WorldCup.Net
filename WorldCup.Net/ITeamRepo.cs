using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    public interface ITeamRepo
    {
        string Target { get; set; }
        Task<IList<Team>> FetchTeamsAsync();
        
    }
}
