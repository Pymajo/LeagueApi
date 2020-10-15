using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueApi.Models
{
    public class Champion
    {
       public string Title { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ChampionId { get; set; }
        public int Id { get; set; }

    }
}
