using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HunterGame.Game.Items;
using System.Collections.Generic;

namespace HunterGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Hunter : Microsoft.Xna.Framework.Game
    {
        Random Ran;
        //iterator for enemies in update
        int iterator = 0;
        //Dictionary for containing enemy spawns
       
        List<Vector2> EnemyVectors = new List<Vector2>();
        SpawnerProto Proto;
        //Vector's for First 5 enemies
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameController controller;

        KeyboardState currentKeyboardState, oldKeyboardState;
        MouseState currentMouseState, oldMouseState;

        //Strings for sprite drawings
        String gOver = "Game Over";
        String nGame = "New Game";
        String exit = "Exit";
        String pause = "PAUSED!";

        //mouse position and sprite
        private Vector2 cursor;
        private Texture2D crosshair;
        private Vector2 scoreVector;
        private Vector2 livesVector;
        private Vector2 notificationVector;

        private Vector2 pauseVector;
        private Vector2 pauseSize;

        private Vector2 ammoVector;
        private Vector2 gameOverVector;
        private Vector2 gameOverSize;

        private Vector2 newGameVector;
        private Vector2 newGameSize;
        private Vector2 quitGameVector;
        private Vector2 quitGameSize;

        Rectangle newGameRect;
        Rectangle quitGameRect; 

        //pause
        bool paused;
        bool pauseKeyDown;
        
        //enemies
        Texture2D EnemyImage;

        //items
        Texture2D itemImage;
        Vector2 itemVector;

        //background
        Texture2D Background;

        //use item
        Player player;

        SpriteFont font;

        SpriteFont MenuFont;

        SpriteFont titleFont;
        SpriteFont ammoFont;

        //player status
        SpriteFont playerNotificationFont;
        double enemySpawnTime = 0;
        double itemSpawnTime = 0;

        ItemManager items;

        //pauses between clicks
        double mouseClickRefresh = 0;

        //elapsedTime to report to other classes
        double elapsedtime;
        public Hunter()
        {
            //sets up window and Game
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1080;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //our height and width of screen
            int height = graphics.GraphicsDevice.Viewport.Height;
            int width = graphics.GraphicsDevice.Viewport.Width;
            Ran = new Random();
            //use item
            player = new Player(3);
            //Handles game logic separate from Rendering
            controller = new GameController(graphics.GraphicsDevice.PresentationParameters.Bounds.Width, graphics.GraphicsDevice.PresentationParameters.Bounds.Height);
            //mouse and keyboard states
            currentKeyboardState = new KeyboardState();
            currentMouseState = new MouseState();

            //initialize cursor
            cursor = new Vector2(width, height);
            paused = false;
            pauseKeyDown = false;


            scoreVector = new Vector2(width - 150, height - 40);
            livesVector = new Vector2(width - 300, height - 40);
            scoreVector = new Vector2(width - 450, height - 40);
            notificationVector = new Vector2(width - 850, height - 40);
            ammoVector = new Vector2(width - 1050 , height - 40);
            //gameOverVector = new Vector2(width / 2.0f - 75, height / 4.0f);
            //newGameVector = new Vector2(width / 2.0f - 75, height / 2.0f);
            //quitGameVector = new Vector2(width / 2.0f-10 , height / 2.0f + 75);
            

            elapsedtime = 0.0;

            //newGameRect = new Rectangle((int)newGameVector.X-10, (int)newGameVector.Y+5, 230, 50);
            //quitGameRect = new Rectangle((int)quitGameVector.X-10, (int)quitGameVector.Y+5, 100, 50);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //our height and width of screen
            int height = graphics.GraphicsDevice.Viewport.Height;
            int width = graphics.GraphicsDevice.Viewport.Width;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            crosshair = Content.Load<Texture2D>("Graphics\\circle-03");
            font = Content.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>("SpriteFont1");
            MenuFont = Content.Load<SpriteFont>("Graphics\\MenuFont");

            //We instantiate these vectors in here Because the pauseSize can only be used AFTER the MenuFont has been loaded
            pauseSize = MenuFont.MeasureString(pause);
            gameOverSize = MenuFont.MeasureString(gOver);
            newGameSize = MenuFont.MeasureString(nGame);
            quitGameSize = MenuFont.MeasureString(exit);

            pauseVector = new Vector2((width / 2) - (pauseSize.X / 2), height - (int) (.75 * (double) height));
            gameOverVector = new Vector2((width / 2) - (gameOverSize.X / 2), height - (int)(.75 * (double)height));
            newGameVector = new Vector2((width / 2) - (newGameSize.X / 2), height - (int)(.60 * (double)height));
            quitGameVector = new Vector2((width / 2) - (quitGameSize.X / 2), height - (int)(.45 * (double)height));

            newGameRect = new Rectangle((int)newGameVector.X - 10, (int)newGameVector.Y + 5, 230, 50);
            quitGameRect = new Rectangle((int)quitGameVector.X - 10, (int)quitGameVector.Y + 5, 100, 50);

            //for enemies
            //player notification
            playerNotificationFont = Content.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>("SpriteFont1");
            ammoFont = Content.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>("SpriteFont1");
            titleFont = Content.Load<SpriteFont>("TitleFont");
            EnemyImage = Content.Load<Texture2D>("Graphics\\rubber-duck-icon");

            //load background
            Background = Content.Load<Texture2D>("Graphics\\background");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
            oldKeyboardState = currentKeyboardState;
            oldMouseState = currentMouseState;
            elapsedtime += gameTime.ElapsedGameTime.TotalSeconds;
            controller.setTime(elapsedtime);
            //mouse
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            //update mouse sprite position.  Image is drawn from bottom right so we subtract
            cursor.X = currentMouseState.X - (crosshair.Width / 2);
            cursor.Y = currentMouseState.Y - (crosshair.Height / 2);

            //check for a paused key press.
            //paused = checkPauseKey(currentKeyboardState);
            checkPauseKey(currentKeyboardState);
            
            // If the user hasn't paused, Update normally
            if (paused)
            {
                base.Update(gameTime);

            }
            else if(controller.checkLives())
            {
                
                enemySpawnTime += gameTime.ElapsedGameTime.TotalSeconds;
                itemSpawnTime += gameTime.ElapsedGameTime.TotalSeconds;

           
                controller.updateEnemies();
                EnemyVectors = controller.EnemiesVector;

                enemySpawnTime += gameTime.ElapsedGameTime.TotalSeconds;
                if (enemySpawnTime > 2)
                {
                    controller.spawnEnemy();
                    enemySpawnTime = 0;
                }

                controller.updateEnemies();
                EnemyVectors = controller.EnemiesVector;

                if (itemSpawnTime > 30)
                {
                    String imageLocation = controller.spawnItem();
                    itemImage = Content.Load<Texture2D>(imageLocation);
                    itemSpawnTime = 0;
                }
                controller.updatePlayer();
                //check if mouse click
                if (currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    
                        Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);
                        //check if an object was shot
                        controller.checkObjectShot(mousePosition);
                    

                    
                }
                //update player on current game time
                
                base.Update(gameTime);
                
            }
            else
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {

                    Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);
                    //check if an object was shot
                    
                    if(newGameRect.Contains(mousePosition))
                    {
                        controller.startNewGame();
                        EnemyVectors.Clear();
                    }
                    else if(quitGameRect.Contains(mousePosition))
                    {
                        Exit();
                    }
                   



                }

            }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //draw the background first
            spriteBatch.Draw(Background, new Rectangle(0, 0, Background.Width + 200, Background.Height), Color.White);

            spriteBatch.Draw(crosshair, cursor);
            if (controller.checkLives())
            {
                if (controller.itemAppeared == true)
                {
                    //move item
                    itemVector = controller.updateItem();

                    //Centers appearance of item on draw point so collision can be compared regardless of size of image
                    Vector2 itemCenter = new Vector2((itemVector.X - itemImage.Width / 2), (itemVector.Y - itemImage.Height / 2));
                    //draw item
                    spriteBatch.Draw(itemImage, itemCenter);

                }

                //draw our enemies
                for (int i = EnemyVectors.Count - 1; i > 0; i--)
                {

                    //Centers appearance of enemy on draw point so collision can be compared regardless of size of image

                    Vector2 centered = new Vector2(EnemyVectors[i].X - (EnemyImage.Width / 2), EnemyVectors[i].Y - (EnemyImage.Height / 2));
                    spriteBatch.Draw(EnemyImage, centered);

                }


                spriteBatch.DrawString(font, controller.notification, notificationVector, Color.Red);

                
                base.Draw(gameTime);
            }
            else
            {
                
                // At the top of your class:
                Texture2D pixel;

                // Somewhere in your LoadContent() method:
                pixel = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                pixel.SetData(new[] { Color.Black }); // so that we can draw whatever color we want on top of it




                spriteBatch.DrawString(MenuFont, "Game Over", gameOverVector, Color.Black);
                spriteBatch.DrawString(MenuFont, "New Game", newGameVector, Color.Black);

                DrawBorder(pixel, newGameRect, 2, Color.Black);
                spriteBatch.DrawString(MenuFont, "Exit", quitGameVector, Color.Black);
                DrawBorder(pixel, quitGameRect, 2, Color.Black);



            }
            spriteBatch.DrawString(font, "Score: " + controller.getScore(), scoreVector, Color.Black);
            spriteBatch.DrawString(font, "Lives: " + controller.getLives(), livesVector, Color.Black);

            spriteBatch.DrawString(font, controller.notification, notificationVector, Color.Red);
            spriteBatch.DrawString(font, "Ammo: " + controller.getAmmo(), ammoVector, Color.Black);

            //for displaying the paused sprite after pausing of the game

            if (paused == true)
            {
               
                spriteBatch.DrawString(MenuFont, pause, pauseVector, Color.Black);
            }

            spriteBatch.End();

        }

        /// <summary>
        /// Will draw a border (hollow rectangle) of the given 'thicknessOfBorder' (in pixels)
        /// of the specified color.
        ///
        /// By Sean Colombo, from http://bluelinegamestudios.com/blog
        /// </summary>
        /// <param name="rectangleToDraw"></param>
        /// <param name="thicknessOfBorder"></param>
        private void DrawBorder(Texture2D pixel,Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }
        
        //performs actions when game is activated

        protected override void OnActivated(object sender, EventArgs args)
        {

            this.Window.Title = "Hunter";
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            this.Window.Title = "Paused";
            

            base.OnDeactivated(sender, args);
        }

        private void checkPauseKey(KeyboardState keyboardState)
        {
            bool pauseKeyDownThisFrame = (keyboardState.IsKeyDown(Keys.P));
            // If key was not down before, but is down now, we toggle the
            // pause setting
            if (!pauseKeyDown && pauseKeyDownThisFrame)
            {
                if (!paused)
                    BeginPause(true);
                else
                    EndPause();
            }
            pauseKeyDown = pauseKeyDownThisFrame;
        }
        private void BeginPause(bool UserInitiated)
        {
            paused = true;
            //TODO: Pause audio playback
            
        }
        private void EndPause()
        {
            //TODO: Resume audio
            
            paused = false;
        }
    }
}
