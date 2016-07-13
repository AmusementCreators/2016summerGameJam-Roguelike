using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace _2WeeksGameJam_Roguelike.Character
{
    class Field : asd.MapObject2D
    {
        public Field(string filepath)
        {
            using (var img = new Bitmap(Image.FromFile(filepath)))
            {
                this.chips = new MapChip[img.Width, img.Height];
                for (int y=0; y<img.Height; y++)
                {
                    for (int x=0; x<img.Width; x++)
                    {
                        this.chips[x, y] = new Func<Color, MapChip>(color =>
                        {
                            var position = new asd.Vector2DF(x * Consts.Chip.Width, y * Consts.Chip.Height);
                            if (color.R == 255)
                                return new MapChip(MapChip.Type.Wall, position);
                            else if (color.R == 0)
                                return new MapChip(MapChip.Type.Ground, position);
                            else
                                return null;
                        })(img.GetPixel(x, y));

                        AddChip(this.chips[x, y]);
                    }
                }
            }
        }

        private MapChip[,] chips;
    }

}
