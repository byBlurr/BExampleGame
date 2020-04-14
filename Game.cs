﻿using BEngine2D;
using BEngine2D.GameStates;
using BEngine2D.Input;
using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using BEngine2D.World.Blocks;
using BExampleGame.Entities;
using BExampleGame.World;
using System;
using System.Drawing;
using System.Numerics;

namespace BExampleGame
{
    public class Game : BGameState
    {
        BTexture[] Textures = new BTexture[200];
        BLevel Level;
        Player Player;

        public override void OnLoad()
        {
            base.OnLoad();

            Textures[0] = BGraphics.LoadTexture("Textures/terrain_default.png");
            Blocks.Initialise();

            Level = new BLevel("Content/Maps/test_map.json");
            Player = new Player(
                new Vector2((Level.playerStartPos.X + 0.5f) * AppInfo.GRIDSIZE, (Level.playerStartPos.Y + 0.5f) * AppInfo.GRIDSIZE),
                BGraphics.LoadTexture("Characters/player.png")
            );
            Camera.SetPosition(Player.position);
            Camera.Zoom = 2.0f;
        }

        public override void Draw()
        {
            base.Draw();

            // Todo: Draw World
            for (int x = 0; x < Level.Width; x++)
            {
                for (int y = 0; y < Level.Height; y++)
                {
                    RectangleF source = Level[x, y].TexturePosition;
                    BGraphics.Draw(Textures[0], new Vector2(x * AppInfo.GRIDSIZE, y * AppInfo.GRIDSIZE), new Vector2((float)AppInfo.GRIDSIZE / AppInfo.TILESIZE), Color.Transparent, Vector2.Zero, source); ;
                }
            }

            Player.Draw();
        }

        public override void Tick(double delta)
        {
            base.Tick(delta);

            Player.Update(delta);

            //if (Camera.GetDistanceFromLocation(Player.position) > 45.0f) Camera.SetPosition(Player.position, BTweenType.QuadraticInOut, 60);

            var LeftClick = BMouseListener.GetButtonStateNow(BMouseButton.Left);
            if (LeftClick.IsPressed)
            {
                Vector2 pos = new Vector2(LeftClick.Location.X, LeftClick.Location.Y);
                pos -= new Vector2(AppSettings.SETTING_WIDTH, AppSettings.SETTING_HEIGHT) / 2f;
                pos = Camera.ToWorld(pos);

                Camera.SetPosition(pos, BTweenType.QuadraticInOut, 120);
                Player.MoveToPosition(pos);
            }
        }
    }
}
