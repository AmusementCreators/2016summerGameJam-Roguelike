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

namespace _2WeeksGameJam_Roguelike.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            var layer = new asd.Layer2D();

            layer.AddObject(camera);

            field = new Character.Field("Resource/Maps/field1", enemies);
            layer.AddObject(field);

            this.player = new Character.Player(field);
            layer.AddObject(player);

            foreach (var chara in enemies)
                layer.AddObject(chara);

            AddLayer(layer);

            this.turn = new Turn.Start();
            AddLayer(this.turn);

            AddLayer(message_layer);
        }

        protected override void OnUpdated()
        {
            camera.Src = new asd.RectI(player.Position.To2DI() - asd.Engine.WindowSize/2, asd.Engine.WindowSize);
            camera.Dst = new asd.RectI(0, 0, 640, 480);
            var next = turn.Next();
            if (next != turn)
            {
                turn.Dispose();
                turn = next;
                AddLayer(turn);
            }
        }
        private Character.Field field;
        private asd.CameraObject2D camera = new asd.CameraObject2D();
        private List<Character.Enemy.Enemy> enemies = new List<Character.Enemy.Enemy>();
        private Character.Player player;
        private Turn.Turn turn;

        private Layer.Message message_layer = new Layer.Message();
    }
}
