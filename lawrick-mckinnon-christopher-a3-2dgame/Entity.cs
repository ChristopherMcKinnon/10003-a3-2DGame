using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    class Renderer; // Temp
    internal class Entity
    {
        Vector2 position;
        float angle;
        Texture2D sprite;
        Vector2 velocity;
        float scale;
        bool alive;

        // Set the sprite
        public void Initialize(string filePath)
        {
            this.sprite = Graphics.LoadTexture(filePath);
        }

        public void Process() 
        {

            // Update position

            this.position.X -= velocity.X * Time.DeltaTime;
            this.position.Y -= velocity.Y * Time.DeltaTime;

            // Update rotation

            // Update scale


        }



        // SET the instance variables
        public Entity(Vector2 setPosition, float setAngle, Vector2 setVelocity, float setScale, bool isAlive) 
        {
            this.position = setPosition;
            this.angle = setAngle;
            this.velocity = setVelocity;
            this.scale = setScale;
            this.alive = isAlive;
        }
        // SET the instance variables
        public void SetPosition(Vector2 setPosition)
        {
            this.position = setPosition;
        }
        public void SetAngle(float setAngle)
        {
            this.angle = setAngle;
        }
        public void SetSprite(Texture2D setTexture)
        {
            this.sprite = setTexture;
        }
        public void SetVelocity(Vector2 setVelocity)
        {
            this.velocity = setVelocity;
        }
        public void SetScale(float setScale)
        {
            this.scale = setScale;
        }
        public void SetAlive()
        {
            this.alive = true;
        }
        public void SetDead()
        {
            this.alive = false;
            Graphics.UnloadTexture(this.sprite);
        }

        // GET the instance variables
        public Vector2 GetPosition()
        {
            return this.position;
        }
        public float GetAngle()
        {
            return this.angle;
        }
        public Texture2D GetSprite()
        {
            return this.sprite;
        }
        public Vector2 GetVelocity()
        {
            return this.velocity;
        }
        public float GetScale()
        {
            return this.scale;
        }
        public bool CheckAlive()
        {
            return alive;
        }
        public Vector2 GetFacingDirection()
        {
            // Find normalized vector based upon angle

            float radAngle = angle * (float)(Math.PI / 180);

            Vector2 facingDirection;

            facingDirection.X = (float)Math.Sin(radAngle);
            facingDirection.Y = (float)Math.Cos(radAngle);

            return facingDirection;
        }

        public void Draw() { }
    }
}
