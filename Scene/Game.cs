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

namespace _2WeeksGameJam_Roguelike.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            charactorSet.gameLayer.AddObject(charactorSet.camera);
            charactorSet.gameLayer.AddObject(charactorSet.player);

            var circle = new asd.CircleShape();
            circle.NumberOfCorners = 32;
            viewCircle.Shape = circle;
            viewCircle.Color = new asd.Color(0, 255, 255);
            charactorSet.gameLayer.AddObject(viewCircle);

            AddLayer(charactorSet.gameLayer);

            turn = new Turn.Start(charactorSet);

            AddLayer(new Layer.Status(charactorSet));
            AddLayer(charactorSet.messageLayer);

            gameSoundId = asd.Engine.Sound.Play(Resource.GameSong);
        }

        protected override void OnUpdated()
        {
            turn = turn.update();
            viewCircle.Position = charactorSet.player.Position + new asd.Vector2DF(Consts.Chip.Width, Consts.Chip.Height)/2;
            float radius = (float)Math.Sqrt(30 * charactorSet.player.ViewPoint);
            (viewCircle.Shape as asd.CircleShape).InnerDiameter = radius * 2 - 1;
            (viewCircle.Shape as asd.CircleShape).OuterDiameter = radius * 2;

            if (charactorSet.enemies.Count(e => e.IsAlive) == 0)
            {
                if (charactorSet.stageNumber == 3)
                    asd.Engine.ChangeScene(new Scene.Clear());
                else
                    turn = new Turn.Start(charactorSet);
            }
            if (charactorSet.player.HitPoint <= 0)
                asd.Engine.ChangeScene(new Scene.GameOver());
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
