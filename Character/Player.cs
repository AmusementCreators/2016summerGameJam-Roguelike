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
using asd;

namespace _2WeeksGameJam_Roguelike.Character
{
    class Player : Charactor
    {
        public Player(CharactorSet set) :
            base(set, new asd.Vector2DF(Consts.Chip.Width * 30, Consts.Chip.Height * 30))
        {
            Src = new asd.RectF(0, Consts.Chip.Height, Consts.Chip.Width, Consts.Chip.Height);
        }

        public override int MaxActionPoint()
        {
            return 40;
        }
        public override int MaxHitPoint()
        {
            return 20;
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

        protected override Vector2DF Move()
        {
            var diff = new asd.Vector2DF();
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Push)
                diff.X -= Consts.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Push)
                diff.X += Consts.Chip.Width;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push)
                diff.Y -= Consts.Chip.Height;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
                diff.Y += Consts.Chip.Height;
            return diff;
        }
    }
}
