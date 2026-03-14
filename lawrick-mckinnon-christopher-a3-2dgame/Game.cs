using System;
using System.Numerics;


namespace MohawkGame2D
{
    
    public class Game
    {

        Camera cam;
        Vector2 squarePos = new(400, 300);
        Vector2 squareSize = new(25, 25);
        string groundTexture = "C:\\Users\\Abstrxcted\\source\\repos\\10003-a3-2DGame\\lawrick-mckinnon-christopher-a3-2dgame\\Assets\\orb.png";
        Entity floor = new Entity(new Vector2(400, 300), 0.0f, new Vector2(0, 0), 1.0f, true);
        // Place your variables here:

        Vector2 canvasSize = new Vector2(800, 600);
        int targetFPS = 60;
        Scene currentScene;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("2D Game");
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;


            // Load sprites
            for (int i = 0; i < spriteNames.Length; i++)
            {
                // Display loading textures
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Loading asset #{i+1}, {spriteNames[i]}...");
                Console.ForegroundColor = ConsoleColor.White;
                // Load each texture
                Graphics.LoadTexture(assetPath + spriteNames[i]);
            }

            BeginScene();



        }

        public void BeginScene()
        {
            cam = new Camera(10, 10, 10, 10);
            cam.SetPosition(new Vector2(20,20));
            cam.SetScale(1.0f);

            floor.Initialize(groundTexture);

        }
        public void Render(int spacing)
        {
            
            // Grid
            Draw.LineSize = 1;
            Draw.LineColor = new Color(255, 0, 0);
            for (int i = 0; i < (Window.Width + Window.Width); i += spacing)
            {
                Draw.Line(i, 0, i, Window.Height);
            }
            for (int i = 0; i < (Window.Height + Window.Height); i += spacing)
            {
                Draw.Line(0, i, Window.Width, i);
            }

            // Camera
            Draw.LineColor = Color.Blue;
            Draw.Circle(cam.GetPosition(), 5f);



            
        }
        public void ControlsUpdate()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                cam.SetPosition(cam.GetPosition() + new Vector2(0, 1));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                cam.SetPosition(cam.GetPosition() + new Vector2(0, -1));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                cam.SetPosition(cam.GetPosition() + new Vector2(-1, 0));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                cam.SetPosition(cam.GetPosition() + new Vector2(1, 0));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.E))
            {
                cam.SetScale(cam.GetScale()+0.01f);
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Q))
            {
                cam.SetScale(cam.GetScale()-0.01f);
            }
        }
        public void Update()
        {
            Window.ClearBackground(Color.Black);
            
            Render(40);
            ControlsUpdate();
        }
    }

}
