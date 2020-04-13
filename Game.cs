using BEngine2D;
using BEngine2D.Input;
using BEngine2D.Render;
using BEngine2D.Util;
using System;
using System.Drawing;
using System.Numerics;

namespace BExampleGame
{
    public class Game : BGame
    {
        BTexture2D[] Textures = new BTexture2D[200];

        public Game(string title, double fps, double ups) : base(title, fps, ups)
        {

        }
        public override void OnLoad()
        {
            base.OnLoad();
            Textures[0] = BContentPipe.LoadTexture("Textures/tree.png");
            Textures[1] = BContentPipe.LoadTexture("Textures/grass.png");
        }

        public override void Draw()
        {
            base.Draw();

            // Todo: Draw World

            // Draw random ass tree
            BGraphics.Draw(Textures[0], Vector2.Zero, new Vector2(0.2f), Color.Transparent, new Vector2(0, 256));
            BGraphics.Draw(Textures[0], Vector2.Zero, new Vector2(0.2f), Color.Transparent, new Vector2(0, 0));
            BGraphics.Draw(Textures[0], Vector2.Zero, new Vector2(0.2f), Color.Transparent, new Vector2(256, 0));
            BGraphics.Draw(Textures[1], Vector2.Zero, new Vector2(0.2f), Color.Transparent, new Vector2(256*2, 0));
            BGraphics.Draw(Textures[1], Vector2.Zero, new Vector2(0.2f), Color.Transparent, new Vector2(256*3, 0));
            BGraphics.Draw(Textures[1], Vector2.Zero, new Vector2(0.2f), Color.Transparent, new Vector2(256*4, 0));
        }

        public override void Tick(double delta)
        {
            base.Tick(delta);
        }

        public override void OnMouseDown(BMouseButton button, System.Numerics.Vector2 position)
        {
            base.OnMouseDown(button, position);

            if (button.Equals(BMouseButton.Left))
            {
                Vector2 pos = new Vector2(position.X, position.Y);
                pos -= new Vector2(Width, Height) / 2f;
                pos = Camera.ToWorld(pos);

                Camera.SetPosition(pos, BTweenType.QuadraticInOut, 120);
            }
        }
    }
}
