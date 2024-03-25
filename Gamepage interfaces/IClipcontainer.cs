using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public interface IClipcontainer
    {
        public bool AddClip(ClipDTO cDto);

        public List<ClipDTO> getBygameID(int gameid);
    }
}
