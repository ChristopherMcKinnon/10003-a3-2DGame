// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        int[] windowSize = [600, 600];
        Scene scene = new Scene();
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(windowSize[0], windowSize[1]);
            Window.SetTitle("2D Game");
            Window.TargetFPS = 60;
            scene.GameSceneInit();
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            scene.GameSceneUpdate();

        }
    }

}
