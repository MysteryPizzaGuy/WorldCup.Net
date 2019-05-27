using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    public partial class TeamEvent
    {
        public override string ToString()
        {
            return $"ID: {Id} Type: {TypeOfEvent} Player: {Player} Time: {Time}";
        }
    }

}
