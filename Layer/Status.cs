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

namespace _2WeeksGameJam_Roguelike.Layer
{
    class Status : asd.Layer2D
    {
        public Status(Character.CharactorSet set)
        {
            background = new asd.GeometryObject2D();
            var shape = new asd.RectangleShape();
            background.Shape = shape;
            background.Color = new asd.Color(0, 50, 100, 100);
            AddObject(background);

            charactorSet = set;
            playerStatusLabel.Font = Resource.SmallFont;
            playerStatusLabel.Position = new asd.Vector2DF(32, 32);
            AddObject(playerStatusLabel);

            enemiesStatusLabel.Font = Resource.SmallFont;
            enemiesStatusLabel.Position = new asd.Vector2DF(32, 96);
            AddObject(enemiesStatusLabel);
        }

        protected override void OnUpdated()
        {
            var player = charactorSet.player;
            playerStatusLabel.Text  = "プレイヤー: \n";
            playerStatusLabel.Text += String.Format("  AP    : {0} / {1}\n", player.ActionPoint, player.MaxActionPoint);
            playerStatusLabel.Text += String.Format("  HP    : {0} / {1}\n", player.HitPoint, player.MaxHitPoint);
            playerStatusLabel.Text += String.Format("  Power : {0}\n", player.Power);
            playerStatusLabel.Text += String.Format("  View  : {0}\n", player.ViewPoint);
            enemiesStatusLabel.Text = "近くにいる敵: AP/HP/Power\n";
            float radius = (float)Math.Sqrt(30 * charactorSet.player.ViewPoint);
            var nearEnemies = charactorSet.enemies
                .FindAll(enemy => (enemy.Position - player.Position).Length < radius);
            nearEnemies.Sort(new Character.Enemy.Enemy.DistanceToPlayer());
            foreach (var e in nearEnemies)
                enemiesStatusLabel.Text += String.Format("  {0}: {1}/{2}/{3}\n", e.Name(), e.MaxActionPoint, e.HitPoint, e.Power);
            var playerLabelHeight = Resource.SmallFont.CalcTextureSize(playerStatusLabel.Text, asd.WritingDirection.Horizontal).Y;
            enemiesStatusLabel.Position = playerStatusLabel.GetGlobalPosition() + new asd.Vector2DF(0, playerLabelHeight);

            var size = Resource.SmallFont.CalcTextureSize(enemiesStatusLabel.Text, asd.WritingDirection.Horizontal).To2DF() + new asd.Vector2DF(8, playerLabelHeight + 8);
            (background.Shape as asd.RectangleShape).DrawingArea = new asd.RectF(playerStatusLabel.Position, size);
        }
        private asd.GeometryObject2D background = new asd.GeometryObject2D();
        private asd.TextObject2D playerStatusLabel = new asd.TextObject2D();
        private asd.TextObject2D enemiesStatusLabel = new asd.TextObject2D();
        private Character.CharactorSet charactorSet;
    }
}
