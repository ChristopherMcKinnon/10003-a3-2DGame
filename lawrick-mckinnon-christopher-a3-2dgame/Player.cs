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
        float bulletSpread;

        float playerSize = 50f;

        public Player(Scene setScene, Camera setCamera)
        {
            this.camera = setCamera;
            this.scene = setScene;
            this.sprite1 = Graphics.LoadTexture("../../../../../10003-a3-2DGame/lawrick-mckinnon-christopher-a3-2dgame/Assets/survivor-knife.png");
            this.sprite2 = Graphics.LoadTexture("../../../../../10003-a3-2DGame/lawrick-mckinnon-christopher-a3-2dgame/Assets/survivor-gun.png");
            this.currentSprite = sprite2;
            this.playerPos = camera.TransformVertices(new Vector2(0, 0));
            this.bulletCount = 4;
            this.bulletSpeed = 500f;
            this.bulletSize = 10f;
            this.bulletSpread = 0.2f; // Lower the greater the spread
        }

        public void Shoot(bool canShoot)
        {
            if (canShoot)
            {
                Vector2 mousePos = camera.FindMouse();
                for (int i = 0; i < this.bulletCount; i++)
                {
                    liveBullets.Add(
                        new Bullet(
                            this,
                            playerPos,
                            Vector2.Normalize(Random.Vector2(mousePos*bulletSpread, mousePos/bulletSpread)),
                            this.bulletSpeed,
                            this.bulletSize));
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
            Graphics.Scale = camera.GetScale()/2;
            Graphics.Draw(currentSprite, playerPos, playerPos);

            Draw.Square(playerPos-new Vector2(playerSize/2, playerSize/2), playerSize);
            for (int i = 0; i < liveBullets.Count; i++)
            {
                liveBullets[i].Update();
            }
        }
        public void setCamera(Camera setCamera) { this.camera = setCamera; }
        public Camera getCamera() { return this.camera; }
    }
}
