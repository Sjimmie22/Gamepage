using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public struct ClipDTO
    {
        public string Title { get; set; }
        public int ClipID { get; set; }
        public int GameID { get; set; }
        public int UserID { get; set; }
        public string Maker { get; set; }
        public string Cliptext { get; set; }

        //public List<string> Comments { get; set; } later use
    }
}
