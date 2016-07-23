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
    abstract class Charactor : asd.TextureObject2D
    {
        public Charactor(CharactorSet set, asd.Vector2DF pos)
        {
            charactorSet = set;
            Texture = Resource.Image;
            Position = pos;
            HitPoint = MaxHitPoint;
        }
        public int ActionPoint { get; set; }
        public int HitPoint { get; set; }

        public abstract int MaxActionPoint { get; }
        public abstract int MaxHitPoint { get; }

        public abstract String Name();
        abstract protected List<Character.Charactor> AgainstCharactors();

        abstract protected asd.Vector2DF Move();

        public virtual bool IsTurnEnd()
        {
            return ActionPoint <= 0;
        }

        public void Action()
        {
            if (step != 0)
            {
                Position += speed;
                step--;
                if (step == 0)
                    ActionPoint -= 5;
                return;
            }

            var diff = this.Move();
            if (diff == new asd.Vector2DF())
                return;

            var collideCharactor = AgainstCharactors().Find(c =>
            {
                return (c.Position - (Position + diff)).Length < 8;
            });

            if (collideCharactor != null && (Position + diff - collideCharactor.Position).Length < 8)
            {
                ActionPoint -= 10;
                charactorSet.messageLayer.Add(collideCharactor.Name() + "に攻撃！！");
                collideCharactor.HitPoint -= 1;
                return;
            }
            if (charactorSet.field.At(Position + diff).type != MapChip.Type.Wall)
            {
                speed = diff / MaxStep;
                step = MaxStep;
            }
        }

        private const int MaxStep = 16;
        private int step = 0;
        private asd.Vector2DF speed = new asd.Vector2DF();
        protected CharactorSet charactorSet;
    }

    class CharactorSet
    {
        public CharactorSet()
        {
            field = new Character.Field("Resource/Maps/debug", this);
            player = new Character.Player(this);
        }
        public Layer.Message messageLayer = new Layer.Message();
        public asd.CameraObject2D camera = new asd.CameraObject2D();
        public Player player;
        public List<Enemy.Enemy> enemies = new List<Enemy.Enemy>();
        public Field field;

        public Charactor selectedCharactor;
    }
}
