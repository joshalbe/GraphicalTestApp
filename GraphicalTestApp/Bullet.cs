using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Sprite _sprite = new Sprite("png/default_size/bulletdark1_outline");
        AABB Hitbox;

        public Bullet(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;

            AABB hitbox = new AABB(_sprite.Width, _sprite.Height);

            Hitbox = hitbox;

            AddChild(hitbox);
            AddChild(_sprite);

            
        }
    }
}
