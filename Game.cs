using BEngine2D.GameStates;
using BEngine2D.Input;
using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using BExampleGame.Entities;
using BExampleGame.World;
using System.Numerics;

namespace BExampleGame
{
    public class Game : BGameState
    {
        Player Player;

        public override void OnLoad()
        {
            base.OnLoad();

            Player = new Player(
                new Vector2((Level.playerStartPos.X + 0.5f) * AppInfo.GRIDSIZE, (Level.playerStartPos.Y + 0.5f) * AppInfo.GRIDSIZE),
                BGraphics.LoadTexture("Characters/player.png")
            );
            Camera.SetPosition(Player.position);
            Camera.Zoom = 2.0f;
        }

        public override void InitialiseLevel()
        {
            base.InitialiseLevel();

            Textures[0] = BGraphics.LoadTexture("Textures/terrain_default.png");
            Blocks.Initialise();
            Level = new BLevel("Content/Maps/test_map.json");
            
        }

        public override void Draw()
        {
            base.Draw();

            Player.Draw();
        }

        public override void Tick(double delta)
        {
            base.Tick(delta);

            Player.Update(delta);

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
