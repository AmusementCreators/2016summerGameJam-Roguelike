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

namespace _2WeeksGameJam_Roguelike
{
    static class Resource
    {
        static public String GameTitle = "冒険";
        static public asd.Font BigFont;
        static public asd.Font Font;
        static public asd.Font SmallFont;
        static public asd.Texture2D Image;
        static public asd.SoundSource TitleSong;
        static public asd.SoundSource GameSong;
        static public System.Random Rand = new Random();
        static public void Init()
        {
            BigFont = asd.Engine.Graphics.CreateDynamicFont("Resource/PixelMplus10-Regular.ttf", 32, new asd.Color(0, 0, 0, 255), 0, new asd.Color(0, 0, 0, 255));
            Font = asd.Engine.Graphics.CreateDynamicFont("Resource/PixelMplus10-Regular.ttf", 16, new asd.Color(255, 255, 255, 255), 0, new asd.Color(255, 255, 255, 255));
            SmallFont = asd.Engine.Graphics.CreateDynamicFont("Resource/PixelMplus10-Regular.ttf", 10, new asd.Color(255, 255, 255, 255), 0, new asd.Color(255, 255, 255, 255));
            Image = asd.Engine.Graphics.CreateTexture2D("Resource/image.png");

            TitleSong = asd.Engine.Sound.CreateSoundSource("Resource/title.ogg", true);
            TitleSong.IsLoopingMode = true;

            GameSong = asd.Engine.Sound.CreateSoundSource("Resource/game.ogg", true);
            GameSong.IsLoopingMode = true;
        }
    }
}
