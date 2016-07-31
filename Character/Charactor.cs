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

        public enum ActionType
        {
            Move,
            Attack
        }
        static public int ActionCost(ActionType type)
        {
            switch (type)
            {
                case ActionType.Attack:
                    return 10;
                case ActionType.Move:
                    return 5;
                default:
                    return 0;
            }
        }

        public int ActionPoint { get; set; }
        public int HitPoint { get; set; }

        public abstract int MaxActionPoint { get; }
        public abstract int MaxHitPoint { get; }
        public abstract int Power { get; }

        public abstract String Name();
        abstract protected List<Character.Charactor> AgainstCharactors();

        abstract protected asd.Vector2DF Move();
        abstract protected void OnGetItem(Item.Item item);

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
                    ActionPoint -= ActionCost(ActionType.Move);
                return;
            }

            var diff = this.Move();
            if (diff == new asd.Vector2DF())
                return;

            var collideCharactor = AgainstCharactors().Find(c =>
            {
                return (c.Position - (Position + diff)).Length < 8;
            });

            if (collideCharactor != null)
            {
                ActionPoint -= ActionCost(ActionType.Attack);
                charactorSet.messageLayer.Add(collideCharactor.Name() + "に攻撃！！");
                collideCharactor.HitPoint -= Power;
                return;
            }
            var collideItem = charactorSet.items.Find(item => (item.Position - (Position + diff)).Length < 8);
            if (collideItem != null)
                OnGetItem(collideItem);

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
            player = new Character.Player(this);
            field = new Character.Field("Resource/Maps/debug", this);
        }
        public Layer.Message messageLayer = new Layer.Message();
        public asd.CameraObject2D camera = new asd.CameraObject2D();
        public Player player;
        public List<Enemy.Enemy> enemies = new List<Enemy.Enemy>();
        public List<Item.Item> items = new List<Item.Item>();
        public Field field;

        public Charactor selectedCharactor;
    }
}
