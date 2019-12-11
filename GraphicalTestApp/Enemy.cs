using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Enemy : Entity
    {
        private Sprite _sprite = new Sprite("Images/enemyTank.png");
        private EnemyTurret _turret1 = new EnemyTurret(-10, 0);
        private EnemyTurret _turret2 = new EnemyTurret(10, 0);

        public int _hp = 10;

        public AABB _hitbox;

        public static List<Enemy> Enemies1 = new List<Enemy>();
        public static List<Enemy> Enemies2 = new List<Enemy>();
        public static List<Enemy> Enemies3 = new List<Enemy>();
        public static List<Enemy> Enemies4 = new List<Enemy>();
        public static List<Enemy> Boss = new List<Enemy>();

        public static List<Enemy> removals = new List<Enemy>();

        private Stopwatch _timer = new Stopwatch();

        public Enemy(float x, float y) : base(x,y)
        {

            X = x;
            Y = y;

            AABB Hitbox = new AABB(_sprite.Height, _sprite.Width);
            _hitbox = Hitbox;

            _hitbox.X = 0;
            _hitbox.Y = 0;

            AddChild(_sprite);
            AddChild(_hitbox);
            AddChild(_turret1);
            AddChild(_turret2);

            _timer.Start();

            Enemies1.Add(this);

            OnUpdate += Movement;
            //OnUpdate += Damage;
        }

        public void Movement(float deltatime)
        {
            
            Rotate(1f * deltatime);
            

            if (_timer.ElapsedMilliseconds > 600)
            {
                _turret1.Fire();
                _turret2.Fire();
                _timer.Restart();
            }
        }

        public void Damage(int damageTaken)
        {
            _hp -= damageTaken;
            if (_hp <= 0)
            {
                //Number++
                X = 9000;
                Y = 9000;
                _parent.RemoveChild(this);
                
            }
        }
    }
}
