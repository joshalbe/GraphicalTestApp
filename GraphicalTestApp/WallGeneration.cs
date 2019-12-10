using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class WallGeneration : Actor
    {
        public static List<HorizontalWall> HorWallList = new List<HorizontalWall>();
        public static List<VerticalWall> VerWallList = new List<VerticalWall>();

        public WallGeneration()
        {

            for (int i = 1; i < 22; i++)
            {
                HorizontalWall _wallH = new HorizontalWall(46 + (54 * i), 100);
                AddChild(_wallH);
            }

            for (int i = 1; i < 22; i++)
            {
                HorizontalWall _wallH = new HorizontalWall(46 + (54 * i), 676);
                AddChild(_wallH);
            }

            //VerticalWall _wall2 = new VerticalWall(82, 154);

            for (int i = 1; i < 11; i++)
            {
                VerticalWall _wallV = new VerticalWall(82, 100 + (54 * i));
                AddChild(_wallV);
            }
        }
    }
}
