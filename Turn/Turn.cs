using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Turn
{
    abstract class Turn : asd.Layer2D
    {
        public abstract Turn Next();
    }
}
