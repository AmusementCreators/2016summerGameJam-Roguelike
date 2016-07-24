using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character.Item
{
    class View : Item
    {
        public View(asd.Vector2DF pos) :
            base(pos)
        {
            Src = new asd.RectF(2*Consts.Chip.Width, 2 * Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        public override string Name()
        {
            return "View Pod";
        }
    }
}
