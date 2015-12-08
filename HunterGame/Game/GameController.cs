using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HunterGame.Game.Items;
using HunterGame.Game.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        private List<Vector2> enemiesVector;
        private List<EnemySubclass> enemiesOnScreen;
        private Random rand = new Random();

        private double elapsedTime;
        public string notification { get; set;}
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

        public bool itemAppeared { get; set; }

        public GameController (int windowX, int windowY)
        {
            
            //game controller will keep track of
            //player, enemies, score, items.
            player = new Player(3);
            diffContext = new DifficultyContext(player.PlayerScore);
            player.PlayerScore.register(diffContext);
            spawner = new SpawnerProto(windowX,windowY);
            
            enemiesVector = new List<Vector2>();
            enemiesOnScreen = new List<EnemySubclass>();

            notification = "";
            
            
            windowHeight = windowY;
            windowWidth = windowX;

            items = new ItemManager();
            itemAppeared = false;

            elapsedTime = 0;
        }

        public void checkObjectShot(Point point)
        {
            bool enemyShot = false;
            Rectangle rect = new Rectangle(point.X-60, point.Y-60, 120, 120);

            if (player.canShoot())
            {
                player.shoot();
                
                for (int i = enemiesOnScreen.Count - 1; i > 0; i--)
                {

                    if (rect.Contains(enemiesVector[i]) && !enemyShot)
                    {
                        
                        player.PlayerScore.gainScore(enemiesOnScreen[i].KillWorth);
                        enemiesVector.Remove(enemiesVector[i]);
                        enemiesOnScreen.Remove(enemiesOnScreen[i]);

                        //prevents multiple enemies and items from being shot.
                        enemyShot = true;
                        

                    }


                }


                if (rect.Contains(items.getPosition()) && !enemyShot)
                {

                    //spawn a random item and draw to screen.                
                    IItem item = items.getItem();
                    player.changeLives(item.increaseLives());
                    
                    player.powerUp(item.powerUp());
                    player.stun(item.stun());
                    player.increaseMaxAmmo(item.weaponUpgrade());

                    
                    //destroy item
                    itemAppeared = false;
                }

                
            }

      





        }

      

        public void spawnEnemy()
        {
            
            if(enemiesOnScreen.Count< maxEnemies)
            {
                EnemySubclass enemy = spawner.spawnEnemy(diffContext.getState());
                int[] Start = enemy.getStartPos();
                Vector2 CurrentEnemyVector = new Vector2(Start[0], Start[1]);  
                    
                enemy.Destination = createDestination(Start[0],Start[1]);
                    
                    enemiesVector.Add(CurrentEnemyVector);
                    enemiesOnScreen.Add(enemy);
                   
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


                //get the current position of the enemy
                Vector2 start = enemiesVector[i];               

                //get the destination of the enemy
                Vector2 dest = enemiesOnScreen[i].Destination;
                
                //check if the enemy is near the boundary
                if (Math.Abs(start.X- dest.X) < 5 && Math.Abs(start.Y - dest.Y) < 5)
                {
                    if (enemiesOnScreen[i].getLocationCount() < enemiesOnScreen[i].ScreenPoints)
                    {
                        //reset for a new destination
                        enemiesOnScreen[i].Destination = createDestination(dest.X, dest.Y);
                        enemiesOnScreen[i].incrementLocCount();

                    }
                    else
                    {
                        //if the enemy goes off screen lose a life.
                        player.changeLives(-1);
                        remove = true;
                    }

                }
                //the enemies speed 
                float speed = enemiesOnScreen[i].Speed;
                
                //Vector2 end = enemiesOnScreen[i].Destination;
                float distance = Vector2.Distance(start,dest);
                //calculate the direction of the enemy (how far to travel in each direction to move a distance of 1 closer to the destination)
                Vector2 direction = Vector2.Normalize(dest - start);

                //get move the enemy closer to the destination (the value of speed units closer)
                enemiesVector[i] += direction * speed;
                //check if the enemy has moved beyond its destination
                if (Vector2.Distance(start, enemiesVector[i]) >= distance)
                {
                    enemiesVector[i] = dest;
                       
                }
                
                //if the enemy has reached its max 
                if (remove)
                {
                    enemiesOnScreen.RemoveAt(i);
                    enemiesVector.RemoveAt(i);
                }

            }
        }

        //randomly generate destination
        public Vector2 createDestination(float currX, float currY)
        {

            Random rand = new Random();
            Vector2 dest = new Vector2();

            int currDirect;

            //determine which edge the enemy just came from (so it doesn't go back to the same edge)
            if(currX ==0)
            {
                currDirect = 0;
            }
            else if(currX==windowWidth)
            {
                currDirect = 2;
            }
            else if(currY ==0)
            {
                currDirect = 1;
            }
            else
            {
                currDirect = 3;
            }
            

            int edge;
            //loop until the random is a new edge
            do
            {
                edge = rand.Next(3);
            } while (edge == currDirect);

            //set the value of the vector depending on which edge was chosen
            switch(edge){
                case 0:
                    dest.X = 0;
                    dest.Y = rand.Next(windowHeight);
                    break;
                case 1:
                    dest.X = rand.Next(windowWidth);
                    dest.Y =0;
                    break;
                case 2:
                    dest.X = windowWidth;
                    dest.Y = rand.Next(windowHeight);
                    break;
                default:
                    dest.X = rand.Next(windowWidth);
                    dest.Y = windowHeight;
                    break;
            };


            return dest;
            
        }

        
        public void startNewGame()
        {
            //game controller will keep track of
            //player, enemies, score, items.
            player.newGame(3);
            //diffContext = new DifficultyContext(player.PlayerScore);
            //player.PlayerScore.register(diffContext);
            //spawner = new SpawnerProto(windowHeight, windowWidth);

            enemiesVector.Clear();
            enemiesOnScreen.Clear();

            notification = "";

            items = new ItemManager();
            itemAppeared = false;

            elapsedTime = 0;
        }

        public void quitGame()
        {
           
        }

        public Vector2 updateItem()
        {
            items.changePosition();
            return items.getPosition();
        }

         
        public String spawnItem()
        {
            items.createRandomItem();
            itemAppeared = true;
            return items.getImage();
            
        }
        public Boolean checkLives()
        {
            return (player.lives>0);
        }
        
        public int getScore()
        {
            return player.PlayerScore.ScoreVal;
        }

        public string getAmmo()
        {
            return player.ammo.ToString();
        }
        public int getLives()
        {
            return player.lives;
        }

       public void setTime(double time)
        {
            elapsedTime = time;
        }

        public void updatePlayer()
        {

            player.update(elapsedTime);
            this.notification = player.getState();

        }




    }
}
