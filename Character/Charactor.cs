using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character
{
    abstract class Charactor : asd.TextureObject2D
    {
    }

    class CharactorSet
    {
        public asd.CameraObject2D camera = new asd.CameraObject2D();
        public Player player;
        public List<Enemy.Enemy> enemies = new List<Enemy.Enemy>();
        public Field field;
    }
}
