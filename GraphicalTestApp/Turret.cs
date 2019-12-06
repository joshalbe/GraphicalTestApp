using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Turret : Entity
    {
        private Sprite _sprite = new Sprite("Images/tankDark_barrel2_outline.png");


        public Turret(float x, float y) : base(x,y)
        {

        }

        public void Fire()
        {
            Bullet bulletOne = new Bullet(XAbsolute, YAbsolute);
            bulletOne.Rotate(GetRotation());
            bulletOne.XVelocity = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 1000;
            bulletOne.YVelocity = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 1000;

            _parent._parent.AddChild(bulletOne);
        }
    }
}
