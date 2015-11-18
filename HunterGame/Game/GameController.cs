using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Items;
using HunterGame.Game.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HunterGame
{
    public class GameController
    {
        //create player
        private Player player;
        private int maxEnemies = 10;
        private int windowHeight;
        private int windowWidth;
        private DifficultyContext diffContext;
        private SpawnerProto spawner;
        private Queue<EnemySubclass> enemyQueue;
        private List<Vector2> enemiesVector;
        private List<EnemySubclass> enemiesOnScreen;
        private Random rand = new Random();

        
        //items
        private ItemManager items;

        public List<EnemySubclass> EnemiesOnScreen
        {
            get { return enemiesOnScreen; }
        }
        public List<Vector2> EnemiesVector
        {
            get { return enemiesVector; }
        }

        public GameController (int windowX, int windowY)
        {
            
            //game controller will keep track of
            //player, enemies, score, items.
            player = new Player(3);
            diffContext = new DifficultyContext(player.PlayerScore);
            spawner = new SpawnerProto(windowX,windowY);
            enemyQueue = new Queue<EnemySubclass>();
            
            enemiesVector = new List<Vector2>();
            enemiesOnScreen = new List<EnemySubclass>();

            windowHeight = windowY;
            windowWidth = windowX;
            //initialize enemy queue
            fillEnemyQueue();
            //spawnEnemies();


            items = new ItemManager();
             
            
        }

        public void checkObjectShot(Point point)
        {
            Rectangle rect = new Rectangle(point.X, point.Y, 60, 60); //buggy at the moment, doesn't center on image.

            for (int i = enemiesOnScreen.Count - 1; i > 0; i--)
            {
                
                
                if (rect.Contains(enemiesVector[i]))
                {
                    Console.Write("Enemy shot"); //remove this later.
                    enemiesVector.Remove(enemiesVector[i]);
                    enemiesOnScreen.Remove(enemiesOnScreen[i]);
                }


            }

            //check if item shot
            if (rect.Contains(items.position))
            {
                //spawn a random item and draw to screen.
                Console.Write("Item Shot"); // remove this
                player.changeLives(items.useItem());

            }

        }

        public void fillEnemyQueue()
        {
           Dictionary<int, EnemySubclass> enemyDict =  spawner.getClonedEnemy(maxEnemies,diffContext.getState());

           foreach(int key in enemyDict.Keys)
           {
               enemyQueue.Enqueue(enemyDict[key]);
           }            
           
        }

        public void spawnEnemy()
        {
            
            if(enemyQueue.Count>0)
            {
                if(enemiesOnScreen.Count< maxEnemies)
                {
                    EnemySubclass enemy = enemyQueue.Dequeue();
                    int[] Start = enemy.getStartPos();
                    Vector2 CurrentEnemyVector = new Vector2(Start[0], Start[1]);  
                    
                    float RanDestX = rand.Next(windowWidth);
                    float RanDestY = rand.Next(windowHeight);
                    enemy.resetDestination(RanDestX, RanDestY);
                    
                        enemiesVector.Add(CurrentEnemyVector);
                        enemiesOnScreen.Add(enemy);
                   
                    
                }
            }
            else
            {
                fillEnemyQueue();
                spawnEnemy();
            }
        }
        public void updateEnemies()
        {
            
             //logic for updating enemies. loop through and set values for each

            for(int i = enemiesOnScreen.Count - 1; i > 0; i--)
            {
                
                bool remove = false;
                float RanDestX = rand.Next(windowWidth);
                float RanDestY = rand.Next(windowHeight);
                //Get our destination address

                float[] Dest = enemiesOnScreen[i].getDestination();

                //After initialize check, we check to see if the enemy has reached its destination
                //if the enemy reaches its initial destination, it then changes position
                int[] Start = enemiesOnScreen[i].getStartPos();

                int x = (int)enemiesVector[i].X;
                int y = (int)enemiesVector[i].Y;
                if (Math.Abs(x- Dest[0]) < 5 && Math.Abs(y - Dest[1]) < 5)
                {
                    if (enemiesOnScreen[i].getLocationCount() < enemiesOnScreen[i].ScreenPoints)
                    {
                        //reset for a new destination
                        enemiesOnScreen[i].resetDestination(RanDestX, RanDestY);
                        enemiesOnScreen[i].incrementLocCount();

                    }
                    else
                    {
                        player.changeLives(-1);
                        remove = true;
                    }

                }
                //adjust for x
                if (x<= Dest[0])
                {
                    x += 1;
                    enemiesVector[i] = new Vector2(x, y);
                }

                else if (x >= Dest[0])
                {
                    x -= 1;
                    enemiesVector[i] = new Vector2(x, y);

                }
                if (y <= Dest[1])
                {
                    y += 1;
                    enemiesVector[i] = new Vector2(x, y);
                }
                //adjust for y

                else if (y >= Dest[1])
                {
                    y -= 1;
                    enemiesVector[i] = new Vector2(x, y);
                }

                if (remove)
                {
                    enemiesOnScreen.RemoveAt(i);
                    enemiesVector.RemoveAt(i);
                }

            }
        }

        public Vector2 updateItem()
        {
            items.changePosition(1, 1);
            return items.getPosition();
        }

         
        public String spawnItem()
        {
            items.createRandomItem();
            return items.getImage();
            
        }
        
        public int getScore()
        {
            return player.PlayerScore.ScoreVal;
        }
        public int getLives()
        {
            return player.lives;
        }
        
    }
}
