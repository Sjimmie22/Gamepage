﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamepage_interfaces
{
    public struct CommentDTO
    {
        public int CommentID { get; set; }

        public int ClipID { get; set; }

        public int UserID { get; set; }

        public string CommentText { get; set; }

        public string Maker { get; set; }
    }
}
