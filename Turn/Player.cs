using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Player : Turn
    {
        public Player(Character.CharactorSet set) :
            base(set)
        {
        }

        public override Turn update()
        {
            this.charactorSet.camera.Src = new asd.RectI(this.charactorSet.player.Position.To2DI() - asd.Engine.WindowSize / 2, asd.Engine.WindowSize);
            this.charactorSet.camera.Dst = new asd.RectI(0, 0, 640, 480);

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                return new Enemy(this.charactorSet);
            else
                return this;
        }
    }
}
