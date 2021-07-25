using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApi.Models
{
    public class DirectoryAPL
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<DirectoryAplCommandPlayer> DirectoryAplCommandPlayers { get; set; }
    }

    public class DirectoryAplCommandPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectoryAplId { get; set; }
        public DirectoryAPL DirectoryAPL { get; set; }
    }
}
