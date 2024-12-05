using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Game.Levels;

namespace Project_Game.UI
{
    public class StartScreen : Screen
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _titleFont;
        private SpriteFont _menuFont;
        private Texture2D _backgroundTexture;
        private string[] options = { "Level 1", "Level 2" };
        private int selectedOption = 0;

        public StartScreen(Game1 game) : base(game) { }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            _titleFont = _game.Content.Load<SpriteFont>("basicFontBig");
            _menuFont = _game.Content.Load<SpriteFont>("basicFont");
            _backgroundTexture = _game.Content.Load<Texture2D>("StartScreen5");
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
                {
                    _game.ChangeScreen(new Level1(_game));
                }
                else if (selectedOption == 1)
                {
                    _game.ChangeScreen(new Level2(_game));
                }
            }
        }


        public override void Draw(GameTime gameTime)
        {
            _game.GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            // Teken de achtergrond
            _spriteBatch.Draw(_backgroundTexture, _game.GraphicsDevice.Viewport.Bounds, Color.White);

            string title = "Save the Princess";
            string[] titleWords = title.Split(' ');  // Split de titel in woorden
            float totalWidth = 0;

            // Meet de totale breedte van de tekst inclusief de spaties tussen woorden
            foreach (string word in titleWords)
            {
                totalWidth += _titleFont.MeasureString(word).X + 10; // Voeg 10 pixels toe voor tussenruimte tussen de woorden
            }

            // Centreer de titel
            float titleX = (_game.GraphicsDevice.Viewport.Width - totalWidth) / 2;
            float titleY = 10; //Afstand van de hoogte

            // Teken een achtergrondbox voor de titel
            float backgroundWidth = totalWidth; 
            float backgroundHeight = _titleFont.MeasureString(title).Y + 20;  // Voeg wat hoogte toe voor de achtergrond
            Rectangle titleBox = new Rectangle((int)titleX - 40, (int)titleY - 10, (int)backgroundWidth + 75, (int)backgroundHeight);
            _spriteBatch.Draw(_game.Content.Load<Texture2D>("scroll_background"), titleBox, Color.White);

            // Teken de titel met spaties tussen de woorden
            float currentX = titleX;
            foreach (string word in titleWords)
            {
                _spriteBatch.DrawString(_titleFont, word, new Vector2(currentX, titleY), Color.Black);
                currentX += _titleFont.MeasureString(word).X + 10;
            }

            // Bereken de breedte van beide opties en plaats ze horizontaal gecentreerd onderaan het scherm
            float optionsTotalWidth = _menuFont.MeasureString(options[0]).X + _menuFont.MeasureString(options[1]).X + 50; // 50 pixels tussenruimte
            float optionsStartX = (_game.GraphicsDevice.Viewport.Width - optionsTotalWidth) / 2;
            float optionsY = _game.GraphicsDevice.Viewport.Height - 50;

            for (int i = 0; i < options.Length; i++)
            {
                string option = options[i];
                Vector2 optionSize = _menuFont.MeasureString(option);  // Meet de breedte van de optie
                float optionX = optionsStartX + (i * (optionSize.X + 50));  // Plaats opties naast elkaar met 50 pixels tussenruimte

                // Voeg een achtergrondbox toe voor de menu-optie
                Rectangle optionBox = new Rectangle((int)optionX - 15, (int)optionsY - 10, (int)optionSize.X + 30, (int)optionSize.Y + 20);
                _spriteBatch.Draw(_game.Content.Load<Texture2D>("scroll_background"), optionBox, Color.White);

                // Hooglicht de geselecteerde optie en teken de tekst
                Color optionColor = i == selectedOption ? Color.White : Color.Black;
                _spriteBatch.DrawString(_menuFont, option, new Vector2(optionX, optionsY), optionColor);
            }

            _spriteBatch.End();
        }
    }
}
