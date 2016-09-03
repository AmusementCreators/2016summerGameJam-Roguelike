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

            String map_filename = "";
            switch (set.stage)
            {
                case Character.CharactorSet.Stage.Tutorial:
                    map_filename = "tutorial";
                    set.messageLayer.Add("チュートリアルを始めます");
                    set.messageLayer.Add("カーソルキーで移動とかできます");
                    set.messageLayer.Add("目の前にある薬品を取ってみよう");
                    break;
                case Character.CharactorSet.Stage.Stage1:
                    map_filename = "field1";
                    set.messageLayer.Add("冒険のはじまりだ！");
                    break;
                case Character.CharactorSet.Stage.Stage2:
                    map_filename = "field2";
                    break;
                case Character.CharactorSet.Stage.Stage3:
                    map_filename = "field3";
                    break;
                case Character.CharactorSet.Stage.Stage4:
                    map_filename = "field4";
                    break;
                case Character.CharactorSet.Stage.Stage5:
                    map_filename = "field5";
                    set.messageLayer.Add("とうとう魔王のいるところまで来たぞ！！");
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
            charactorSet.camera.Src = new asd.RectI(charactorSet.field.Size() / 2 - asd.Engine.WindowSize / 2, asd.Engine.WindowSize);
            charactorSet.camera.Dst = new asd.RectI(new asd.Vector2DI(), asd.Engine.WindowSize);

            return new Player(charactorSet);
        }
    }
}
