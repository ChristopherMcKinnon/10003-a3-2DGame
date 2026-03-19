using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace MohawkGame2D
{
    internal class Bullet
    {
        public Player player;
        public Scene scene;
        public Camera camera;
        Vector2 position;
        Vector2 direction;
        float enemyDistance;
        Enemy closestEnemy;
        float bulletSpeed;
        float bulletSize;
        float bulletDamage;

        public Bullet(Player setPlayer, Scene setScene, Camera setCamera, Vector2 setPosition, Vector2 setDirection, float setBulletSpeed, float setBulletSize)
        {
            this.player = setPlayer;
            this.scene = setScene;
            this.camera = setCamera;
            this.position = setPosition;
            this.direction = setDirection;
            this.bulletSpeed = setBulletSpeed;
            this.bulletSize = setBulletSize;
        }

        public void CollisionCheck()
        {
            // Every bullet checks the nearest 1 (default) enemy and checks if it's colliding
;

            // Iterate backwards when removing elements
            for (int i = scene.liveEnemies.Count -1 ; i >= 0; i--)
            {
                this.enemyDistance = Vector2.DistanceSquared(camera.WorldCameraOffset(scene.liveEnemies[i].position), camera.WorldCameraOffset(this.position));
                float enemyRadius = scene.liveEnemies[i].size / 2;
                if (this.enemyDistance <= enemyRadius*enemyRadius)
                {
                    scene.liveEnemies.Remove(scene.liveEnemies[i]);
                    Console.WriteLine($"Enemy Killed at {scene.liveEnemies[i].position}");
                }
                
                //Console.WriteLine($"NEAREST ENEMY: {camera.WorldToScreenPos(scene.liveEnemies[i].position)}");
                //if (Vector2.DistanceSquared(this.position, scene.liveEnemies[i].position)) ;
            }

        }


        public void Update()
        {
            this.position.Y += bulletSpeed*this.direction.Y*Time.DeltaTime;
            this.position.X += bulletSpeed*this.direction.X*Time.DeltaTime;
            if (player.scene.CheckWithinBorders(this.position))
            {
                Draw.FillColor = Color.Cyan;
                Draw.Circle(player.camera.TransformVertices(this.position), this.bulletSize * player.camera.GetScale());
                this.CollisionCheck();
            }
            else 
            {
                player.liveBullets.Remove(this);
            }

            // Check outside bounds


            //Console.WriteLine(this.position);
        }
    }
}
