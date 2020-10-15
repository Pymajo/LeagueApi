using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueApi.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Gold { get; set; }
        public string ItemId { get; set; }
        public string Plaintext { get; set; }
        public int Id { get; set; }
    }

}
