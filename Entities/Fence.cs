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
    public class Fence : BEntity
    {
        public Fence(Vector2 position, BTexture spriteSheet, Vector2 size, RectangleF spriteBox) : base(position, spriteSheet, size, spriteBox)
        {
            collisionBox = new RectangleF(0f - size.X / 2f, 0f, size.X, size.Y / 2);
        }
    }
}
