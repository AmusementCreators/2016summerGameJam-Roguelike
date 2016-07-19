using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Character
{
    abstract class Charactor : asd.TextureObject2D
    {
        public int ActionPoint { get; set; }
        public abstract int MaxActionPoint();
        public abstract void Action();
    }

    class CharactorSet
    {
        public CharactorSet()
        {
            field = new Character.Field("Resource/Maps/field1", enemies);
            player = new Character.Player(field);
        }
        public Layer.Message messageLayer = new Layer.Message();
        public asd.CameraObject2D camera = new asd.CameraObject2D();
        public Player player;
        public List<Enemy.Enemy> enemies = new List<Enemy.Enemy>();
        public Field field;
    }
}
