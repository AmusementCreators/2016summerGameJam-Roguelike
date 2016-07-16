using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike.Layer
{
    class Message : asd.Layer2D
    {
        public Message()
        {
            var rect = new asd.GeometryObject2D();
            var shape = new asd.RectangleShape();
            shape.DrawingArea = new asd.RectF(-Width/2, -Height/2, Width, Height);
            rect.Shape = shape;
            var pos = asd.Engine.WindowSize.To2DF() / 2;
            pos.Y *= 3.0f / 2.0f;
            rect.Position = pos;
            rect.Color = new asd.Color(0, 50, 100, 100);
            AddObject(rect);

            label.Font = Resource.SmallFont;
            label.Text = "";
            label.Position = rect.Position - shape.DrawingArea.Size/2 + new asd.Vector2DF(8, 8);
            AddObject(label);
        }

        public void Add(String str)
        {
            lines.Add(str);
            if (lines.Count() > MaxLines)
                lines.RemoveAt(0);
            label.Text = "";
            foreach (var line in lines)
                label.Text += "\n" + line;
        }

        const int Width = 400;
        const int Height = 160;
        const int MaxLines = 6;
        asd.TextObject2D label = new asd.TextObject2D();
        List<String> lines = new List<string>();
    }
}
