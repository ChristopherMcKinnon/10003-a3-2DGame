using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Controls
    {
        public Camera camera;
        public Scene scene;
        public Player player;
        public float moveSpeed;
        public bool canShoot = true;
        public float zoomLimit = 0.4f;


        public Controls(Scene setScene, Camera setCamera, Player setPlayer)
        {
            this.scene = setScene;
            this.camera = setCamera;
            this.player = setPlayer;
            this.moveSpeed = camera.moveSpeed;
            
        }
        public void Update()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W)) // Up
            {
                camera.AddPosition(new Vector2(0, -moveSpeed * Time.DeltaTime));
                //player.Move(new Vector2(0, 1));
                //Console.WriteLine(camera.GetPosition());
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S)) // Down
            {
                camera.AddPosition(new Vector2(0, moveSpeed * Time.DeltaTime));
                //player.Move(new Vector2(0, -1));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A)) // Left
            {
                camera.AddPosition(new Vector2(-moveSpeed * Time.DeltaTime, 0));
                //player.Move(new Vector2(-1, 0));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D)) // Right
            {
                camera.AddPosition(new Vector2(moveSpeed * Time.DeltaTime, 0));
                //player.Move(new Vector2(1, 0));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.E)) // Zoom In
            {
                
                // Lock zoom
                
                if (camera.GetScale() <= scene.startScale+zoomLimit)
                {
                    camera.AddScale(0.01f);
                }
                //Console.WriteLine(camera.GetScale());
                
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Q)) // Zoom Out
            {
                if (camera.GetScale() >= scene.startScale - zoomLimit)
                {
                    camera.AddScale(-0.01f);
                }
                //Console.WriteLine(camera.GetScale());
                camera.AddScale(-0.01f);
            }
            // Shoot
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                player.Shoot(canShoot);
                //Console.WriteLine("Shot");
                //Console.WriteLine(camera.FindMouse());
            }
        }
    }
}
