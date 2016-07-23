using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character.Item
{
    abstract class Item : asd.TextureObject2D
    {
        public Item(asd.Vector2DF pos)
        {
            Texture = Resource.Image;
            Position = pos;
        }

        public abstract String Name();
    }
}
