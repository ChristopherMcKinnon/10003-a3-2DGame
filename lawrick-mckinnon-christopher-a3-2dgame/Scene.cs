using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Scene
    {
        public float startScale = 1.0f;
        Vector2[] mainMenuButtonVert = [new Vector2()];
        public Camera camera;
        public Controls controls;
        public Player player;
        public Enemy[] liveEnemies = new Enemy[100];

        public Vector2[] worldBorder;

        float moveSpeed = 100f;

        /*public Scene ()
        {
            this.camera = new Camera(this, 10, 10, 10, 10);
            this.player = new Player(this, camera);
        }*/


        // Runs once at the start of the scene
    public void GameSceneInit()
        {
            // Set init variables
            this.camera = new Camera(this, 10, 10, 10, 10);
            this.player = new Player(this, camera);
            this.controls = new Controls(this, camera, player, this.moveSpeed);
            this.worldBorder = [new Vector2(-500, -500), new Vector2(500, 500)];

            // Set enemies and spawn them
            for (int i = 0; i < liveEnemies.Length; i++)
            {
                Console.WriteLine(i);
                liveEnemies[i] = new Enemy(this, this.camera, this.player);
                liveEnemies[i].RandomSpawn();
                Console.WriteLine(liveEnemies[i]);
            }
        }

        // Runs every frame
    public void GameSceneUpdate()
        {
            controls.Update();
            player.Update();
            
            // Update each enemy
            for (int i = 0; i < liveEnemies.Length; i++)
            {
                liveEnemies[i].Update();
            }


            // Temp
            Draw.Rectangle(camera.WorldToScreenPos(new Vector2(100,100)), new Vector2(30*camera.GetScale(), 30*camera.GetScale()));
            Draw.Circle(camera.WorldToScreenPos(new Vector2(-100,0)), 15f);

            
        }

        // Check if the object is within the borders of the map
     public bool CheckWithinBorders(Vector2 obj)
        {
            if (obj.X >= worldBorder[0].X && obj.Y >= worldBorder[0].Y && obj.X <= worldBorder[1].X && obj.Y <= worldBorder[1].Y) 
            {
                return true;
            } else { return false; }
        }
    public void MainMenuUpdate()
        {
            Text.Draw("Main Menu", camera.TransformVertices(new Vector2(0f,0f)));
            
        }
    }
}
