using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HackedDesign
{
    public class CoreGame : MonoBehaviour
    {
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
        [SerializeField] public GameState state = new GameState();

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
        }

        void Initialization()
        {
            SetPlatformInput();
            player.Initialize(turnManager);


            InitializeLevel();
            
        }

        void InitializeLevel()
        {
            state.level = levelGenerator.GenerateRandomLevel(7, 7);
            state.level.DebugPrint();
            levelRenderer.Render(state.level, environment);
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
            player.UpdateSprite();

            if(turnManager.PlayerTurnCompleted())
            {
                turnManager.ProcessTurn();
                // Update enemy actions
            }
        }

        private void LateUpdate()
        {
            
        }

        /*
        void UpdatePlayerInput()
        {
            //player.UpdatePlayerTurn(inputController);
            //Update enemy actions

        }*/
    }

}
