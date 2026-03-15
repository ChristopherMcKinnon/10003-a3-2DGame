using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Player
    {
        public Scene scene;
        public Camera camera;

        Texture2D sprite1;
        Texture2D sprite2;
        Texture2D currentSprite;

        Vector2 playerPos;
        public List<Bullet> liveBullets = new List<Bullet>();



        int bulletCount;

        float bulletSpeed;
        float bulletSize;
        
        public Player(Scene setScene, Camera setCamera)
        {
            this.camera = setCamera;
            this.scene = setScene;
            this.sprite1 = Graphics.LoadTexture("C:\\Users\\Abstrxcted\\source\\repos\\10003-a3-2DGame\\lawrick-mckinnon-christopher-a3-2dgame\\Assets\\survivor-knife.png");
            this.sprite2 = Graphics.LoadTexture("C:\\Users\\Abstrxcted\\source\\repos\\10003-a3-2DGame\\lawrick-mckinnon-christopher-a3-2dgame\\Assets\\survivor-gun.png");
            this.currentSprite = sprite1;
            this.playerPos = new Vector2(0, 0);
            this.bulletCount = 4;
            this.bulletSpeed = 0.5f;
            this.bulletSize = 100;
        }

        public void Shoot(bool canShoot)
        {
            if (canShoot)
            {
                Vector2 mousePos = Input.GetMousePosition();
                for (int i = 0; i < this.bulletCount; i++)
                {
                    liveBullets.Add(new Bullet(this, playerPos, Vector2.Normalize(mousePos-playerPos), bulletSpeed, bulletSize));
                }
            }
        }
        public void Update()
        {
            Vector2 mousePos = Input.GetMousePosition();
            /*
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                Console.WriteLine(mousePos);
                Console.WriteLine(camera.InverseTransformVertices(mousePos));
            }

            Graphics.Rotation += 10;*/
            //Console.WriteLine(Math.Acos(Vector2.Dot(camera.InverseTransformVertices(mousePos), new Vector2(0, 0))));
            Graphics.Scale = 0.5f;
            
            Graphics.Draw(currentSprite, camera.TransformVertices(playerPos), camera.TransformVertices(playerPos));
            Graphics.Scale = 1f;

            for (int i = 0; i < liveBullets.Count; i++)
            {
                liveBullets[i].Update();
            }
        }
        public void setCamera(Camera setCamera) { this.camera = setCamera; }
        public Camera getCamera() { return this.camera; }
    }
}
