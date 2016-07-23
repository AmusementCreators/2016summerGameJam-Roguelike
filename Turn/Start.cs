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

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Start : Turn
    {
        public Start(Character.CharactorSet set) :
            base(set)
        {
        }
        public override Turn update()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                return new Player(charactorSet);
            else
                return this;
        }
    }
}
