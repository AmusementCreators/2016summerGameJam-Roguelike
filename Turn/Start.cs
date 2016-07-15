using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Start : Turn
    {
        public Start()
        {
            var label = new asd.TextObject2D();
            label.Font = Resource.Font;
            label.Text = "はじめのターンです\nZキーで主人公のターンになります";
            label.Position = asd.Engine.WindowSize.To2DF() / 2;
            label.CenterPosition = Resource.Font.CalcTextureSize(label.Text, asd.WritingDirection.Horizontal).To2DF() / 2;

            AddObject(label);
        }
        public override Turn Next()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                return new Player();
            else
                return this;
        }
    }
}
