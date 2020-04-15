using BEngine2D;
using BEngine2D.GameStates;
using BEngine2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BExampleGame
{
    public class Menu : BMenuState
    {
        public Menu()
        {
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void OnLoad(BWindow Window)
        {
            base.OnLoad(Window);

            // Initialise our menu buttons
            BMenuButton[] buttons = new BMenuButton[] {
                new BMenuButton(SwitchState, 300f, 300f, 150f, 60f),
                new BMenuButton(Window.ExitWindow, 300f, 380f, 150f, 60f)
            };
            InitialiseMenu(buttons);
        }

        private void SwitchState(object obj)
        {
            BWindow window = (BWindow)obj;
            if (window != null)
            {
                window.SwitchState(new Game());
            }
            else throw new InvalidCastException();
        }

        public override void Tick(double delta)
        {
            base.Tick(delta);
        }
    }
}
