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
        Vector2 closestEnemyDistance;
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

        /*public void CollisionCheck()
        {
            // Every bullet checks the nearest 1 (default) enemy and checks if it's colliding

            
            ;
            for (int i = 0; i < scene.liveEnemies.Count; i++)
            {
                Console.WriteLine($"NEAREST ENEMY: {scene.liveEnemies[i].position}");
                //if (Vector2.DistanceSquared(this.position, scene.liveEnemies[i].position)) ;
            }

        }*/


        public void Update()
        {
            this.position.Y += bulletSpeed*this.direction.Y*Time.DeltaTime;
            this.position.X += bulletSpeed*this.direction.X*Time.DeltaTime;
            if (player.scene.CheckWithinBorders(this.position))
            {
                Draw.Circle(player.camera.TransformVertices(this.position), this.bulletSize * player.camera.GetScale());
            }
            else 
            {
                player.liveBullets.Remove(this);
            }
            //this.CollisionCheck();

            // Check outside bounds


            //Console.WriteLine(this.position);
        }
    }
}
