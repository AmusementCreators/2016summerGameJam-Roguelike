using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Start : Turn
    {
        public Start(Character.CharactorSet set) :
            base(set)
        {
        }
        public override Turn update()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                return new Player(this.charactorSet);
            else
                return this;
        }
    }
}
