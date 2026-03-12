using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Camera
    {
        Matrix4x4 projectionMatrix;
        Matrix4x4 viewMatrix;
        Matrix4x4 viewProjectionMatrix;

        Vector2 position;
        float rotation = 0.0f;
        float scale = 1.0f;

        public Camera(float left, float right, float bottom, float top)
        {

        }
        public Camera()
        {

        }
        
        // Get and Set methods
        public void SetPosition(Vector2 position){this.position = position;}
        public Vector2 GetPosition(){ return position; }
        public void SetRotation(float rotation){this.rotation = rotation;}
        public float GetRotation(){ return rotation;  }
        public void SetScale(float scale){this.scale = scale;}
        public float GetScale() {  return scale; }


        // Convert world to screen
        public Vector2 WorldToScreenPos(Vector2 objectPosition)  
        {
            Vector2 screenPosition;
            screenPosition.X = objectPosition.X - this.GetPosition().X + (this.GetScale() - 1.0f)*(objectPosition.X - this.GetPosition().X - Window.Width/2);
            screenPosition.Y = objectPosition.Y - this.GetPosition().Y + (this.GetScale() - 1.0f)*(objectPosition.Y - this.GetPosition().Y - Window.Height/2);


            return screenPosition;
        }
    }
}
