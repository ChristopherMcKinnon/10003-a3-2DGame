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
        float moveSpeed = 100f;

        /*public Scene ()
        {
            this.camera = new Camera(this, 10, 10, 10, 10);
            this.player = new Player(this, camera);
        }*/
    public void GameSceneInit()
        {
            this.camera = new Camera(this, 10, 10, 10, 10);
            this.player = new Player(this, camera);
            this.controls = new Controls(this, camera, player, this.moveSpeed);
        }
    public void GameSceneUpdate()
        {
            controls.Update();
            player.Update();
            Draw.Rectangle(camera.WorldToScreenPos(new Vector2(100,100)), new Vector2(30*camera.GetScale(), 30*camera.GetScale()));
        }
    public void MainMenuUpdate()
        {
            Text.Draw("Main Menu", camera.TransformVertices(new Vector2(0f,0f)));
            
        }
    }
}
