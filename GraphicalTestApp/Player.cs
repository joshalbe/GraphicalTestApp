using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sprite _sprite = new Sprite("Images/tankBody_dark_outline.png");
        private Turret _turret = new Turret(0, 0);

        public int _hp = 10;

        public AABB _hitbox;
        public static Player Instance;

        private Stopwatch _timer = new Stopwatch();

        float SpeedCap = 25;
        //25 - 50

        public Player(float x, float y) : base(x,y)
        {
            Instance = this;

            X = x;
            Y = y;

            AABB Hitbox = new AABB(_sprite.Height, _sprite.Width);
            _hitbox = Hitbox;
            //need specific offset

            _hitbox.X = 0;
            _hitbox.Y = 0;

            AddChild(_sprite);
            AddChild(_hitbox);
            AddChild(_turret);

            _timer.Start();

            OnUpdate += Movement;
            OnUpdate += BounceCheck;
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
            if (Input.IsKeyDown(69))
            {
                _turret.Rotate(0.75f * deltatime);
            }
            if (Input.IsKeyDown(81))
            {
                _turret.Rotate(-0.75f * deltatime);
            }
            if (Input.IsKeyDown(32))
            {
                //FIYAAAAAAAAAAAAAAAAAAAAAh
                if (_timer.ElapsedMilliseconds > 500) //100 - 1000
                {
                    _turret.Fire();
                    _timer.Restart();
                }
            }
            else if (!Input.IsKeyDown(87) && !Input.IsKeyDown(83))
            {
                XAcceleration = 0;
                if (XVelocity > 0)
                {
                    XVelocity = XVelocity - 0.005f;
                }
                else if (XVelocity < 0)
                {
                    XVelocity = XVelocity + 0.005f;
                }
                YAcceleration = 0;
                if (YVelocity > 0)
                {
                    YVelocity = YVelocity - 0.005f;
                }
                else if (YVelocity < 0)
                {
                    YVelocity = YVelocity + 0.005f;
                }
            }
        }

        public void BounceCheck(float deltatime)
        {
            if (_hitbox.Right >= 1280)
            {
                XVelocity = -XVelocity/2;
                //X = 1232;
            }
            else if (_hitbox.Left <= 0)
            {
                XVelocity = -XVelocity/2;
                //X = 6;
            }
            if (_hitbox.Bottom >= 760)
            {
                YVelocity = -YVelocity/2;
                //Y = 720;
            }
            else if (_hitbox.Top <= 0)
            {
                YVelocity = -YVelocity/2;
                //Y = 6;
            }
            foreach (VerticalWall v in WallGeneration.VerWallList1)
            {
                if (_hitbox.DetectCollision(v._hitbox))
                {
                    XVelocity = -XVelocity;
                }
            }

            foreach (HorizontalWall h in WallGeneration.HorWallList1)
            {
                if (_hitbox.DetectCollision(h._hitbox))
                {
                    YVelocity = -YVelocity;
                }
            }
            
            foreach (Enemy e in Enemy.Enemies1)
            {
                if (_hitbox.DetectCollision(e._hitbox))
                {
                    XVelocity = -XVelocity;
                    YVelocity = -YVelocity;
                }
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

        public void Damage(int damageTaken)
        {
            _hp -= damageTaken;
            if (_hp <= 0)
            {
                _parent.RemoveChild(this);
            }
        }
    }
}
