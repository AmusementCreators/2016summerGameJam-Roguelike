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
    class Enemy : Turn
    {
        public Enemy(Character.CharactorSet set) :
            base(set)
        {
            if (set.enemies.Count != 0)
            {
                set.enemies.ElementAt(0).ActionPoint = set.enemies.ElementAt(0).MaxActionPoint;
                set.messageLayer.Add(set.enemies.ElementAt(0).Name() + "のターンです");
            }
        }
        public override Turn update()
        {
            var targetEnemy = charactorSet.enemies.ElementAt(enemyIndex);
            charactorSet.camera.Src = new asd.RectI(
    ((targetEnemy.Position - asd.Engine.WindowSize.To2DF() / 2) * 0.1f + charactorSet.camera.Src.Position.To2DF() * 0.9f).To2DI(),
    asd.Engine.WindowSize);
            charactorSet.camera.Dst = new asd.RectI(0, 0, 640, 480);

            targetEnemy.Action();

            if (targetEnemy.IsTurnEnd())
            {
                enemyIndex++;
                if (enemyIndex == charactorSet.enemies.Count)
                    return new Player(charactorSet);
                else
                {
                    charactorSet.messageLayer.Add(targetEnemy.Name() + "のターンです");
                    charactorSet.selectedCharactor = charactorSet.enemies.ElementAt(enemyIndex);
                    charactorSet.enemies.ElementAt(enemyIndex).ActionPoint = charactorSet.enemies.ElementAt(enemyIndex).MaxActionPoint;
                }
            }
            return this;
        }

        private int enemyIndex = 0;
    }
}
