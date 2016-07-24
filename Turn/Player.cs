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
    class Player : Turn
    {
        public Player(Character.CharactorSet set) :
            base(set)
        {
            set.messageLayer.Add("プレイヤーのターンです");
            charactorSet.selectedCharactor = charactorSet.player;
            charactorSet.player.ActionPoint = charactorSet.player.MaxActionPoint;
        }

        public override Turn update()
        {
            charactorSet.camera.Src = new asd.RectI(
                ((charactorSet.player.Position - asd.Engine.WindowSize.To2DF() / 2) * 0.1f  + charactorSet.camera.Src.Position.To2DF() * 0.9f).To2DI(),
                asd.Engine.WindowSize);
            charactorSet.camera.Dst = new asd.RectI(0, 0, 640, 480);

            charactorSet.player.Action();

            charactorSet.enemies.ForEach(e => {
                if (e.HitPoint <= 0)
                {
                    charactorSet.messageLayer.Add(e.Name() + "は死んだ！！");
                    e.Dispose();
                }
            });
            charactorSet.enemies.RemoveAll(e => !e.IsAlive);
            charactorSet.items.RemoveAll(item => !item.IsAlive);

            if (charactorSet.player.IsTurnEnd())
                return new Enemy(charactorSet);
            else
                return this;
        }
    }
}
