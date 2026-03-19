using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Bullet
    {
        public Player player;
        Vector2 position;
        Vector2 direction;
        float bulletSpeed;
        float bulletSize;
        float bulletDamage;

        public Bullet(Player setPlayer, Vector2 setPosition, Vector2 setDirection, float setBulletSpeed, float setBulletSize)
        {
            this.player = setPlayer;
            this.position = setPosition;
            this.direction = setDirection;
            this.bulletSpeed = setBulletSpeed;
            this.bulletSize = setBulletSize;
        }

        public void CollisionCheck()
        {
            for (int i = 0; i < player.scene.liveEnemies.Length; i++)
            {

            }
        }


        public void Update()
        {
            this.position.Y += bulletSpeed*this.direction.Y*Time.DeltaTime;
            this.position.X += bulletSpeed*this.direction.X*Time.DeltaTime;
            if (player.scene.CheckWithinBorders(this.position))
            {
                Draw.Circle(player.camera.WorldToScreenPos(this.position), this.bulletSize * player.camera.GetScale());
            }
            else 
            {
                player.liveBullets.Remove(this);
            }


            // Check outside bounds


            Console.WriteLine(this.position);
        }
    }
}
