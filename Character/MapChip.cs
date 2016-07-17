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

namespace _2WeeksGameJam_Roguelike.Character
{
    class MapChip : asd.Chip2D
    {
        public enum Type
        {
            Ground,
            Wall
        }

        public MapChip(Type type, asd.Vector2DF position)
        {
            this.type = type;
            this.Position = position;
            this.Texture = Resource.Image;
            switch (type)
            {
                case Type.Ground:
                    this.Src = new asd.RectF(0, 0, Consts.Chip.Width, Consts.Chip.Height);
                    break;
                case Type.Wall:
                    this.Src = new asd.RectF(Consts.Chip.Width, 0, Consts.Chip.Width, Consts.Chip.Height);
                    break;
            }
        }


        public Type type;
    }
}
