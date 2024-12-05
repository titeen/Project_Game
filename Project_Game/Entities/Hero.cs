using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Game.Entities
{
    public class Hero
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity;
        private bool _isJumping = false;

        private float _gravity = 0.5f;
        private float _jumpForce = -10f;

        public Hero(Texture2D texture, Vector2 startPosition)
        {
            _texture = texture;
            _position = startPosition;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            // Beweeg links/rechts
            if (keyboardState.IsKeyDown(Keys.Left))
                _velocity.X = -5f;
            else if (keyboardState.IsKeyDown(Keys.Right))
                _velocity.X = 5f;
            else
                _velocity.X = 0;

            // Springen
            if (keyboardState.IsKeyDown(Keys.Space) && !_isJumping)
            {
                _velocity.Y = _jumpForce;
                _isJumping = true;
            }

            // Gravitatie
            _velocity.Y += _gravity;

            // Update positie
            _position += _velocity;

            // Check vloer
            if (_position.Y >= 400) // Stel vloerhoogte in
            {
                _position.Y = 400;
                _velocity.Y = 0;
                _isJumping = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
