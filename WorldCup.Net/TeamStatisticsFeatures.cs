using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    partial class TeamStatistics
    {
        public override string ToString()
        {
            return $"C: {Country} Passes: {NumPasses} Fouls_Commited: {FoulsCommitted} ";
        }
    }
}
