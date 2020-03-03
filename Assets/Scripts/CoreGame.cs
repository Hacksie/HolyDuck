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
        [SerializeField] private Transform itemsParent = null;
        [SerializeField] private Transform npcsParent = null;
        [SerializeField] private FinalBoss finalBoss = null;
        [SerializeField] private Princess princess = null;
        [SerializeField] private List<Boss> bossList = null;
        [SerializeField] private LayerMask enemyLayerMask;


        [Header("State")]
        [SerializeField] private GameState state = new GameState();
        [SerializeField] private Inventory inventory = null;

        [Header("UI")]
        [SerializeField] private MenuPresenter menuPresenter = null;
        [SerializeField] private ConsolePresenter consolePresenter = null;
        [SerializeField] private CreditsPresenter creditsPresenter = null;
        [SerializeField] private StatusPresenter statusPresenter = null;
        [SerializeField] private TurnPresenter turnPresenter = null;
        [SerializeField] private GameOverStarvePresenter gameOverStarvePresenter = null;
        [SerializeField] private DifficultyPresenter difficultyPresenter = null;

        [Header("Prefabs")]
        [SerializeField] private GameObject mummaPrefab = null;
        [SerializeField] private GameObject chickPrefab = null;
        [SerializeField] private GameObject eggPrefab = null;
        [SerializeField] private GameObject applePrefab = null;
        [SerializeField] private GameObject mushroomPrefab = null;
        [SerializeField] private GameObject breadPrefab = null;
        [SerializeField] private GameObject chipPrefab = null;
        [SerializeField] private GameObject snakePrefab = null;

        [Header("Game Settings")]
        [SerializeField] private int levelWidth = 11;
        [SerializeField] private int levelHeight = 11;
        [SerializeField] private int chickCount = 99;
        [SerializeField] private int eggCount = 99;
        [SerializeField] private int breadCount = 99;
        [SerializeField] private int chipCount = 30;
        [SerializeField] private int appleCount = 20;
        [SerializeField] private int mushroomCount = 10;
        [SerializeField] private int mummaDucks = 20;
        [SerializeField] private int snakesCount = 20;
        [SerializeField] private int enemyRadius = 10;

        [SerializeField] private List<Difficulty> difficulties = new List<Difficulty>();
        private Difficulty difficulty;

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
            if (finalBoss == null) Logger.LogError(name, "finalBoss is null");
            if (princess == null) Logger.LogError(name, "princess is null");
            if (environment == null) Logger.LogError(name, "environment is null");
            if (itemsParent == null) Logger.LogError(name, "itemsParent is null");
            if (npcsParent == null) Logger.LogError(name, "npcsParent is null");
            if (menuPresenter == null) Logger.LogError(name, "menuPresenter is null");
            if (consolePresenter == null) Logger.LogError(name, "consolePresenter is null");
            if (creditsPresenter == null) Logger.LogError(name, "creditsPresenter is null");
            if (statusPresenter == null) Logger.LogError(name, "statusPresenter is null");
            if (turnPresenter == null) Logger.LogError(name, "turnPresenter is null");
            if (chickPrefab == null) Logger.LogError(name, "chickPrefab is null");
            if (eggPrefab == null) Logger.LogError(name, "eggPrefab is null");
            if (applePrefab == null) Logger.LogError(name, "applePrefab is null");
            if (mushroomPrefab == null) Logger.LogError(name, "mushroomPrefab is null");
            if (breadPrefab == null) Logger.LogError(name, "breadPrefab is null");
            if (chipPrefab == null) Logger.LogError(name, "chipPrefab is null");
            if (gameOverStarvePresenter == null) Logger.LogError(name, "gameOverStarvePresenter is null");
            if (difficultyPresenter == null) Logger.LogError(name, "difficultyPresenter is null");
            if (mummaPrefab == null) Logger.LogError(name, "mummaPrefab is null");
            if (snakePrefab == null) Logger.LogError(name, "snakePrefab is null");
        }


        void Initialization()
        {
            SetPlatformInput();
            InitializeLevel();
            turnManager.Initialize(state);
            player.Initialize(turnManager, state);
            menuPresenter.Initialize(state);
            consolePresenter.Initialize(state);
            creditsPresenter.Initialize(state);
            statusPresenter.Initialize(state);
            turnPresenter.Initialize(state);
            gameOverStarvePresenter.Initialize(state);
            difficultyPresenter.Initialize(state);
            SetMenu();
        }

        void InitializeLevel()
        {
            state.level = levelGenerator.GenerateRandomLevel(levelWidth, levelHeight);
            state.level.DebugPrint();
            levelRenderer.Render(state.level, environment);

            InitializeSpawns();
            SpawnChicks();
            SpawnEggs();
            SpawnApples();
            SpawnMushrooms();
            SpawnBreads();
            SpawnChips();
            SpawnMummaDucks();
            SpawnSnakes();

            //player.transform.position = levelRenderer.LevelToWorldCoords(new Vector2Int((state.level.width - 1) / 2, (state.level.height - 1) / 2), state.level) + new Vector2(-2, -1);
            player.transform.position = GetPlayerSpawn();
            finalBoss.transform.position = GetFinalBossSpawn();
            princess.transform.position = GetPrincessSpawn();

            var fbNPC = finalBoss.GetComponent<EnemyController>();
            fbNPC.Initialize(turnManager, state, player.transform); // Move to a separate function
            state.enemies.Add(fbNPC);

            var bossesSpawns = GetBossSpawns();
            bossesSpawns.Randomize();


            for(int i=0;i<bossesSpawns.Count;i++)
            {
                bossList[i].transform.position = bossesSpawns[i];
                //state.enemies.Add(fbNPC);
            }


        }

        private void InitializeSpawns()
        {
            state.spawns = GameObject.FindGameObjectsWithTag("Respawn").Select(e => e.GetComponent<Spawn>()).ToList();
        }

        private void SpawnMummaDucks()
        {
            var mummaSpawns = state.spawns.ToList().PickRandomElements(mummaDucks);

            foreach (var s in mummaSpawns)
            {
                Instantiate(mummaPrefab, s.transform.position, Quaternion.identity, npcsParent);
            }
        }

        private void SpawnSnakes()
        {
            var snakeSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(snakesCount);

            foreach (var s in snakeSpawns)
            {
                var go = Instantiate(snakePrefab, s.transform.position, Quaternion.identity, npcsParent);
                var enemy = go.GetComponent<EnemyController>();

                if(enemy != null)
                {
                    enemy.Initialize(turnManager, state, player.transform);
                    state.enemies.Add(enemy);
                }
                else
                {
                    Logger.Log(name, "Enemy without enemyController");
                }
            }
        }

        private void SpawnChicks()
        {
            var chickSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(chickCount);

            foreach (var s in chickSpawns)
            {
                Instantiate(chickPrefab, s.transform.position, Quaternion.identity, itemsParent);
            }
        }

        private void SpawnEggs()
        {
            var eggSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(eggCount);

            foreach (var s in eggSpawns)
            {
                Instantiate(eggPrefab, s.transform.position, Quaternion.identity, itemsParent);
            }
        }

        private void SpawnApples()
        {
            var appleSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(appleCount);

            foreach (var s in appleSpawns)
            {
                Instantiate(applePrefab, s.transform.position, Quaternion.identity, itemsParent);
            }
        }

        private void SpawnMushrooms()
        {
            var mushroomSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(mushroomCount);
            foreach (var s in mushroomSpawns)
            {
                Instantiate(mushroomPrefab, s.transform.position, Quaternion.identity, itemsParent);
            }
        }

        private void SpawnBreads()
        {
            var breadSpawns = state.spawns.ToList().PickRandomElements(breadCount);
            foreach (var s in breadSpawns)
            {
                Instantiate(breadPrefab, s.transform.position, Quaternion.identity, itemsParent);
            }
        }

        private void SpawnChips()
        {
            var chipSpawns = state.spawns.ToList().PickRandomElements(chipCount);
            foreach (var s in chipSpawns)
            {
                Instantiate(chipPrefab, s.transform.position, Quaternion.identity, itemsParent);
            }
        }


        private Vector2 GetPlayerSpawn() => state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().playerStart).transform.position;
        private Vector2 GetFinalBossSpawn() => state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().finalBossStart).transform.position;
        private Vector2 GetPrincessSpawn() => state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().princessStart).transform.position;

        private List<Vector2> GetBossSpawns() => state.spawns.FindAll(s => s.GetComponent<Spawn>().bossStart).Select(s => (Vector2)s.transform.position).ToList();


        public void AddActionMessage(string message)
        {
            state.actions.Insert(0, message);
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
                        /*
                        state.playerStatus.energy--;
                        if (state.playerStatus.energy <= 0)
                        {
                            state.currentState = GameStateEnum.GAMEOVERSTARVED;
                            break;
                        }

                        if (state.playerStatus.health <= 0)
                        {
                            state.currentState = GameStateEnum.GAMEOVERDEAD;
                            break;
                        }*/
                        turnManager.ProcessTurn();

                        var hits = Physics2D.OverlapCircleAll(player.transform.position, enemyRadius, enemyLayerMask);

                        foreach(var hit in hits)
                        {
                            if(hit.gameObject != null)
                            {
                                var enemy = hit.gameObject.GetComponent<EnemyController>();
                                enemy.UpdateTurn();
                            }
                        }
                        /*

                        foreach (var enemy in state.enemies)
                        {
                            enemy.UpdateTurn();
                        }*/
                    }
                    break;
                case GameStateEnum.MENU:
                    if (state.started)
                    {
                        // Close the menu
                    }
                    break;
                case GameStateEnum.GAMEOVERDEAD:
                    break;
                case GameStateEnum.GAMEOVERSTARVED:
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
            statusPresenter.Repaint();
            turnPresenter.Repaint();
            gameOverStarvePresenter.Repaint();
            difficultyPresenter.Repaint();
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

        public void SetDifficult()
        {
            state.currentState = GameStateEnum.DIFFICULTY;
        }

        public void SetOver()
        {
            // Reset stuff in here
            state.started = false;
            state.currentState = GameStateEnum.MENU;
        }

        public void ResumeGame()
        {
            state.currentState = GameStateEnum.PLAYING;
        }
        public void StartGame()
        {
            state.currentState = GameStateEnum.PLAYING;
            state.started = true;
        }

        public void Quit()
        {
            Application.Quit();
        }

        /*
        void UpdatePlayerInput()
        {
            //player.UpdatePlayerTurn(inputController);
            //Update enemy actions

        }*/
    }

}
