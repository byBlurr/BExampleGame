using BEngine2D.Entities;
using BEngine2D.Render;
using BEngine2D.World;
using System;
using System.Drawing;
using System.Numerics;

namespace BExampleGame.Entities
{
    public class Player : BPlayableCharacter
    {
        private RectangleF[] idleSprites, rSprites, ruSprites, rdSprites, lSprites, luSprites, ldSprites, uSprites, dSprites;
        float spriteId;

        public Player(Vector2 position, BTexture spriteSheet, BMovementType movementType = BMovementType.MoveToPosition) : base(position, spriteSheet)
        {
            var collisionWidth = size.X * 0.85f;
            var collisionHeight = size.Y * 0.5f;

            collisionBox = new RectangleF(0f - (size.X / 2f), (0f - (size.Y / 2f)) + collisionHeight, collisionWidth, collisionHeight);

            InitialiseSprites();
        }

        public void InitialiseSprites()
        {
            var spriteWidth = spritesheet.Width / 6f;
            var spriteHeight = spritesheet.Height / 9f;
            idleSprites = new RectangleF[]
            {
                new RectangleF(0, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, 0, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, 0, spriteWidth, spriteHeight),
            };
            uSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight, spriteWidth, spriteHeight),
            };
            ruSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*2, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*2, spriteWidth, spriteHeight),
            };

            rSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*3, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*3, spriteWidth, spriteHeight),
            };
            rdSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*4, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*4, spriteWidth, spriteHeight),
            };
            dSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*5, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*5, spriteWidth, spriteHeight),
            };
            ldSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*6, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*6, spriteWidth, spriteHeight),
            };
            lSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*7, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*7, spriteWidth, spriteHeight),
            };
            luSprites = new RectangleF[]
            {
                new RectangleF(0, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 2, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 3, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 4, spriteHeight*8, spriteWidth, spriteHeight),
                new RectangleF(spriteWidth * 5, spriteHeight*8, spriteWidth, spriteHeight),
            };

            spriteId = 0.0f;
            currentSprite = idleSprites[0];
        }

        public override void Draw()
        {
            base.Draw();

            if (CurrentState != BEntityState.Idle)
            {
                if (velocity.X > 0.0f) spriteId += (float)velocity.X / 30f;
                else if (velocity.X < 0.0f) spriteId += -((float)velocity.X) / 30f;

                if (spriteId > 5.0f || spriteId < 0.0f) spriteId = 0f;
            }
        }

        public override void Update(double delta, BLevel level)
        {
            base.Update(delta, level);

            UpdateSprite();
        }

        public void UpdateSprite()
        {
            switch (CurrentState)
            {
                case BEntityState.Idle:
                    currentSprite = idleSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingR:
                    currentSprite = rSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingRU:
                    currentSprite = ruSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingRD:
                    currentSprite = rdSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingL:
                    currentSprite = lSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingLU:
                    currentSprite = luSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingLD:
                    currentSprite = ldSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingU:
                    currentSprite = uSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                case BEntityState.MovingD:
                    currentSprite = dSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
                default:
                    currentSprite = idleSprites[Convert.ToInt32(Math.Floor(spriteId))];
                    break;
            }
        }
    }
}
