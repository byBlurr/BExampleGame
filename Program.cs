using BEngine2D.Util;

namespace BExampleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppInfo.APP_NAME = "Tree Planter";
            AppInfo.APP_DEVELOPER = "Blurr Development";
            AppInfo.APP_VERSION = "v0.1";
            AppInfo.APP_RELEASE = Release.Alpha;
            AppInfo.APP_UPDATE_DATE = "April 12 2020";
            AppInfo.APP_WATERMARK = $"This is the {AppInfo.APP_RELEASE} version of {AppInfo.APP_NAME}. This does not represent the final product.";
            AppInfo.DISPLAY_APP_WATERMARK = true;

            Game game = new Game(AppInfo.APP_NAME, 30.0, 144.0);
        }
    }
}
