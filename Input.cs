﻿using BEngine2D.Input;

namespace BExampleGame
{
    public class Input
    {
        private Game Game;
        private BKeyboardListener KeyboardListener;
        private BMouseListener MouseListener;

        public Input(Game game, BKeyboardListener keyboardListener, BMouseListener mouseListener )
        {
            Game = game;
            KeyboardListener = keyboardListener;
            MouseListener = mouseListener;
        }

        public void Update()
        {

        }
    }
}
