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
    class Player : Charactor
    {
        public Player()
        {
            this.Position = new asd.Vector2DF(Consts.Chip.Width*30, Consts.Chip.Height*30);
            this.Texture = Resource.Image;
            this.Src = new asd.RectF(0, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        protected override void OnUpdate()
        {
            if (step != 0)
            {
                this.Position += speed;
                step--;
                return;
            }

            var diff = new asd.Vector2DF();
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
                diff.X -= Consts.Chip.Width / MaxStep;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
                diff.X += Consts.Chip.Width / MaxStep;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
                diff.Y -= Consts.Chip.Height / MaxStep;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
                diff.Y += Consts.Chip.Height / MaxStep;

            if (diff != new asd.Vector2DF())
            {
                this.speed = diff;
                step = MaxStep;
            }
        }

        private const int MaxStep = 8;
        private int step = 0;
        private asd.Vector2DF speed = new asd.Vector2DF();
    }
}
