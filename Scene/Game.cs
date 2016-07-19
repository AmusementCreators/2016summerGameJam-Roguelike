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

namespace _2WeeksGameJam_Roguelike.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            var layer = new asd.Layer2D();

            layer.AddObject(charactorSet.camera);

            charactorSet.field = new Character.Field("Resource/Maps/field1", charactorSet.enemies);
            layer.AddObject(charactorSet.field);

            charactorSet.player = new Character.Player(charactorSet.field);
            layer.AddObject(charactorSet.player);

            foreach (var chara in charactorSet.enemies)
                layer.AddObject(chara);

            AddLayer(layer);

            this.turn = new Turn.Start(this.charactorSet);

            AddLayer(message_layer);
        }

        protected override void OnUpdated()
        {
            turn = turn.update();
        }
        private Character.CharactorSet charactorSet = new Character.CharactorSet();
        private Turn.Turn turn;

        private Layer.Message message_layer = new Layer.Message();
    }
}
