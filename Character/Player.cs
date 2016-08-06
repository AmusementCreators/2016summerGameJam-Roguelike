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
using _2WeeksGameJam_Roguelike.Character.Item;
using asd;

namespace _2WeeksGameJam_Roguelike.Character
{
    class Player : Charactor
    {
        public Player(CharactorSet set) :
            base(set, new asd.Vector2DF())
        {
            Src = new asd.RectF(0, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        public override int MaxActionPoint {  get { return 40; } }
        public override int MaxHitPoint { get { return 20; } }
        public override int Power { get { return power; } }

        private int viewPoint = 30;
        public int ViewPoint
        {
            get
            {
                return viewPoint;
            }
        }

        public override string Name()
        {
            return "プレイヤー";
        }

        protected override List<Charactor> AgainstCharactors()
        {
            List<Charactor> result = new List<Charactor>();
            foreach (var e in charactorSet.enemies)
                result.Add(e);
            return result;
        }

        protected override void OnGetItem(Item.Item item)
        {
            if (item is Item.Life)
                HitPoint += 5;
            if (item is Item.Power)
                power += 1;
            if (item is Item.View)
                viewPoint *= 2;
            item.Dispose();
        }

        protected override Vector2DF Move()
        {
            var diff = new asd.Vector2DF();
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Push)
                diff.X -= Consts.Chip.ScreenWidth;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Push)
                diff.X += Consts.Chip.ScreenWidth;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push)
                diff.Y -= Consts.Chip.ScreenHeight;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
                diff.Y += Consts.Chip.ScreenHeight;
            return diff;
        }

        private int power = 1;
    }
}
