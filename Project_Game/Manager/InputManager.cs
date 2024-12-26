using Microsoft.Xna.Framework.Input;

namespace Project_Game.Manager
{
    public class InputManager
    {
        private KeyboardState _currentState;
        private KeyboardState _previousState;

        // Update de invoerstatus
        //moet in methode van game worden aangeroepen om huidige en vorige toestand van toetsen bij te houden
        public void Update()
        {
            _previousState = _currentState;
            _currentState = Keyboard.GetState();
        }

        // Controleer of een bepaalde toets momenteel ingedrukt is
        public bool IsKeyDown(Keys key)
        {
            return _currentState.IsKeyDown(key);
        }

        // Controleer of een bepaalde toets net is ingedrukt (één keer)
        public bool IsKeyPressed(Keys key)
        {
            return _currentState.IsKeyDown(key) && !_previousState.IsKeyDown(key);
        }

        // Controleer of een bepaalde toets is losgelaten
        public bool IsKeyReleased(Keys key)
        {
            return !_currentState.IsKeyDown(key) && _previousState.IsKeyDown(key);
        }
    }
}
