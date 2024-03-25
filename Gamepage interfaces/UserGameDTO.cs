using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public struct UserGameDTO
    {
        public int GameID { get; set; }
        
        public int UserID { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }

        public int Level { get; set; }

        public string Particularities { get; set; }
    }
}
