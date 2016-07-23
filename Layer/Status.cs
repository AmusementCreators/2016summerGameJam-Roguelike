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
            charactorSet = set;
            APLabel.Font = Resource.SmallFont;
            APLabel.Position = new asd.Vector2DF();
            AddObject(APLabel);
        }

        protected override void OnUpdated()
        {
            var target = charactorSet.selectedCharactor;
            if (target != null)
            {
                APLabel.Text = "ActionPoint: " + target.ActionPoint.ToString();
                APLabel.Text += "\nHitPoint: " + target.HitPoint.ToString();
            }
        }
        private asd.TextObject2D APLabel = new asd.TextObject2D();
        private Character.CharactorSet charactorSet;
    }
}
