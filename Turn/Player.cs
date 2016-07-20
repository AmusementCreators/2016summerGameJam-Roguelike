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

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Player : Turn
    {
        public Player(Character.CharactorSet set) :
            base(set)
        {
            set.messageLayer.Add("プレイヤーのターンです");
            charactorSet.selectedCharactor = charactorSet.player;
            charactorSet.player.ActionPoint = charactorSet.player.MaxActionPoint();
        }

        public override Turn update()
        {
            this.charactorSet.camera.Src = new asd.RectI(this.charactorSet.player.Position.To2DI() - asd.Engine.WindowSize / 2, asd.Engine.WindowSize);
            this.charactorSet.camera.Dst = new asd.RectI(0, 0, 640, 480);

            charactorSet.player.Action();

            if (charactorSet.player.isTurnEnd())
                return new Enemy(this.charactorSet);
            else
                return this;
        }
    }
}
