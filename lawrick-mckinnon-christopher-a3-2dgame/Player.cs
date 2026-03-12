using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D
{
    internal class Player : Entity
    {

        public Player() : base(new Vector2(Window.Width/2, Window.Height/2), 0.0f, new Vector2(0, 0), 1.0f, true)
        {
            //this.SetSprite(sprite);
        }

    }
}
