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
            set.stageNumber++;
            String map_filename = "";
            switch (set.stageNumber)
            {
                case 1:
                    map_filename = "debug";
                    break;
                case 2:
                    map_filename = "field1";
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
            charactorSet.camera.Src = new asd.RectI(charactorSet.field.Size() / 2 - asd.Engine.WindowSize/2, asd.Engine.WindowSize);
            charactorSet.camera.Dst = new asd.RectI(new asd.Vector2DI(), asd.Engine.WindowSize);

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                return new Player(charactorSet);
            else
                return this;
        }
    }
}
