﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Sprite _sprite = new Sprite("Images/bulletDark1_outline.png");
        public AABB _hitbox;
        
        public Bullet(float x, float y) : base(x, y)
        {

            X = x;
            Y = y;

            AABB hitbox = new AABB(_sprite.Width, _sprite.Height);

            _hitbox = hitbox;

            AddChild(hitbox);
            AddChild(_sprite);

            _hitbox.X = XAbsolute;
            _hitbox.Y = YAbsolute;

            OnUpdate += BulletCollide;
            OnUpdate += DeletBullet;
        }

        private void BulletCollide(float deltatime)
        {
            foreach (VerticalWall v in WallGeneration.VerWallList1)
            {
                if (_hitbox.DetectCollision(v._hitbox))
                {
                    
                    _parent.RemoveChild(this);
                }
            }
            
            foreach (HorizontalWall h in WallGeneration.HorWallList1)
            {
                if (_hitbox.DetectCollision(h._hitbox))
                {
                    
                    _parent.RemoveChild(this);
                }
            }

            foreach (Enemy e in Enemy.Enemies1)
            {
                if (_hitbox.DetectCollision(e._hitbox))
                {
                    e.Damage(1);
                    _parent.RemoveChild(this);
                }
            }
        }

        public void DeletBullet(float deltatime)
        {
            if (_hitbox.Right >= 1300)
            {
                _parent.RemoveChild(this);
            }
            else if (_hitbox.Left <= -100)
            {
                _parent.RemoveChild(this);
            }
            if (_hitbox.Bottom >= 800)
            {
                _parent.RemoveChild(this);
            }
            else if (_hitbox.Top <= -100)
            {
                _parent.RemoveChild(this);
            }
        }
    }

    class EnemyBullet : Entity
    {
        private Sprite _sprite = new Sprite("Images/bulletRed2_outline.png");
        public AABB _hitbox;
        
        public EnemyBullet(float x, float y) : base(x, y)
        {

            X = x;
            Y = y;

            AABB hitbox = new AABB(_sprite.Width, _sprite.Height);

            _hitbox = hitbox;

            AddChild(hitbox);
            AddChild(_sprite);

            _hitbox.X = XAbsolute;
            _hitbox.Y = YAbsolute;

            OnUpdate += BulletCollide;
            OnUpdate += DeletBullet;
        }

        private void BulletCollide(float deltatime)
        {
            foreach (VerticalWall v in WallGeneration.VerWallList1)
            {
                if (_hitbox.DetectCollision(v._hitbox))
                {

                    _parent.RemoveChild(this);
                }
            }

            foreach (HorizontalWall h in WallGeneration.HorWallList1)
            {
                if (_hitbox.DetectCollision(h._hitbox))
                {

                    _parent.RemoveChild(this);
                }
            }

            if (_hitbox.DetectCollision(Player.Instance._hitbox))
            {
                Player.Instance.Damage(1);
                _parent.RemoveChild(this);
            }

        }

        public void DeletBullet(float deltatime)
        {
            if (_hitbox.Right >= 1300)
            {
                _parent.RemoveChild(this);
            }
            else if (_hitbox.Left <= -100)
            {
                _parent.RemoveChild(this);
            }
            if (_hitbox.Bottom >= 800)
            {
                _parent.RemoveChild(this);
            }
            else if (_hitbox.Top <= -100)
            {
                _parent.RemoveChild(this);
            }
        }
    }
}
