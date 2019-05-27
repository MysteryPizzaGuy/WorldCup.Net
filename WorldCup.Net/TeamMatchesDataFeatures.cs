using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    partial class TeamMatchesData
    {
        public override string ToString()
        {
            return $"{AwayTeamCountry} {LastEventUpdateAt}";
        }
    }
}
