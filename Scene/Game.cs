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

namespace _2WeeksGameJam_Roguelike.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            charactorSet.gameLayer.AddObject(charactorSet.camera);

            var circle = new asd.CircleShape();
            circle.NumberOfCorners = 32;
            viewCircle.Shape = circle;
            viewCircle.Color = new asd.Color(0, 255, 255);
            charactorSet.gameLayer.AddObject(viewCircle);

            AddLayer(charactorSet.gameLayer);

            turn = new Turn.Start(charactorSet);
            charactorSet.gameLayer.AddObject(charactorSet.player);

            AddLayer(new Layer.Status(charactorSet));
            AddLayer(charactorSet.messageLayer);

            gameSoundId = asd.Engine.Sound.Play(Resource.GameSong);
        }

        protected override void OnUpdated()
        {
            turn = turn.update();
            viewCircle.Position = charactorSet.player.Position + new asd.Vector2DF(Consts.Chip.ScreenWidth, Consts.Chip.ScreenHeight) / 2;
            float radius = (float)Math.Sqrt(30 * charactorSet.player.ViewPoint);
            (viewCircle.Shape as asd.CircleShape).InnerDiameter = radius * 2 - 1;
            (viewCircle.Shape as asd.CircleShape).OuterDiameter = radius * 2;

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push && turn is Turn.Wait)
            {
                if (charactorSet.enemies.Count(e => e.IsAlive) == 0 && charactorSet.stage == Character.CharactorSet.Stage.Stage5)
                {
                    asd.Engine.ChangeScene(new Scene.Clear());
                    return;
                }

                if (charactorSet.player.HitPoint <= 0)
                {
                    asd.Engine.ChangeScene(new Scene.GameOver());
                    return;
                }
            }
            if (charactorSet.enemies.Count(e => e.IsAlive) == 0 && !(turn is Turn.Wait))
            {
                if (charactorSet.stage == Character.CharactorSet.Stage.Stage5)
                {
                    charactorSet.messageLayer.Add("世界の平和は守られた！");
                    turn = new Turn.Wait(charactorSet);
                }
                else
                {
                    switch (charactorSet.stage)
                    {
                        case Character.CharactorSet.Stage.Stage1:
                            charactorSet.stage = Character.CharactorSet.Stage.Stage2;
                            break;
                        case Character.CharactorSet.Stage.Stage2:
                            charactorSet.stage = Character.CharactorSet.Stage.Stage3;
                            break;
                        case Character.CharactorSet.Stage.Stage3:
                            charactorSet.stage = Character.CharactorSet.Stage.Stage4;
                            break;
                        case Character.CharactorSet.Stage.Stage4:
                            charactorSet.stage = Character.CharactorSet.Stage.Stage5;
                            break;
                        default:
                            break;
                    }
                    turn = new Turn.Start(charactorSet);
                }
            }
            if (charactorSet.player.HitPoint <= 0 && !(turn is Turn.Wait))
            {
                charactorSet.messageLayer.Add("死んじゃった・・・");
                turn = new Turn.Wait(charactorSet);
            }
        }
        protected override void OnDispose()
        {
            asd.Engine.Sound.Stop(gameSoundId);
        }
        private Character.CharactorSet charactorSet = new Character.CharactorSet();
        private asd.GeometryObject2D viewCircle = new asd.GeometryObject2D();
        private Turn.Turn turn;

        int gameSoundId;
    }
}
