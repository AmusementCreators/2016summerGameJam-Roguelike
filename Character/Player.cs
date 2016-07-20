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
        public Player(CharactorSet set)
        {
            this.Position = new asd.Vector2DF(Consts.Chip.Width*30, Consts.Chip.Height*30);
            this.Texture = Resource.Image;
            this.Src = new asd.RectF(0, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);

            this.charactorSet = set;
        }

        public override int MaxActionPoint()
        {
            return 40;
        }

        public override bool isTurnEnd()
        {
            return ActionPoint <= 0;
        }

        protected override void OnUpdate() { }

        public override void Action()
        {
            if (step != 0)
            {
                this.Position += speed;
                step--;
                if (step == 0)
                    ActionPoint -= 5;
                return;
            }

            var diff = new asd.Vector2DF();
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Push)
                diff.X -= Consts.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Push)
                diff.X += Consts.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push)
                diff.Y -= Consts.Chip.Height;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
                diff.Y += Consts.Chip.Height;

            bool is_wall = charactorSet.field.At(this.Position + diff).type == MapChip.Type.Wall;
            var enemy = charactorSet.enemies.Find(e =>
            {
                return (e.Position - (this.Position + diff)).Length < 8;
            });

            if (diff != new asd.Vector2DF())
            {
                if (!(enemy == null))
                {
                    // 敵に攻撃
                    this.ActionPoint -= 10;
                    this.charactorSet.messageLayer.Add(enemy.Name() + "に攻撃！！");
                    return;
                }
                if (!is_wall)
                {
                    this.speed = diff / MaxStep;
                    step = MaxStep;
                }
            }
        }

        private const int MaxStep = 8;
        private int step = 0;
        private asd.Vector2DF speed = new asd.Vector2DF();
        private CharactorSet charactorSet;
    }
}
