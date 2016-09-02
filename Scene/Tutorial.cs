using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Scene
{
    class Tutorial : asd.Scene
    {
        public Tutorial()
        {
            var layer = new asd.Layer2D();
            var background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D("Resource/title.png");
            background.Scale = new asd.Vector2DF(4, 4);
            layer.AddObject(background);
            AddLayer(layer);

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
                asd.Engine.ChangeScene(new Scene.Title());

            if (charactorSet.enemies.Count(e => e.IsAlive) == 0 && !(turn is Turn.Wait))
            {
                charactorSet.messageLayer.Add("チュートリアル終わり！！");
                turn = new Turn.Wait(charactorSet);
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
        private Character.CharactorSet charactorSet = new Character.CharactorSet(Character.CharactorSet.Stage.Tutorial);
        private asd.GeometryObject2D viewCircle = new asd.GeometryObject2D();
        private Turn.Turn turn;

        int gameSoundId;
    }
}
