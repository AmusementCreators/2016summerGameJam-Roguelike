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

namespace _2WeeksGameJam_Roguelike
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var result = System.Windows.Forms.MessageBox.Show(
                "フルスクリーン？",
                Resource.GameTitle,
                System.Windows.Forms.MessageBoxButtons.YesNo
                );
            var option = new asd.EngineOption();
            option.IsFullScreen = result == System.Windows.Forms.DialogResult.Yes;

            asd.Engine.Initialize(Resource.GameTitle, 640, 480, option);
            Resource.Init();

            asd.Engine.ChangeScene(new Scene.Title());
            while (asd.Engine.DoEvents())
            {
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
                    break;
                if (Resource.IsQuit)
                    break;
                asd.Engine.Update();
            }
            asd.Engine.Terminate();
        }
    }
}
