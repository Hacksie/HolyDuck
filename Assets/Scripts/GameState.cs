using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int minAttack = 0;
        public int maxAttack = 5;
        public int defense = 1;

        public List<Spawn> spawns;

        public List<Chick> chicks;

        public List<string> actions = new List<string>(); // FIXME: Maybe don't use a list for this?

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
        GAMEOVERDEAD,
        GAMEOVERSTARVED,
        COMPLETE
    }
}
