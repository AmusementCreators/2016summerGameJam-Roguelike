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
    class Clear : asd.Scene
    {
        public Clear()
        {
            var layer = new asd.Layer2D();

            var background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D("Resource/title.png");
            background.Scale = new asd.Vector2DF(4, 4);
            layer.AddObject(background);

            var gameclearLabel = new asd.TextObject2D();
            gameclearLabel.Font = Resource.BigFont;
            gameclearLabel.Text = "Game Clear!!";
            gameclearLabel.Position = asd.Engine.WindowSize.To2DF() / 2;
            gameclearLabel.CenterPosition = Resource.BigFont.CalcTextureSize(gameclearLabel.Text, asd.WritingDirection.Horizontal).To2DF() / 2;

            layer.AddObject(gameclearLabel);

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
