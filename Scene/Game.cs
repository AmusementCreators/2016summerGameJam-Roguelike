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

            var label = new asd.TextObject2D();
            label.Font = Resource.Font;
            label.Text = "Game Scene";
            label.Position = asd.Engine.WindowSize.To2DF() / 2;
            label.CenterPosition = Resource.Font.CalcTextureSize(label.Text, asd.WritingDirection.Horizontal).To2DF() / 2;

            layer.AddObject(label);
            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            ;
        }
    }
}
