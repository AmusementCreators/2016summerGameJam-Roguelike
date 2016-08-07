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

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Start : Turn
    {
        public Start(Character.CharactorSet set) :
            base(set)
        {
            foreach (var e in set.enemies)
                e.Dispose();
            foreach (var i in set.items)
                i.Dispose();
            set.enemies.RemoveAll(e => !e.IsAlive);
            set.items.RemoveAll(e => !e.IsAlive);
            set.messageLayer.Clear();

            set.stageNumber++;
            String map_filename = "";
            switch (set.stageNumber)
            {
                case 1:
                    map_filename = "debug";
                    set.messageLayer.Add("これはデバッグ用のステージです");
                    set.messageLayer.Add("Zキーを押してステージ開始");
                    break;
                case 2:
                    map_filename = "field1";
                    set.messageLayer.Add("冒険を開始して早々スライムの群れに遭遇した");
                    set.messageLayer.Add("これを切り抜けないと向こうの村にたどり着けない");
                    set.messageLayer.Add("Zキーを押してゲーム開始");
                    break;
                case 3:
                    map_filename = "field2";
                    set.messageLayer.Add("スライムの群れを切り抜けたと思ったら今度はゴーレムだ！");
                    set.messageLayer.Add("Zキーを押してゲーム開始");
                    break;
                case 4:
                    map_filename = "field3";
                    set.messageLayer.Add("Zキーを押してゲーム開始");
                    break;
                default:
                    break;
            }
            set.field?.Dispose();
            set.field = new Character.Field(String.Format("Resource/Maps/{0}", map_filename), set);
            charactorSet.gameLayer.AddObject(charactorSet.field);
            foreach (var chara in charactorSet.enemies)
                charactorSet.gameLayer.AddObject(chara);
            foreach (var item in charactorSet.items)
                charactorSet.gameLayer.AddObject(item);
        }
        public override Turn update()
        {
            charactorSet.camera.Src = new asd.RectI(charactorSet.field.Size() / 2 - asd.Engine.WindowSize/2, charactorSet.field.Size() * 2 / 3);
            charactorSet.camera.Dst = new asd.RectI(new asd.Vector2DI(), asd.Engine.WindowSize);

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                return new Player(charactorSet);
            else
                return this;
        }
    }
}
