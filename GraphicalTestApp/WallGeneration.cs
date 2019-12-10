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
                if (i % 2 == 0)
                {
                    HorizontalWall _wallH = new HorizontalWall(46 + (54 * i), 100);
                    AddChild(_wallH);
                }
            }

            for (int i = 1; i < 22; i++)
            {
                if (i % 2 == 0)
                {
                    HorizontalWall _wallH = new HorizontalWall(46 + (54 * i), 676);
                    AddChild(_wallH);
                }
            }
            
            for (int i = 1; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    VerticalWall _wallV = new VerticalWall(82, 100 + (54 * i));
                    AddChild(_wallV);
                }
            }

            for (int i = 1; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    VerticalWall _wallV = new VerticalWall(1180, 100 + (54 * i));
                    AddChild(_wallV);
                }
            }


            //Level 1

            for (int i = 1; i < 10; i++)
            {
                if (i == 9)
                {
                    VerticalWall _wallV = new VerticalWall(800, 100 + (54 * i));
                    AddChild(_wallV);
                }
                if (i%2 == 0)
                {
                    VerticalWall _wallV = new VerticalWall(500, 100 + (54 * i));
                    AddChild(_wallV);
                }
            }

            for (int i = 1; i < 22; i++)
            {
                if (i > 1 && i < 7 && i%2 == 0)
                {
                    HorizontalWall _wallH = new HorizontalWall(46 + (54 * i), 500);
                    AddChild(_wallH);
                }
            }

            for (int i = 1; i < 22; i++)
            {
                if (i > 15 && i < 21 && i % 2 == 0)
                {
                    HorizontalWall _wallH = new HorizontalWall(46 + (54 * i), 400);
                    AddChild(_wallH);
                }
            }
        }
    }
}
