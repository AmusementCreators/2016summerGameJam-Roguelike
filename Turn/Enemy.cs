using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Turn
{
    class Enemy : Turn
    {
        public Enemy(Character.CharactorSet set) :
            base(set)
        {
            set.enemies.ElementAt(0).ActionPoint = set.enemies.ElementAt(0).MaxActionPoint();
            set.messageLayer.Add(set.enemies.ElementAt(0).Name() + "のターンです");
        }
        public override Turn update()
        {
            var targetEnemy = charactorSet.enemies.ElementAt(enemyIndex);
            this.charactorSet.camera.Src = new asd.RectI(targetEnemy.Position.To2DI() - asd.Engine.WindowSize / 2, asd.Engine.WindowSize);
            this.charactorSet.camera.Dst = new asd.RectI(0, 0, 640, 480);

            targetEnemy.Action();

            if (targetEnemy.isTurnEnd())
            {
                enemyIndex++;
                if (enemyIndex == charactorSet.enemies.Count)
                    return new Player(charactorSet);
                else
                {
                    charactorSet.messageLayer.Add(targetEnemy.Name() + "のターンです");
                    charactorSet.selectedCharactor = charactorSet.enemies.ElementAt(enemyIndex);
                    charactorSet.enemies.ElementAt(enemyIndex).ActionPoint = charactorSet.enemies.ElementAt(enemyIndex).MaxActionPoint();
                }
            }
            return this;
        }

        private int enemyIndex = 0;
    }
}
