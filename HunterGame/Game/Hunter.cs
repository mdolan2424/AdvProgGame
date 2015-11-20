﻿using System;
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

        //mouse position and sprite
        private Vector2 cursor;
        private Texture2D crosshair;
        private Vector2 scoreVector;
        private Vector2 livesVector;
        //pause
        bool paused;
        
        //enemies
        Texture2D EnemyImage;

        //items
        Texture2D itemImage;
        Vector2 itemVector;

        //use item
        Player player;

        SpriteFont font;

        double enemySpawnTime = 0;
        double itemSpawnTime = 0;

        ItemManager items;
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
            Ran = new Random();
            //use item
            player = new Player(3);
            //Handles game logic separate from Rendering
            controller = new GameController(graphics.GraphicsDevice.PresentationParameters.Bounds.Width, graphics.GraphicsDevice.PresentationParameters.Bounds.Height);
            //mouse and keyboard states
            currentKeyboardState = new KeyboardState();
            currentMouseState = new MouseState();

            //initialize cursor
            cursor = new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            paused = false;
            scoreVector = new Vector2(graphics.GraphicsDevice.Viewport.Width - 150, graphics.GraphicsDevice.Viewport.Height - 40);
            livesVector = new Vector2(graphics.GraphicsDevice.Viewport.Width - 300, graphics.GraphicsDevice.Viewport.Height - 40);

            
           

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            crosshair = Content.Load<Texture2D>("Graphics\\circle-03");
            font = Content.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>("SpriteFont1");
            //for enemies
            
            EnemyImage = Content.Load<Texture2D>("Graphics\\rubber-duck-icon");
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

            //mouse
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            //update mouse sprite position.  Image is drawn from bottom right so we subtract
            cursor.X = currentMouseState.X-(crosshair.Width/2);
            cursor.Y = currentMouseState.Y-(crosshair.Height/2);

            //check for a paused key press.
            
                if (currentKeyboardState.IsKeyDown(Keys.Escape) && oldKeyboardState.IsKeyUp(Keys.Escape))
                {
                    paused = true;
                    Exit();
                }

            
            enemySpawnTime += gameTime.ElapsedGameTime.TotalSeconds;
            itemSpawnTime += gameTime.ElapsedGameTime.TotalSeconds;

            if(enemySpawnTime > 2)
            {
                controller.spawnEnemy();
                enemySpawnTime = 0;
            }

            if(itemSpawnTime > 30)
            {
                String imageLocation = controller.spawnItem();
                itemImage = Content.Load<Texture2D>(imageLocation);
                itemSpawnTime = 0;
            }
            controller.updateEnemies();
            EnemyVectors = controller.EnemiesVector;
            

            //check if mouse click
            if (currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                
                Point mousePosition = new Point(currentMouseState.X,currentMouseState.Y);
                //check if an object was shot
                controller.checkObjectShot(mousePosition);
                
            }
            
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(crosshair, cursor);

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
            for (int i = EnemyVectors.Count-1; i >0; i--)
            {
                
                //Centers appearance of enemy on draw point so collision can be compared regardless of size of image
                
                Vector2 centered = new Vector2(EnemyVectors[i].X - (EnemyImage.Width / 2), EnemyVectors[i].Y - (EnemyImage.Height / 2));
                spriteBatch.Draw(EnemyImage, centered);
                
            }


            spriteBatch.DrawString(font, "Score: " + controller.getScore(), scoreVector, Color.Black);
            spriteBatch.DrawString(font, "Lives: " + controller.getLives(), livesVector, Color.Black);
           
            spriteBatch.End();
            
            base.Draw(gameTime);
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
    }
}
