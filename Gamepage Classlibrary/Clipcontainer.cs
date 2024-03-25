using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamepage_DAL;
using Gamepage_interfaces;

namespace Gamepage_Classlibrary
{
    public class Clipcontainer
    {
        private IClipcontainer icontainer;

        public Clipcontainer(IClipcontainer icontainer)
        {
            this.icontainer = icontainer;
        }

        public bool AddClip(Clip c)
        {
            if (icontainer.AddClip(c.toDTO()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Clip> GetClipList(int gameid) 
        {
            List<Clip> list = new List<Clip>();

            foreach (ClipDTO clip in icontainer.getBygameID(gameid))
            {
                list.Add(new Clip(clip));
            }

            return list;
        }
    }
}
