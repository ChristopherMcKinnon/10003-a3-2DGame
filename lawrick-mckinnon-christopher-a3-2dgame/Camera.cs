using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Camera
    {
        
        public Vector2 position;
        public float rotation;
        public float scale;
        public int winScale = (int)MathF.Min(Window.Width, Window.Height) / 2;
        public int worldScale = 100;
        public Scene scene;


        public Camera(Scene setScene, float left, float right, float bottom, float top)
        {
            this.scene = setScene;
            this.scale = scene.startScale;
        }

        // Get and Set methods
        public void SetPosition(Vector2 setPosition) { this.position = setPosition; }
        public void AddPosition(Vector2 addPosition) { this.position += addPosition; }
        public Vector2 GetPosition() { return this.position; }
        public void SetRotation(float setRotation) { this.rotation = setRotation; }
        public void AddRotation(float addRotation) { this.rotation += addRotation; }
        public float GetRotation() { return this.rotation; }
        public void SetScale(float setScale) { this.scale = setScale; }
        public void AddScale(float addScale) { this.scale += addScale; }
        public float GetScale() { return this.scale; }


        // Convert world to screen
        public Vector2 WorldToScreenPos(Vector2 objectPosition)
        {
            Vector2 screenPosition;

            //Convert from -100,-100 to 100,100 cartesian plane first
            Vector2 transformed = this.TransformVertices(objectPosition);

            // To get the screen position, i'm taking the object - camera position
            // For scale (position) considerations, take the object - camera again and multiply the difference by the scale - 1.0f. If the scale is set as 1, then no additions are needed

            screenPosition.X = transformed.X - this.GetPosition().X + (this.GetScale() - 1.0f) * (transformed.X - this.GetPosition().X - Window.Width / 2);
            screenPosition.Y = transformed.Y - this.GetPosition().Y + (this.GetScale() - 1.0f) * (transformed.Y - this.GetPosition().Y - Window.Height / 2);


            return screenPosition;
        }
        
        public Vector2 TransformVertices(Vector2 v)
        {


            // Math is x*(w/2)+w/2  >  (x+1)(w/2)

            v.X = (v.X / worldScale + 1.0f) * this.winScale;
            v.Y = (-v.Y / worldScale + 1.0f) * this.winScale;

            return v;
        }
        public Vector2 FindMouse()
        {
            Vector2 mousePos = Input.GetMousePosition();
            

            mousePos = mousePos / new Vector2(this.winScale*2, this.winScale*2) * 200;
            mousePos -= new Vector2(100f, 100f);
            mousePos.Y *= -1;
            return mousePos;
        }


    }
}