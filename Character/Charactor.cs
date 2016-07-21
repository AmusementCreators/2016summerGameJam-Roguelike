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
        public Charactor()
        {
            this.HitPoint = MaxHitPoint();
        }
        public int ActionPoint { get; set; }
        public int HitPoint { get; set; }

        public abstract int MaxActionPoint();
        public abstract void Action();

        public abstract int MaxHitPoint();

        public abstract bool isTurnEnd();
    }

    class CharactorSet
    {
        public CharactorSet()
        {
            field = new Character.Field("Resource/Maps/field1", enemies);
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
