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
    class Golem : Enemy
    {
        public Golem(CharactorSet set, asd.Vector2DF pos) :
            base(set, pos)
        {
            Src = new asd.RectF(Consts.Chip.Width * 2, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        public override int MaxActionPoint { get { return 10; } }
        public override int MaxHitPoint { get { return 1; } }

        public override string Name()
        {
            return "ゴーレム";
        }

        protected override asd.Vector2DF Move()
        {
            var diff = charactorSet.player.Position - Position;
            if (diff.Length > 100) // プレイヤーから遠ければランダムウォーク
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
            else // プレイヤーと近ければ近付いてくる
            {
                var result = new asd.Vector2DF();
                var angle = (diff.Degree + 360)%360 - 45;
                if (angle < 90)
                    result.Y = Consts.Chip.Height;
                else if (angle < 180)
                    result.X = -Consts.Chip.Width;
                else if (angle < 270)
                    result.Y = -Consts.Chip.Height;
                else
                    result.X = Consts.Chip.Width;

                return result;
            }

        }
    }
}
