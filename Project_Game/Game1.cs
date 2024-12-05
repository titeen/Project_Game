using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game.UI;

namespace Project_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Screen _currentScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Begin met het StartScreen
            _currentScreen = new UI.StartScreen(this); 
            _currentScreen.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _currentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _currentScreen.Draw(gameTime);
            base.Draw(gameTime);
        }

        // Verander het scherm
        public void ChangeScreen(Screen newScreen)
        {
            _currentScreen = newScreen;
            _currentScreen.LoadContent();
        }

        public SpriteBatch SpriteBatch => _spriteBatch; // Exposeer SpriteBatch voor tekeningen
    }
}
