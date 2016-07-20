using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character.Enemy
{
    class Slime : Enemy
    {
        public Slime(Field field, asd.Vector2DF pos)
        {
            this.Texture = Resource.Image;
            this.Src = new asd.RectF(Consts.Chip.Width, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
            this.Position = pos;

            this.field = field;
        }

        public override int MaxActionPoint()
        {
            return 10;
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
            bool is_wall = this.field.At(this.Position + diff).type == MapChip.Type.Wall;
            if (diff != new asd.Vector2DF() && !is_wall)
            {
                ActionPoint -= 5;
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
            return "スライム";
        }

        private const int MaxStep = 16;
        private int step = 0;
        private asd.Vector2DF speed = new asd.Vector2DF();
        private Field field;
    }
}
