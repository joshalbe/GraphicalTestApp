using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sprite _sprite = new Sprite("Images/tankBody_dark_outline.png");

        public AABB _hitbox;
        public static Player Instance;

        float SpeedCap = 25;

        public Player(float x, float y) : base(x,y)
        {
            X = x;
            Y = y;

            AABB Hitbox = new AABB(_sprite.Height, _sprite.Width);
            _hitbox = Hitbox;
            //need specific offset

            //_hitbox.X = 0;
            //_hitbox.Y = 0;

            AddChild(_sprite);
            AddChild(_hitbox);

            OnUpdate += Movement;
            //OnUpdate += BounceCheck;
            OnUpdate += SpeedCheck;
        }

        public void Movement(float deltatime)
        {
            if (Input.IsKeyDown(87))
            {
                XAcceleration = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 15;
                YAcceleration = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 15;

            }
            if (Input.IsKeyDown(83))
            {
                XAcceleration = (float)Math.Cos(GetRotation() - Math.PI * .5f) * -15;
                YAcceleration = (float)Math.Sin(GetRotation() - Math.PI * .5f) * -15;
            }
            if (Input.IsKeyDown(68))
            {
                Rotate(1f * deltatime);
            }
            if (Input.IsKeyDown(65))
            {
                Rotate(-1f * deltatime);
            }
            if (!Input.IsKeyDown(87) && !Input.IsKeyDown(83))
            {
                XAcceleration = 0;
                YAcceleration = 0;
            }
        }

        public void BounceCheck(float deltatime)
        {
            if (_hitbox.Right >= 1280)
            {
                XVelocity = 0;
                X = 1232;
            }
            else if (_hitbox.Left <= 0)
            {
                XVelocity = 0;
                X = 6;
            }
            if (_hitbox.Bottom >= 760)
            {
                YVelocity = 0;
                Y = 720;
            }
            else if (_hitbox.Top <= 0)
            {
                YVelocity = 0;
                Y = 6;
            }
        }
        
        private void SpeedCheck(float deltatime)
        {
            if (XVelocity > SpeedCap)
            {
                XVelocity = SpeedCap;
            }
            if (XVelocity < -SpeedCap)
            {
                XVelocity = -SpeedCap;
            }
            if (YVelocity > SpeedCap)
            {
                YVelocity = SpeedCap;
            }
            if (YVelocity < -SpeedCap)
            {
                YVelocity = -SpeedCap;
            }
        }
    }
}
