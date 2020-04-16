﻿using BEngine2D;
using BEngine2D.Entities;
using BEngine2D.GameStates;
using BEngine2D.Input;
using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using BExampleGame.Entities;
using BExampleGame.World;
using System;
using System.Drawing;
using System.Numerics;

namespace BExampleGame
{
    public class Game : BGameState
    {
        public override void OnLoad(BWindow Window)
        {
            base.OnLoad(Window);

            // Initialising our player
            Player = new Player(
                new Vector2((Level.playerStartPos.X + 0.5f) * AppInfo.GRIDSIZE, (Level.playerStartPos.Y + 0.5f) * AppInfo.GRIDSIZE),
                BGraphics.LoadTexture("Characters/player.png")
            );

            // Initialise our camera settings
            Camera.SetPosition(Player.position);
            Camera.Zoom = 1.0f;
        }

        public override void InitialiseLevel()
        {
            base.InitialiseLevel();

            // Initialising our textures (We can have up to 255 images. Make the most of this by using sprite sheets.)
            Textures[0] = BGraphics.LoadTexture("Textures/terrain_default.png");

            // Initialising our blocks (We can have up to 254 blocks, id 1 to 254)
            Blocks.Initialise();

            // Initialising our level
            Level = new BLevel("test_map");
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Tick(double delta)
        {
            base.Tick(delta);

            // Handle our player and camera movement
            var LeftClick = BMouseListener.GetButtonStateNow(BMouseButton.Left);
            if (LeftClick.IsPressed)
            {
                Vector2 pos = new Vector2(LeftClick.Location.X, LeftClick.Location.Y);
                pos -= new Vector2(AppSettings.SETTING_WIDTH, AppSettings.SETTING_HEIGHT) / 2f;
                pos = Camera.ToWorld(pos);

                Camera.SetPosition(pos, BTweenType.QuadraticInOut, 30);
                Player.MoveToPosition(pos);
            }

            var RightClick = BMouseListener.GetButtonStateNow(BMouseButton.Right);
            if (RightClick.IsPressed)
            {
                Vector2 pos = new Vector2(RightClick.Location.X, RightClick.Location.Y);
                pos -= new Vector2(AppSettings.SETTING_WIDTH, AppSettings.SETTING_HEIGHT) / 2f;
                pos = Camera.ToWorld(pos);

                while (Level.GetEntity(pos, 32f) != null)
                    Level.DisposeEntity(Level.GetEntity(pos));

                float treeSize = (float)new Random().Next(86, 128);
                Tree newEntity = new Tree(pos, BGraphics.LoadTexture("Textures/entities_default.png"), new Vector2(treeSize, treeSize), new RectangleF(0, 0, 256f, 256f));
                Level.CreateEntity(newEntity);
            }

            int ScrollWheel = BMouseListener.GetScrollWheelNow();
            if (ScrollWheel != 0)
            {
                if (ScrollWheel < 0) Camera.Zoom = Camera.Zoom - 0.075f;
                else if (ScrollWheel > 0) Camera.Zoom = Camera.Zoom + 0.075f;

                if (Camera.Zoom > 1.25f) Camera.Zoom = 1.25f;
                else if (Camera.Zoom < 0.75f) Camera.Zoom = 0.75f;
            }

            if (BKeyboardListener.IsKeyJustPressed(BKey.F8)) AppSettings.SETTING_DEBUG = !AppSettings.SETTING_DEBUG;
        }
    }
}
