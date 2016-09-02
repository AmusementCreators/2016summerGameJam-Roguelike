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
            layer.AddObject(titleLabel);

            var gameStartLabel = new asd.TextObject2D();
            gameStartLabel.Font = Resource.Font;
            gameStartLabel.Color = new asd.Color(0, 0, 0);
            gameStartLabel.Text = "Game Start";
            gameStartLabel.Position = asd.Engine.WindowSize.To2DF() / 2;
            layer.AddObject(gameStartLabel);

            var tutorialLabel = new asd.TextObject2D();
            tutorialLabel.Font = Resource.Font;
            tutorialLabel.Color = new asd.Color(0, 0, 0);
            tutorialLabel.Text = "Tutorial";
            tutorialLabel.Position = asd.Engine.WindowSize.To2DF() / 2 + new asd.Vector2DF(0, 32);
            layer.AddObject(tutorialLabel);

            var quitLabel = new asd.TextObject2D();
            quitLabel.Font = Resource.Font;
            quitLabel.Color = new asd.Color(0, 0, 0);
            quitLabel.Text = "Quit";
            quitLabel.Position = asd.Engine.WindowSize.To2DF() / 2 + new asd.Vector2DF(0, 64);
            layer.AddObject(quitLabel);

            cursorLabel.Font = Resource.Font;
            cursorLabel.Text = ">";
            cursorLabel.Position = gameStartLabel.Position - new asd.Vector2DF(32, 0);
            layer.AddObject(cursorLabel);

            AddLayer(layer);

            titleSoundId = asd.Engine.Sound.Play(Resource.TitleSong);
        }

        protected override void OnUpdated()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push)
            {
                switch(cursor)
                {
                    case Cursor.GameStart:
                        break;
                    case Cursor.Tutorial:
                        cursor = Cursor.GameStart;
                        break;
                    case Cursor.Quit:
                        cursor = Cursor.Tutorial;
                        break;
                }
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
            {
                switch (cursor)
                {
                    case Cursor.GameStart:
                        cursor = Cursor.Tutorial;
                        break;
                    case Cursor.Tutorial:
                        cursor = Cursor.Quit;
                        break;
                    case Cursor.Quit:
                        break;
                }
            }

            switch (cursor)
            {
                case Cursor.GameStart:
                    cursorLabel.Position = asd.Engine.WindowSize.To2DF() / 2 + new asd.Vector2DF(-32, 0);
                    break;
                case Cursor.Tutorial:
                    cursorLabel.Position = asd.Engine.WindowSize.To2DF() / 2 + new asd.Vector2DF(-32, 32);
                    break;
                case Cursor.Quit:
                    cursorLabel.Position = asd.Engine.WindowSize.To2DF() / 2 + new asd.Vector2DF(-32, 64);
                    break;
            }

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                switch (cursor)
                {
                    case Cursor.GameStart:
                        asd.Engine.ChangeScene(new Scene.Game());
                        break;
                    case Cursor.Tutorial:
                        asd.Engine.ChangeScene(new Scene.Tutorial());
                        break;
                    case Cursor.Quit:
                        Resource.IsQuit = true;
                        break;
                }
            }
        }

        protected override void OnDispose()
        {
            asd.Engine.Sound.Stop(titleSoundId);
        }

        int titleSoundId;

        enum Cursor
        {
            GameStart,
            Tutorial,
            Quit
        }
        Cursor cursor = Cursor.GameStart;
        asd.TextObject2D cursorLabel = new asd.TextObject2D();
    }
}
