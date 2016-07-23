using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character.Item
{
    class Power : Item
    {
        public Power(asd.Vector2DF pos) :
            base(pos)
        {
            Src = new asd.RectF(Consts.Chip.Width, 2*Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        public override string Name()
        {
            return "Power Pod";
        }
    }
}
