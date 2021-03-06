﻿/*============================================================================
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

        public override int ActionPoint
        {
            set
            {
                base.ActionPoint = value;
                if (base.ActionPoint > MaxActionPoint)
                    base.ActionPoint = MaxActionPoint;
                if (base.ActionPoint < 0)
                    base.ActionPoint = 0;
            }
        }
        public override int HitPoint
        {
            set
            {
                base.HitPoint = value;
                if (base.HitPoint > MaxHitPoint)
                    base.HitPoint = MaxHitPoint;
            }
        }
        public override int MaxActionPoint {  get { return 40; } }
        public override int MaxHitPoint { get { return 10; } }
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
            charactorSet.messageLayer.Add(item.Name() + "を手に入れた！");
            if (charactorSet.stage == CharactorSet.Stage.Tutorial)
            {
                if (item is Item.Life)
                    charactorSet.messageLayer.Add("緑のアイテムを取るとHitPointが回復します");
                if (item is Item.Power)
                    charactorSet.messageLayer.Add("赤のアイテムを取るとPowerが上がります");
                if (item is Item.View)
                    charactorSet.messageLayer.Add("青のアイテムを取ると索敵範囲が広がります");
            }

            if (item is Item.Life)
                HitPoint++;
            if (item is Item.Power)
                power++;
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

        protected override int MaxStep { get { return 16; } }
        private int power = 1;
    }
}
