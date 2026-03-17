using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Enemy
    {
        public Scene scene;
        public Camera camera;
        public Player player;

        public float health;
        public float moveSpeed;
        public float size;
        public Vector2 position;
        public Vector2 direction;

        public Enemy(Scene setScene, Camera setCamera, Player setPlayer) 
        {
            this.scene = setScene;
            this.camera = setCamera;
            this.player = setPlayer;

            this.health = 10f;
            this.moveSpeed = 10f;
            this.size = 30f;
        }

        public void Spawn(Vector2 location)
        {
            this.position = location;
        }
        public Vector2 SetRandomSpawn()
        {
            return Random.Vector2(scene.worldBorder[0], scene.worldBorder[1]);
        }
        public void RandomSpawn()
        {
            Vector2 randomSpawn = this.SetRandomSpawn();
            while (!scene.CheckWithinBorders(randomSpawn))
            {
                randomSpawn = this.SetRandomSpawn();
                
            }
            this.Spawn(randomSpawn);
        }

        public void Update()
        {
            this.direction = player.playerScreenPos - this.position;
            this.position += Vector2.Normalize(direction) * moveSpeed * Time.DeltaTime;
            Draw.Square(camera.WorldToScreenPos(position), size);
        }
    }
}
