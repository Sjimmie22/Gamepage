using Gamepage_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_Unittests
{
    public class ClipDAL : IClipcontainer
    {
        public List<ClipDTO> ClipsDTOlist = new List<ClipDTO>();

        public ClipDTO testaddclip = new ClipDTO();
        public int testgameid = 0;

        public bool AddClip(ClipDTO cDto) //kijkt of de string niet leeg is en als dat zo is dan voegt die em toe aan de lijst
        {
            
            testaddclip = cDto;

            if (cDto.Title == null || cDto.Title == string.Empty)
            {
                return false;
            }
            else
            {
                cDto.ClipID = ClipsDTOlist.Count;
                ClipsDTOlist.Add(cDto);
            }

            return true;
        }

        public List<ClipDTO> getBygameID(int gameid)
        {
            testgameid= gameid;

            return ClipsDTOlist.FindAll(dto => dto.GameID == gameid);
        }

    }
}
