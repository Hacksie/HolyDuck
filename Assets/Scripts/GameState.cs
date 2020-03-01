using UnityEngine;
using System;

namespace HackedDesign
{
    [Serializable]
    public class GameState
    {
        public GameStateEnum currentState;
        public Vector2 player;
        public Level level;
        public bool started;
        public int turn;
        public int health= 100;
        public int maxHealth = 100;
        public int energy = 100;
        public int maxEnergy = 100;
        public int chicksSaved = 0;

        public void IncrementTurn()
        {
            turn++;
        }
    }

    public enum GameStateEnum
    {
        MENU,
        INFO,
        OPTIONS,
        CREDITS,
        PLAYING,
        GAMEOVER,
        COMPLETE
    }
}
