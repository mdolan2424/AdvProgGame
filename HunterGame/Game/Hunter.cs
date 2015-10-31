using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HunterGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Hunter : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameController controller;

        KeyboardState currentKeyboardState, oldKeyboardState;
        MouseState currentMouseState, oldMouseState;

        //mouse position and sprite
        Vector2 cursor;
        Texture2D crosshair;

        //pause
        bool paused = false;


        public Hunter()
        {
            //sets up window and Game
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;

            
           

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            //Handles game logic separate from Rendering
            controller = new GameController();


            // TODO: Add your initialization logic here
            currentKeyboardState = new KeyboardState();
            currentMouseState = new MouseState();


            //Handles game logic separate from GameLoop
            controller = new GameController();

            //initialize cursor to middle of screen
            cursor = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);
            

            //set up player
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
            
            // TODO: Add your update logic here

            oldKeyboardState = currentKeyboardState;
            oldMouseState = currentMouseState;

            //mouse
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            //update mouse sprite position
            cursor.X = currentMouseState.X;
            cursor.Y = currentMouseState.Y;

            //check for a paused key press.
            if (!paused)
            {
                if (currentKeyboardState.IsKeyDown(Keys.Escape))
                {
                    paused = true;
                    Exit();
                }
                
                
            }

            else
            {
                paused = false;
            }

            //run game as normal
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {

            }
            //run game as normal
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {

            }
            //run game as normal
            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {

            }
            //run game as normal
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {

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
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        private void detectInput()
        {
            
        }

        private void Pause(GameTime gameTime)
        {

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
