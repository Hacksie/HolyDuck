﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        [Header("UI")]
        [SerializeField] private MenuPresenter menuPresenter = null;
        [SerializeField] private ConsolePresenter consolePresenter = null;
        [SerializeField] private CreditsPresenter creditsPresenter = null;

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
            SetMenu();
        }

        void InitializeLevel()
        {
            state.level = levelGenerator.GenerateRandomLevel(21, 21);
            state.level.DebugPrint();
            levelRenderer.Render(state.level, environment);
            player.transform.position = levelRenderer.LevelToWorldCoords(new Vector2Int((state.level.width - 1) / 2, (state.level.height - 1) / 2), state.level);
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
            switch(state.currentState)
            {
                case GameStateEnum.PLAYING:
                    if (turnManager.PlayerTurnCompleted())
                    {
                        turnManager.ProcessTurn();
                        // Update enemy actions
                    }
                    break;
                case GameStateEnum.MENU:
                    if(state.started)
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

        private void UpdateUI()
        {
            menuPresenter.Repaint();
            consolePresenter.Repaint();
            creditsPresenter.Repaint();
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