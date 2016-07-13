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

            layer.AddObject(player);

            layer.AddObject(field);
            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            camera.Src = new asd.RectI(player.Position.To2DI() - asd.Engine.WindowSize/2, asd.Engine.WindowSize);
            camera.Dst = new asd.RectI(0, 0, 640, 480);
        }
        private Character.Field field = new Character.Field("Resource/Maps/field1");
        private Character.Player player = new Character.Player();
        private asd.CameraObject2D camera = new asd.CameraObject2D();
    }
}
