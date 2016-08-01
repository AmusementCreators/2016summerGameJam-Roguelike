using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Scene
{
    class GameOver : asd.Scene
    {
        public GameOver()
        {
            var layer = new asd.Layer2D();

            var background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D("Resource/title.png");
            background.Scale = new asd.Vector2DF(4, 4);
            layer.AddObject(background);

            var label = new asd.TextObject2D();
            label.Font = Resource.BigFont;
            label.Text = "Game Over...\nPush Z Key To Title Scene";
            label.Position = asd.Engine.WindowSize.To2DF() / 2;
            label.CenterPosition = Resource.BigFont.CalcTextureSize(label.Text, asd.WritingDirection.Horizontal).To2DF() / 2;

            layer.AddObject(label);
            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                asd.Engine.ChangeScene(new Title());
        }
    }
}
