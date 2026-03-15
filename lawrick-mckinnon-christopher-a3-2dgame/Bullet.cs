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

        public Bullet(Player setPlayer, Vector2 setPosition, Vector2 setDirection, float setBulletSpeed, float setBulletSize)
        {
            this.player = setPlayer;
            this.position = setPosition;
            this.direction = setDirection;
            this.bulletSpeed = setBulletSpeed;
            this.bulletSize = setBulletSize;
        }
        public void Update()
        {   

            Draw.Circle(player.camera.WorldToScreenPos(this.position), this.bulletSize*player.camera.GetScale());

        }
    }
}
