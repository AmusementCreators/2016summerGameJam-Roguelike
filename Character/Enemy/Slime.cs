using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character.Enemy
{
    class Slime : Enemy
    {
        public Slime(asd.Vector2DF pos)
        {
            this.Texture = Resource.Image;
            this.Src = new asd.RectF(Consts.Chip.Width, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
            this.Position = pos;
        }

        protected override void OnUpdate()
        {
        }
    }
}
