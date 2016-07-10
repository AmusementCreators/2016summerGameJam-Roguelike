using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2WeeksGameJam_Roguelike
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            asd.Engine.Initialize("Roguqlike", 640, 480, new asd.EngineOption());

            while (asd.Engine.DoEvents())
            {
                asd.Engine.Update();
            }
            asd.Engine.Terminate();
        }
    }
}
