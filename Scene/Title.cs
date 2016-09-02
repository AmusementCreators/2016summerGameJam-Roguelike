/*============================================================================
  Copyright (C) 2016 akitsu-sanae, ding, lenny-yusei.
  https://github.com/AmusementCreators/2016summerGameJam-Roguelike
  Distributed under the Boost Software License, Version 1.0. (See accompanying
  file LICENSE or copy at http://www.boost.org/LICENSE_1_0.txt)
============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Scene
{
    class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();
            var background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D("Resource/title.png");
            background.Scale = new asd.Vector2DF(4.0f, 4.0f);
            layer.AddObject(background);

            var titleLabel = new asd.TextObject2D();
            titleLabel.Font = Resource.BigFont;
            titleLabel.Text = Resource.GameTitle;
            titleLabel.Position = asd.Engine.WindowSize.To2DF() / 2 - new asd.Vector2DF(0, 64);
            titleLabel.CenterPosition = Resource.BigFont.CalcTextureSize(titleLabel.Text, asd.WritingDirection.Horizontal).To2DF() / 2;

            var label = new asd.TextObject2D();
            label.Font = Resource.Font;
            label.Color = new asd.Color(0, 0, 0);
            label.Text = "ゲームを始めるにはZキーを押してね\nチュートリアルはXキーです";
            label.Position = asd.Engine.WindowSize.To2DF() / 2 + new asd.Vector2DF(0, 64);
            label.CenterPosition = Resource.Font.CalcTextureSize(label.Text, asd.WritingDirection.Horizontal).To2DF() / 2;

            layer.AddObject(titleLabel);
            layer.AddObject(label);
            AddLayer(layer);

            titleSoundId = asd.Engine.Sound.Play(Resource.TitleSong);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                asd.Engine.ChangeScene(new Scene.Game());
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.X) == asd.KeyState.Push)
                asd.Engine.ChangeScene(new Scene.Tutorial());
        }

        protected override void OnDispose()
        {
            asd.Engine.Sound.Stop(titleSoundId);
        }

        int titleSoundId;
    }
}
