using System;
using System.Numerics;


namespace MohawkGame2D
{
    
    public class Game
    {

        Camera cam;
        Vector2 squarePos = new(400, 300);
        Vector2 squareSize = new(25, 25);

        public void Setup()
        {
            Window.SetTitle("2D Game");
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;

            BeginScene();
        }

        public void BeginScene()
        {
            cam = new Camera(10, 10, 10, 10);
            cam.SetPosition(new Vector2(20,20));
            cam.SetScale(1.0f);
        }
        public void Render(int spacing)
        {
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

            Draw.LineColor = Color.Blue;
            Draw.Circle(cam.GetPosition(), 5f);

            Draw.Rectangle(cam.WorldToScreenPos(squarePos), squareSize*cam.GetScale());


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
