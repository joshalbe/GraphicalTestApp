using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sprite _sprite = new Sprite("png/default_size/tankBody_dark_outline");

        public AABB _hitbox;
        public static Player Instance;

        public Player(float x, float y) : base(x,y)
        {
            X = x;
            Y = y;

            AABB Hitbox = new AABB(_sprite.Height, _sprite.Width);
            _hitbox = Hitbox;
            //need specific offset
            _hitbox.X = 0;
            _hitbox.Y = 0;

            AddChild(_sprite);
            AddChild(_hitbox);

        }

        public void Movement(float deltatime)
        {
            if (Input.IsKeyDown(87))
            {
                XAcceleration = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 300;
                YAcceleration = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 300;

            }
            if (Input.IsKeyDown(68))
            {
                Rotate(1f * deltatime);
            }
            if (Input.IsKeyDown(65))
            {
                Rotate(-1f * deltatime);
            }
            else
            {
                XAcceleration = 0;
                YAcceleration = 0;
            }
        }
    }
}
