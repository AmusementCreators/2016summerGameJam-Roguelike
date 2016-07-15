using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character.Enemy
{
    class Slime : asd.TextureObject2D
    {
        public Slime()
        {
            this.Texture = Resource.Image;
            this.Src = new asd.RectF(Consts.Chip.Width, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        protected override void OnUpdate()
        {
        }
    }
}
