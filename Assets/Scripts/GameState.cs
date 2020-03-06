using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackedDesign
{
    [Serializable]
    public class GameState
    {
        
        public GameStateEnum currentState;
        public Level level;
        public bool started;
        public int turn;
        public Status playerStatus;
        public Inventory playerInventory;

        public int cutscene = 0;
        public int endcutscene = 0;

        public Difficulty difficulty;

        public List<Spawn> spawns;

        //public List<Chick> chicks;

        public List<string> actions = new List<string>(); // FIXME: Maybe don't use a list for this?

        public List<EnemyController> enemies = new List<EnemyController>();
        public List<NPCController> npcs = new List<NPCController>();

        public void IncrementTurn()
        {
            turn++;
        }

    }

    public enum GameStateEnum
    {
        MENU,
        INFO,
        HOWTO,
        CREDITS,
        DIFFICULTY,
        STARTCUTSCENE,
        ENDCUTSCENE,
        PLAYING,
        SHOP,
        GAMEOVERDEAD,
        GAMEOVERSTARVED,
        COMPLETE
    }

    [System.Serializable]
    public class Cutscene
    {
        public string speaker = "";
        [TextArea]
        public string text = "";
        public UnityEvent nextEvent;
    }
}
