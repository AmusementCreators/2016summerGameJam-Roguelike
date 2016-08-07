using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Wait : Turn
    {
        public Wait(Character.CharactorSet set) :
            base(set)
        { }

        public override Turn update()
        {
            charactorSet.camera.Src = new asd.RectI(
    ((charactorSet.player.Position - asd.Engine.WindowSize.To2DF() / 2) * 0.1f + charactorSet.camera.Src.Position.To2DF() * 0.9f).To2DI(),
    (charactorSet.camera.Src.Size.To2DF() * 0.9f + asd.Engine.WindowSize.To2DF() * 0.1f).To2DI());
            charactorSet.camera.Dst = new asd.RectI(0, 0, 640, 480);
            return this;
        }
    }
}
