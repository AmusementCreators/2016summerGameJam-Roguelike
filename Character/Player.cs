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
        public Player(Field field)
        {
            this.Position = new asd.Vector2DF(Consts.Chip.Width*30, Consts.Chip.Height*30);
            this.Texture = Resource.Image;
            this.Src = new asd.RectF(0, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);

            this.field = field;
        }

        public override int MaxActionPoint()
        {
            return 40;
        }

        protected override void OnUpdate() { }

        public override void Action()
        {
            if (step != 0)
            {
                this.Position += speed;
                step--;
                return;
            }

            var diff = new asd.Vector2DF();
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
                diff.X -= Consts.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
                diff.X += Consts.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
                diff.Y -= Consts.Chip.Height;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
                diff.Y += Consts.Chip.Height;

            bool is_wall = this.field.At(this.Position + diff).type == MapChip.Type.Wall;
            if (diff != new asd.Vector2DF() && !is_wall)
            {
                ActionPoint -= 5;
                this.speed = diff / MaxStep;
                step = MaxStep;
            }
        }

        private const int MaxStep = 8;
        private int step = 0;
        private asd.Vector2DF speed = new asd.Vector2DF();
        private Field field;
    }
}
