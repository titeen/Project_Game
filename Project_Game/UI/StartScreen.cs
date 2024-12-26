using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game.Levels;

namespace Project_Game.UI
{
    public class StartScreen : Screen
    {
        private SpriteFont _titleFont;
        private SpriteFont _menuFont;
        private Texture2D _backgroundTexture;
        private Texture2D _scrollBackgroundTexture;

        private string[] options = { "Level 1", "Level 2" };
        private int selectedOption = 0;

        public StartScreen(Game1 game) : base(game) { }

        public override void LoadContent()
        {
            // Laad bronnen
            _titleFont = _game.Content.Load<SpriteFont>("basicFontBig");
            _menuFont = _game.Content.Load<SpriteFont>("basicFont");
            _backgroundTexture = _game.Content.Load<Texture2D>("StartScreen5");
            _scrollBackgroundTexture = _game.Content.Load<Texture2D>("scroll_background");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Exit();

            // Menu navigatie met Left en Right keys
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && selectedOption > 0)
                selectedOption--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && selectedOption < options.Length - 1)
                selectedOption++;

            // Optie selecteren met Enter
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (selectedOption == 0)
                    _game.ChangeScreen(new Level1(_game));
                else if (selectedOption == 1)
                    _game.ChangeScreen(new Level2(_game));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _game.GraphicsDevice.Clear(Color.Black);
            _game.SpriteBatch.Begin();

            // Teken de achtergrond
            _game.SpriteBatch.Draw(_backgroundTexture, _game.GraphicsDevice.Viewport.Bounds, Color.White);

            // Teken de titel
            string title = "Save the Princess";
            string[] titleWords = title.Split(' ');
            float totalWidth = 0;

            foreach (string word in titleWords)
            {
                totalWidth += _titleFont.MeasureString(word).X + 10;
            }

            float titleX = (_game.GraphicsDevice.Viewport.Width - totalWidth) / 2;
            float titleY = 10;

            float backgroundWidth = totalWidth;
            float backgroundHeight = _titleFont.MeasureString(title).Y + 20;
            Rectangle titleBox = new Rectangle((int)titleX - 40, (int)titleY - 10, (int)backgroundWidth + 75, (int)backgroundHeight);

            _game.SpriteBatch.Draw(_scrollBackgroundTexture, titleBox, Color.White);

            float currentX = titleX;
            foreach (string word in titleWords)
            {
                _game.SpriteBatch.DrawString(_titleFont, word, new Vector2(currentX, titleY), Color.Black);
                currentX += _titleFont.MeasureString(word).X + 10;
            }

            // Teken menu-opties
            float optionsTotalWidth = _menuFont.MeasureString(options[0]).X + _menuFont.MeasureString(options[1]).X + 50;
            float optionsStartX = (_game.GraphicsDevice.Viewport.Width - optionsTotalWidth) / 2;
            float optionsY = _game.GraphicsDevice.Viewport.Height - 50;

            for (int i = 0; i < options.Length; i++)
            {
                string option = options[i];
                Vector2 optionSize = _menuFont.MeasureString(option);
                float optionX = optionsStartX + (i * (optionSize.X + 50));

                Rectangle optionBox = new Rectangle((int)optionX - 15, (int)optionsY - 10, (int)optionSize.X + 30, (int)optionSize.Y + 20);
                _game.SpriteBatch.Draw(_scrollBackgroundTexture, optionBox, Color.White);

                Color optionColor = i == selectedOption ? Color.White : Color.Black;
                _game.SpriteBatch.DrawString(_menuFont, option, new Vector2(optionX, optionsY), optionColor);
            }

            _game.SpriteBatch.End();
        }
    }
}
