using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Enemy
    {

        public float health;
        public float moveSpeed;
        public float size;
        public Vector2 position;
        public Vector2 direction;

        public Enemy() 
        {
            this.health = 10f;
            this.size = 30f;
            this.size = 30f;
            this.size = 30f;
        }
        public void Update()
        {
            this.position += Vector2.Normalize(direction) * moveSpeed * Time.DeltaTime;
            Draw.Square(position, size);
        }
    }
}
