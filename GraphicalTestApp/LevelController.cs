using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class LevelController : Actor
    {
        Actor Root;
        Actor level1 = new Actor();
        Actor level2 = new Actor();
        Actor level3 = new Actor();
        Actor level4 = new Actor();
        Actor levelBoss = new Actor();

        float currentLevel = 1;

        public LevelController(Actor root)
        {
            Root = root;

            GameStart();

            OnUpdate += WinCondition;
        }

        public void GameStart()
        {
            Sprite background = new Sprite("Images/tileSand1.png");
            background.X = 0;
            background.Y = 0;

            
            Root.AddChild(level1);

            //## Set up game here ##//
            Player player = new Player(1100, 600);
            Enemy enemy1 = new Enemy(300, 300);
            Enemy enemy2 = new Enemy(1050, 200);
            Enemy enemy3 = new Enemy(200, 550);
            WallGeneration _walls = new WallGeneration();

            level1.AddChild(background);
            level1.AddChild(player);
            level1.AddChild(enemy1);
            level1.AddChild(enemy2);
            level1.AddChild(enemy3);
            level1.AddChild(_walls);
        }

        public void WinCondition(float deltatime)
        {
            //if (Number >= 0) {thing}
            if (Enemy.Boss.Count == 0)
            {
                Root.RemoveChild(levelBoss);
            }
            else if (Enemy.Enemies4.Count == 0)
            {
                Root.RemoveChild(level4);
                Root.AddChild(levelBoss);
            }
            else if (Enemy.Enemies3.Count == 0)
            {
                Root.RemoveChild(level3);
                Root.AddChild(level4);
            }
            else if (Enemy.Enemies2.Count == 0)
            {
                Root.RemoveChild(level2);
                Root.AddChild(level3);
            }
            else if (Enemy.Enemies1.Count == 0)
            {
                Root.RemoveChild(level1);
                Root.AddChild(level2);
            }
        }
    }
}
