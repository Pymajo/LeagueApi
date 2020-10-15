using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueApi.Models
{
    public class Build
    {
        public int Id { get; set; }
        public int ChampionId { get; set;}
        public string BuildName { get; set; }

    }
}
