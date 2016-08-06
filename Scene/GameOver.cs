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

            var gameoverLabel = new asd.TextObject2D();
            gameoverLabel.Font = Resource.BigFont;
            gameoverLabel.Text = "Game Over...";
            gameoverLabel.Position = asd.Engine.WindowSize.To2DF() / 2;
            gameoverLabel.CenterPosition = Resource.BigFont.CalcTextureSize(gameoverLabel.Text, asd.WritingDirection.Horizontal).To2DF() / 2;
            
            layer.AddObject(gameoverLabel);

            var returnLabel = new asd.TextObject2D();
            returnLabel.Font = Resource.Font;
            returnLabel.Text = "Push Z Key To Title Scene";
            returnLabel.Position = asd.Engine.WindowSize.To2DF() / 2 + new asd.Vector2DF(0, 64);
            returnLabel.CenterPosition = Resource.Font.CalcTextureSize(returnLabel.Text, asd.WritingDirection.Horizontal).To2DF() / 2;

            layer.AddObject(returnLabel);

            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                asd.Engine.ChangeScene(new Title());
        }
    }
}
