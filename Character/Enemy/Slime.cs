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

namespace _2WeeksGameJam_Roguelike.Character.Enemy
{
    class Slime : Enemy
    {
        public Slime(CharactorSet set, asd.Vector2DF pos) :
            base(set, pos)
        {
            Src = new asd.RectF(Consts.Chip.Width, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        public override int MaxActionPoint()
        {
            return 10;
        }
        public override int MaxHitPoint()
        {
            return 1;
        }

        public override string Name()
        {
            return "スライム";
        }

        protected override asd.Vector2DF Move()
        {
            switch (Resource.Rand.Next(0, 3))
            {
                case 0:
                    return new asd.Vector2DF(-Consts.Chip.Width, 0);
                case 1:
                    return new asd.Vector2DF(Consts.Chip.Width, 0);
                case 2:
                    return new asd.Vector2DF(0, -Consts.Chip.Height);
                case 3:
                    return new asd.Vector2DF(0, Consts.Chip.Height);
                default:
                    return new asd.Vector2DF();
            }
        }
    }
}
