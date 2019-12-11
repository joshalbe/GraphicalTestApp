using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class HorizontalWall : Entity
    {
        private Sprite _sprite = new Sprite("Images/sandbagBeige.png");
        public AABB _hitbox;

        public HorizontalWall(float x, float y) : base(x,y)
        {
            _hitbox = new AABB(_sprite.Width, _sprite.Height);

            AddChild(_hitbox);
            AddChild(_sprite);

            _sprite.X = XAbsolute - 53;
            _sprite.Y = YAbsolute - 35;

            WallGeneration.HorWallList1.Add(this);
        }
    }

    class VerticalWall : Entity
    {
        private Sprite _sprite = new Sprite("Images/sandbagBeigeUp.png");
        public AABB _hitbox;

        public VerticalWall(float x, float y) : base(x, y)
        {
            _hitbox = new AABB(_sprite.Width, _sprite.Height);

            AddChild(_hitbox);
            AddChild(_sprite);

            //_hitbox.X = X;
            //_hitbox.Y = Y;

            _sprite.X = XAbsolute - 35;
            _sprite.Y = YAbsolute - 53;

            WallGeneration.VerWallList1.Add(this);
        }
    }
}
