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
        float zoomLimit = 0.4f;

        public Controls(Scene setScene, Camera setCamera, Player setPlayer, float setMoveSpeed)
        {
            this.scene = setScene;
            this.camera = setCamera;
            this.player = setPlayer;
            this.moveSpeed = setMoveSpeed;
            
        }
        public void Update()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                camera.AddPosition(new Vector2(0, -moveSpeed * Time.DeltaTime));
                //Console.WriteLine(camera.GetPosition());
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                camera.AddPosition(new Vector2(0, moveSpeed * Time.DeltaTime));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                camera.AddPosition(new Vector2(-moveSpeed * Time.DeltaTime, 0));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                camera.AddPosition(new Vector2(moveSpeed * Time.DeltaTime, 0));
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.E))
            {
                
                // Lock zoom
                if (camera.GetScale() <= scene.startScale+zoomLimit)
                {
                    camera.AddScale(0.01f);
                }
                Console.WriteLine(camera.GetScale());
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Q))
            {
                if (camera.GetScale() >= scene.startScale - zoomLimit)
                {
                    camera.AddScale(-0.01f);
                }
            }
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                player.Shoot(canShoot);
                Console.WriteLine("Shot");
            }
        }
    }
}
