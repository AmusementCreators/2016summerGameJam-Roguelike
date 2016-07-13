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
        static public asd.Font Font;
        static public asd.Texture2D Image;
        static public void Init()
        {
            Font = asd.Engine.Graphics.CreateDynamicFont(string.Empty, 32, new asd.Color(255, 255, 255, 255), 0, new asd.Color(255, 255, 255, 255));
            Image = asd.Engine.Graphics.CreateTexture2D("Resource/image.png");
        }
    }
}
