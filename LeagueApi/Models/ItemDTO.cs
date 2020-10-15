using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueApi.Models
{
    public class ItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public Gold Gold { get; set; }
        public string ItemId { get; set; }
        public int Id { get; set; }
        public string Plaintext { get; set; }
    }
    public class Gold
    {
        public int Total { get; set; }
    }
    public class Image
    {
        public string Full { get; set; }
    }

}
