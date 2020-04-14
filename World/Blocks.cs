using BEngine2D.Util;
using BEngine2D.World.Blocks;
using System.Drawing;

namespace BExampleGame.World
{
    public class Blocks
    {
        public static void Initialise()
        {
            BBlocks.AddBlock(1, new BBlockTemplate("Water", BBlockType.Solid, new RectangleF(0, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)));
            BBlocks.AddBlock(2, new BBlockTemplate("Grass", BBlockType.Ground, new RectangleF(AppInfo.TILESIZE, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)));
            BBlocks.AddBlock(3, new BBlockTemplate("Dirt", BBlockType.Ground, new RectangleF(AppInfo.TILESIZE * 2, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)));
            BBlocks.AddBlock(4, new BBlockTemplate("Sand", BBlockType.Ground, new RectangleF(AppInfo.TILESIZE * 3, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)));
            BBlocks.AddBlock(5, new BBlockTemplate("Stone", BBlockType.Ground, new RectangleF(AppInfo.TILESIZE * 4, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)));
        }
    }
}
