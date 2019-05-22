using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    public static class RepoFactory
    {
        public static ITeamRepo GenerateRepo()
        {
            return new JSONTeamRepo();
        }
    }
}
