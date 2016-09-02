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
using asd;

namespace _2WeeksGameJam_Roguelike.Character.Enemy
{
    class Satan : Enemy
    {
        public Satan(CharactorSet set, asd.Vector2DF pos) :
            base(set, pos)
        {
            Src = new asd.RectF(Consts.Chip.Width*5, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }
        public override int MaxActionPoint { get { return 50; } }
        public override int MaxHitPoint { get { return 50; } }

        public override string Name()
        {
            return "魔王";
        }

        protected override Vector2DF Move()
        {
            Func<asd.Vector2DF> random_walk = () =>
            {
                switch (Resource.Rand.Next(0, 4))
                {
                    case 0:
                        return new asd.Vector2DF(-Consts.Chip.ScreenWidth, 0);
                    case 1:
                        return new asd.Vector2DF(Consts.Chip.ScreenWidth, 0);
                    case 2:
                        return new asd.Vector2DF(0, -Consts.Chip.ScreenHeight);
                    case 3:
                        return new asd.Vector2DF(0, Consts.Chip.ScreenHeight);
                    default:
                        return new asd.Vector2DF();
                }
            };
            var diff = charactorSet.player.Position - Position;
            if (diff.Length > 200) // プレイヤーから遠ければランダムウォーク
            {
                return random_walk();
            }
            else // プレイヤーと近ければ近付いてくる
            {
                var result = new asd.Vector2DF();
                var angle = (diff.Degree + 360) % 360 - 45;
                if (angle < 90)
                    result.Y = Consts.Chip.ScreenHeight;
                else if (angle < 180)
                    result.X = -Consts.Chip.ScreenWidth;
                else if (angle < 270)
                    result.Y = -Consts.Chip.ScreenHeight;
                else
                    result.X = Consts.Chip.ScreenWidth;

                if (charactorSet.field.At(Position + result).type != MapChip.Type.Wall)
                    return result;
                else
                    return random_walk();
            }
        }
    }
}
