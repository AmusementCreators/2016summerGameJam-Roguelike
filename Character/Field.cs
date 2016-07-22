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
using System.Drawing;
using System.Drawing.Imaging;

namespace _2WeeksGameJam_Roguelike.Character
{
    class Field : asd.MapObject2D
    {
        public Field(string filepath, List<Enemy.Enemy> enemies)
        {
            using (var img = new Bitmap(Image.FromFile(filepath)))
            {
                this.chips = new MapChip[img.Width, img.Height];
                for (int y=0; y<img.Height; y++)
                {
                    for (int x=0; x<img.Width; x++)
                    {
                        var color = img.GetPixel(x, y);
                        var position = new asd.Vector2DF(x * Consts.Chip.Width, y * Consts.Chip.Height);
                        if (color.G == 255)
                        {
                            this.chips[x, y] = new MapChip(MapChip.Type.Wall, position);
                            AddChip(this.chips[x, y]);
                        } else if (color.R == 255)
                        {
                            this.chips[x, y] = new MapChip(MapChip.Type.Ground, position);
                            AddChip(this.chips[x, y]);
                            enemies.Add(new Character.Enemy.Slime(this, position));
                        } else
                        {
                            this.chips[x, y] = new MapChip(MapChip.Type.Ground, position);
                            AddChip(this.chips[x, y]);
                        }
                    }
                }
            }
        }

        public MapChip At(asd.Vector2DF pos)
        {
            int x = (int)pos.X / Consts.Chip.Width;
            int y = (int)pos.Y / Consts.Chip.Height;
            try
            {
                return this.chips[x, y];
            } catch (IndexOutOfRangeException)
            {
                return new MapChip(MapChip.Type.Wall, pos);
            }
        }

        private MapChip[,] chips;
    }

}
