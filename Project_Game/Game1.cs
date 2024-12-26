using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Game.UI;
using Project_Game.Manager;

namespace Project_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Screen _currentScreen;
        private InputManager _inputManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _inputManager = new InputManager();
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
            _inputManager.Update();
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
        public InputManager InputManager => _inputManager;

    }
}
