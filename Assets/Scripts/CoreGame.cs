using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign
{
    public class CoreGame : MonoBehaviour
    {
        public static CoreGame instance;

        private Input.IInputController inputController;

        [Header("Test Flags")]
        [SerializeField] private RuntimePlatform testPlatform = RuntimePlatform.WindowsEditor;
        [SerializeField] private bool testPlatformFlag = false;

        [Header("Game Objects")]
        [SerializeField] public TurnManager turnManager = null;
        [SerializeField] public LevelGenerator levelGenerator = null;
        [SerializeField] public LevelRenderer levelRenderer = null;
        [SerializeField] public PlayerController player = null;
        [SerializeField] private Transform environment = null;


        [Header("State")]
        [SerializeField] private GameState state = new GameState();
        [SerializeField] private Inventory inventory = null;

        [Header("UI")]
        [SerializeField] private MenuPresenter menuPresenter = null;
        [SerializeField] private ConsolePresenter consolePresenter = null;
        [SerializeField] private CreditsPresenter creditsPresenter = null;
        [SerializeField] private StatusPresenter statusPresenter = null;

        CoreGame()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            CheckBindings();
            Initialization();
        }

        void CheckBindings()
        {
            if (turnManager == null) Logger.LogError(name, "turnManager is null");
            if (levelGenerator == null) Logger.LogError(name, "levelGenerator is null");
            if (levelRenderer == null) Logger.LogError(name, "levelRenderer is null");
            if (player == null) Logger.LogError(name, "player is null");
            if (environment == null) Logger.LogError(name, "environment is null");
            if (menuPresenter == null) Logger.LogError(name, "menuPresenter is null");
            if (consolePresenter == null) Logger.LogError(name, "consolePresenter is null");
            if (creditsPresenter == null) Logger.LogError(name, "creditsPresenter is null");
            if (statusPresenter == null) Logger.LogError(name, "statusPresenter is null");
        }

        void Initialization()
        {
            SetPlatformInput();
            InitializeLevel();
            turnManager.Initialize(state);
            player.Initialize(turnManager, state);
            menuPresenter.Initialize(state);
            consolePresenter.Initialize(state, turnManager);
            creditsPresenter.Initialize(state);
            statusPresenter.Initialize(state, inventory);
            SetMenu();
        }

        void InitializeLevel()
        {
            state.level = levelGenerator.GenerateRandomLevel(21, 21);
            state.level.DebugPrint();
            levelRenderer.Render(state.level, environment);
            player.transform.position = levelRenderer.LevelToWorldCoords(new Vector2Int((state.level.width - 1) / 2, (state.level.height - 1) / 2), state.level) + new Vector2(-2, -1);
            player.transform.position = GetPlayerSpawn();
        }

        private Vector2 GetPlayerSpawn()
        {
            var spawns = GameObject.FindGameObjectsWithTag("Respawn");

            Logger.Log(name, "spawns", spawns.Length.ToString());

            var playerSpawn = spawns.FirstOrDefault(s => s.GetComponent<Spawn>().playerStart);

            return playerSpawn.transform.position;

        }

        private void SetPlatformInput()
        {
            switch (testPlatformFlag ? testPlatform : Application.platform)
            {
                case RuntimePlatform.Android:
                    Logger.Log(this.name, "input platform Android");
                    inputController = new Input.DesktopInputController(); // new Input.AndroidInputController(mobileInputUI);
                    break;
                default:
                    Logger.Log(this.name, "input platform Default");
                    inputController = new Input.DesktopInputController();
                    break;
            }
        }

        // Update is called once per frame
        void Update()
        {
            switch (state.currentState)
            {
                case GameStateEnum.PLAYING:
                    if (turnManager.PlayerTurnCompleted())
                    {
                        state.energy--;
                        turnManager.ProcessTurn();
                        // Update enemy actions
                        statusPresenter.RepaintText();
                    }
                    break;
                case GameStateEnum.MENU:
                    if (state.started)
                    {
                        // Close the menu
                    }
                    break;
                case GameStateEnum.GAMEOVER:
                    break;
                default:
                    break;
            }


        }


        private void LateUpdate()
        {
            player.UpdateSprite();
            UpdateUI();
        }

        public void SaveChick()
        {
            state.chicksSaved++;
            Logger.Log(name, "Chick saved!");
        }

        private void UpdateUI()
        {
            menuPresenter.Repaint();
            consolePresenter.Repaint();
            creditsPresenter.Repaint();
            statusPresenter.Repaint();
        }

        public void SetOptions()
        {
            state.currentState = GameStateEnum.OPTIONS;
        }

        public void SetCredits()
        {
            state.currentState = GameStateEnum.CREDITS;
        }

        public void SetMenu()
        {
            state.currentState = GameStateEnum.MENU;
        }

        public void StartGame()
        {
            state.currentState = GameStateEnum.PLAYING;
            state.started = true;
        }

        /*
        void UpdatePlayerInput()
        {
            //player.UpdatePlayerTurn(inputController);
            //Update enemy actions

        }*/
    }

}
