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

namespace _2WeeksGameJam_Roguelike.Character.Enemy
{
    class Golem : Enemy
    {
        public Golem(CharactorSet set, asd.Vector2DF pos)
        {
            this.Texture = Resource.Image;
            this.Src = new asd.RectF(Consts.Chip.Width * 2, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
            this.Position = pos;

            this.charactorSet = set;
        }

        public override int MaxActionPoint()
        {
            return 10;
        }
        public override int MaxHitPoint()
        {
            return 1;
        }

        protected override void OnUpdate()
        {
        }
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

            asd.Vector2DF diff = new asd.Vector2DF();
            switch (Resource.Rand.Next(0, 3))
            {
                case 0:
                    diff = new asd.Vector2DF(-Consts.Chip.Width, 0);
                    break;
                case 1:
                    diff = new asd.Vector2DF(Consts.Chip.Width, 0);
                    break;
                case 2:
                    diff = new asd.Vector2DF(0, -Consts.Chip.Height);
                    break;
                case 3:
                    diff = new asd.Vector2DF(0, Consts.Chip.Height);
                    break;
            }
            if ((Position + diff - charactorSet.player.Position).Length < 8)
            {
                // プレイヤーに攻撃
                this.ActionPoint -= 10;
                this.charactorSet.messageLayer.Add("プレイヤーに攻撃！！");
                charactorSet.player.HitPoint -= 1;
                return;
            }
            if (charactorSet.field.At(Position + diff).type != MapChip.Type.Wall)
            {
                this.speed = diff / MaxStep;
                step = MaxStep;
            }
        }

        public override bool isTurnEnd()
        {
            return ActionPoint <= 0;
        }

        public override string Name()
        {
            return "ゴーレム";
        }

        private const int MaxStep = 16;
        private int step = 0;
        private asd.Vector2DF speed = new asd.Vector2DF();
        private CharactorSet charactorSet;
    }
}
