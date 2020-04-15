using BEngine2D.Entities;
using BEngine2D.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BExampleGame.Entities
{
    public class Tree : BEntity
    {
        public Tree(Vector2 position, BTexture spriteSheet, Vector2 size, RectangleF spriteBox) : base(position, spriteSheet, size, spriteBox)
        {
        }

        public override void Draw()
        {
            BGraphics.Draw(
                spritesheet,
                this.position - (new Vector2(DrawBox.Width / 2f, DrawBox.Height / 1.35f)),
                new Vector2((DrawBox.Width / currentSprite.Width), (DrawBox.Height / currentSprite.Height)),
                Color.Transparent,
                Vector2.Zero,
                currentSprite
            );
        }
    }
}
