using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame
{
    class PictureModel
    {
        public int Id { get; set; }
        public string ImageSource { get; set; }
        public bool IsMatched { get; set; }
        public bool IsOpen { get; set; }


       
    }
}
