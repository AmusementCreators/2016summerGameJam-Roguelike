using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Turn
{
    abstract class Turn
    {
        public Turn(Character.CharactorSet set)
        {
            charactorSet = set;
        }
        abstract public Turn update();

        protected Character.CharactorSet charactorSet;

    }
}
