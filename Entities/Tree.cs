using BEngine2D.Entities;
using BEngine2D.Render;
using BEngine2D.Util;
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
            var collisionWidth = size.X / 14;
            var collisionHeight = size.Y / 5;

            collisionBox = new RectangleF(0f, 0f - (collisionHeight/2f), collisionWidth, collisionHeight);
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

            if (AppSettings.SETTING_COLLISION_DEBUG) BGraphics.DrawRec(this.position - (new Vector2(CollisionBox.Width, CollisionBox.Height) / 2f), CollisionBox, Color.AliceBlue);
        }
    }
}
