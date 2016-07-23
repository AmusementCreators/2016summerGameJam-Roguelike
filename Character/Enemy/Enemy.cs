﻿/*============================================================================
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

namespace _2WeeksGameJam_Roguelike.Character.Enemy
{
    abstract class Enemy : Charactor
    {
        public Enemy(CharactorSet set, asd.Vector2DF pos) :
            base(set, pos)
        {
        }

        protected override List<Charactor> AgainstCharactors()
        {
            List<Charactor> result = new List<Charactor>();
            result.Add(charactorSet.player);
            return result;
        }
    }
}
