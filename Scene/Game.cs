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
            layer.AddObject(field);

            charactors.Add(new Character.Player(field));

            foreach (var chara in charactors)
                layer.AddObject(chara);

            AddLayer(layer);

            this.turn = new Turn.Start();
            AddLayer(this.turn);

            AddLayer(message_layer);
        }

        protected override void OnUpdated()
        {
            var player = charactors.ElementAt(0);
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
        private Character.Field field = new Character.Field("Resource/Maps/field1");
        private asd.CameraObject2D camera = new asd.CameraObject2D();
        private List<Character.Charactor> charactors = new List<Character.Charactor>();
        private Turn.Turn turn;

        private Layer.Message message_layer = new Layer.Message();
    }
}
