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
        [SerializeField] private CrowBoss crowBoss = null;
        [SerializeField] private SwanBoss swanBoss = null;
        [SerializeField] private SeagullBoss seagullBoss = null;
        [SerializeField] private SnipeBoss snipeBoss = null;
        [SerializeField] private SandpiperBoss sandpiperBoss = null;
        [SerializeField] private Princess princess = null;
        [SerializeField] private GameObject gooseleeCutscene = null;
        [SerializeField] private GameObject suzieCutscene = null;
        [SerializeField] private GameObject suzieCutscene2 = null;
        [SerializeField] private GameObject crowCutscene = null;
        [SerializeField] private GameObject loafCutscene = null;
        [SerializeField] private GameObject loafCutscene2 = null;
        [SerializeField] private LayerMask enemyLayerMask;


        [Header("State")]
        [SerializeField] private GameState state = new GameState();
        //[SerializeField] private Inventory inventory = null;

        [Header("UI")]
        [SerializeField] private MenuPresenter menuPresenter = null;
        [SerializeField] private ConsolePresenter consolePresenter = null;
        [SerializeField] private CreditsPresenter creditsPresenter = null;
        [SerializeField] private StatusPresenter statusPresenter = null;
        [SerializeField] private TurnPresenter turnPresenter = null;
        [SerializeField] private GameOverStarvePresenter gameOverStarvePresenter = null;
        [SerializeField] private GameOverDeadPresenter gameOverDeadPresenter = null;
        [SerializeField] private GameOverSuccessPresenter gameOverSuccessPresenter = null;
        [SerializeField] private DifficultyPresenter difficultyPresenter = null;
        [SerializeField] private ShopPresenter shopPresenter = null;
        [SerializeField] private CutscenePresenter cutscenePresenter = null;

        [Header("Prefabs")]
        [SerializeField] private GameObject mummaPrefab = null;
        [SerializeField] private GameObject chickPrefab = null;
        [SerializeField] private GameObject eggPrefab = null;
        [SerializeField] private GameObject applePrefab = null;
        [SerializeField] private GameObject mushroomPrefab = null;
        [SerializeField] private GameObject breadPrefab = null;
        [SerializeField] private GameObject chipPrefab = null;
        [SerializeField] private GameObject lettucePrefab = null;
        [SerializeField] private GameObject snakePrefab = null;
        [SerializeField] private GameObject ratPrefab = null;
        [SerializeField] private GameObject hawkPrefab = null;
        [SerializeField] private GameObject crocPrefab = null;
        [SerializeField] private GameObject crabPrefab = null;

        [Header("Game Settings")]

        //[SerializeField] private int levelWidth = 11;
        //[SerializeField] private int levelHeight = 11;
        //[SerializeField] private int chickCount = 99;
        //[SerializeField] private int eggCount = 99;
        //[SerializeField] private int breadCount = 99;
        //[SerializeField] private int chipCount = 30;
        //[SerializeField] private int appleCount = 20;
        //[SerializeField] private int mushroomCount = 10;
        //[SerializeField] private int mummaDucks = 20;
        //[SerializeField] private int snakesCount = 20;
        //[SerializeField] private int ratsCount = 20;
        //[SerializeField] private int hawkCount = 5;
        //[SerializeField] private int enemyRadius = 10;

        [SerializeField] private List<Difficulty> difficulties = new List<Difficulty>();

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
            if (crowBoss == null) Logger.LogError(name, "crowBoss is null");
            if (swanBoss == null) Logger.LogError(name, "swanBoss is null");
            if (seagullBoss == null) Logger.LogError(name, "seagullBoss is null");
            if (snipeBoss == null) Logger.LogError(name, "snipeBoss is null");
            if (sandpiperBoss == null) Logger.LogError(name, "sandpiperBoss is null");
            if (princess == null) Logger.LogError(name, "princess is null");
            if (environment == null) Logger.LogError(name, "environment is null");
            if (itemsParent == null) Logger.LogError(name, "itemsParent is null");
            if (npcsParent == null) Logger.LogError(name, "npcsParent is null");
            if (menuPresenter == null) Logger.LogError(name, "menuPresenter is null");
            if (consolePresenter == null) Logger.LogError(name, "consolePresenter is null");
            if (creditsPresenter == null) Logger.LogError(name, "creditsPresenter is null");
            if (statusPresenter == null) Logger.LogError(name, "statusPresenter is null");
            if (turnPresenter == null) Logger.LogError(name, "turnPresenter is null");
            if (cutscenePresenter == null) Logger.LogError(name, "cutscenePresenter is null");
            if (chickPrefab == null) Logger.LogError(name, "chickPrefab is null");
            if (eggPrefab == null) Logger.LogError(name, "eggPrefab is null");
            if (applePrefab == null) Logger.LogError(name, "applePrefab is null");
            if (mushroomPrefab == null) Logger.LogError(name, "mushroomPrefab is null");
            if (breadPrefab == null) Logger.LogError(name, "breadPrefab is null");
            if (chipPrefab == null) Logger.LogError(name, "chipPrefab is null");
            if (lettucePrefab == null) Logger.LogError(name, "lettucePrefab is null");
            if (gameOverStarvePresenter == null) Logger.LogError(name, "gameOverStarvePresenter is null");
            if (gameOverDeadPresenter == null) Logger.LogError(name, "gameOverDeadPresenter is null");
            if (gameOverSuccessPresenter == null) Logger.LogError(name, "gameOverSuccessPresenter is null");
            if (difficultyPresenter == null) Logger.LogError(name, "difficultyPresenter is null");
            if (shopPresenter == null) Logger.LogError(name, "shopPresenter is null");
            if (mummaPrefab == null) Logger.LogError(name, "mummaPrefab is null");
            if (snakePrefab == null) Logger.LogError(name, "snakePrefab is null");
            if (ratPrefab == null) Logger.LogError(name, "ratPrefab is null");
            if (hawkPrefab == null) Logger.LogError(name, "hawkPrefab is null");
            if (crocPrefab == null) Logger.LogError(name, "crocPrefab is null");
            if (crabPrefab == null) Logger.LogError(name, "crabPrefab is null");

            //if (finalBossCutscene == null) Logger.LogError(name, "finalBossCutscene is null");
            //if (crowBossCutscene == null) Logger.LogError(name, "crowBossCutscene is null");
            //if (princessCutscene == null) Logger.LogError(name, "princessCutscene is null");
            //if (loafCutscene == null) Logger.LogError(name, "loafCutscene is null");
        }


        void Initialization()
        {
            SetPlatformInput();

            turnManager.Initialize(state);
            player.Initialize(turnManager, state);
            menuPresenter.Initialize(state);
            consolePresenter.Initialize(state);
            creditsPresenter.Initialize(state);
            statusPresenter.Initialize(state);
            turnPresenter.Initialize(state);
            gameOverStarvePresenter.Initialize(state);
            gameOverDeadPresenter.Initialize(state);
            gameOverSuccessPresenter.Initialize(state);
            difficultyPresenter.Initialize(state);
            shopPresenter.Initialize(state);
            cutscenePresenter.Initialize(state);
            SetMenu();
        }

        void InitializeLevel()
        {
            state.level = levelGenerator.GenerateRandomLevel(state.difficulty.levelWidth, state.difficulty.levelHeight);
            state.level.DebugPrint();
            levelRenderer.Render(state.level, environment);

            InitializeSpawns();
            //FIXME: Flakey
            SpawnPlayer(player.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().playerStart));
            SpawnNamedEnemy(finalBoss.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().finalBossStart));
            SpawnNamedEnemy(crowBoss.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().crowBossStart));
            SpawnNamedEnemy(swanBoss.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().swanStart));
            SpawnNamedEnemy(seagullBoss.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().seagullStart));
            SpawnNamedEnemy(snipeBoss.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().snipeStart));
            SpawnNamedEnemy(sandpiperBoss.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().sandpiperStart));
            SpawnPrincess(princess.gameObject, state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().princessStart));

            SpawnChicks();
            SpawnEggs();
            SpawnApples();
            SpawnMushrooms();
            SpawnBreads();
            SpawnChips();
            SpawnLettuces();
            SpawnMummaDucks();
            SpawnSnakes();
            SpawnRats();
            SpawnHawks();
            SpawnCrocs();
            SpawnCrabs();
            SpawnCutscene();
        }

        private void InitializeSpawns()
        {
            state.spawns = GameObject.FindGameObjectsWithTag("Respawn").Select(e => e.GetComponent<Spawn>()).ToList();
        }

        private void SpawnCutscene()
        {
            gooseleeCutscene.transform.position = state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().finalBossStartCutscene).transform.position;
            crowCutscene.transform.position = state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().crowBossStartCutscene).transform.position;
            suzieCutscene.transform.position = state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().princessStartCutscene).transform.position;
            suzieCutscene2.transform.position = state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().princessStartCutscene2).transform.position;
            

            loafCutscene.transform.position = state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().loafCutscene).transform.position;
            loafCutscene2.transform.position = state.spawns.FirstOrDefault(s => s.GetComponent<Spawn>().loafCutscene2).transform.position;
            suzieCutscene2.SetActive(false);
            loafCutscene2.SetActive(false);
        }

        private void SpawnPlayer(GameObject player, Spawn spawn)
        {
            SpawnCharacter(player, spawn);
        }

        private void SpawnNamedEnemy(GameObject enemy, Spawn spawn)
        {
            SpawnCharacter(enemy, spawn);
            var controller = crowBoss.GetComponent<EnemyController>();
            controller.Initialize(turnManager, state, player.transform);
            state.enemies.Add(controller);
        }

        private void SpawnCharacter(GameObject character, Spawn spawn)
        {
            character.transform.position = spawn.transform.position;
            state.spawns.Remove(spawn);
        }

        private void SpawnPrincess(GameObject princess, Spawn spawn)
        {
            SpawnCharacter(princess, spawn);

            var fbNPC = princess.GetComponent<NPCController>();
            fbNPC.Initialize(turnManager, state);
            //state.enemies.Add(fbNPC);
            state.spawns.Remove(spawn);
        }

        private void SpawnMummaDucks()
        {
            var mummaSpawns = state.spawns.ToList().PickRandomElements(state.difficulty.mummaDucks);

            foreach (var s in mummaSpawns)
            {
                Instantiate(mummaPrefab, s.transform.position, Quaternion.identity, npcsParent);
                state.spawns.Remove(s);
            }
        }

        private void SpawnSnakes()
        {
            var snakeSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.snakesCount);

            foreach (var s in snakeSpawns)
            {
                var go = Instantiate(snakePrefab, s.transform.position, Quaternion.identity, npcsParent);
                var enemy = go.GetComponent<EnemyController>();

                if (enemy != null)
                {
                    enemy.Initialize(turnManager, state, player.transform);
                    state.enemies.Add(enemy);
                }
                else
                {
                    Logger.LogError(name, "Enemy without enemyController");
                }
                state.spawns.Remove(s);
            }
        }

        private void SpawnRats()
        {
            var ratSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.ratsCount);

            foreach (var s in ratSpawns)
            {
                var go = Instantiate(ratPrefab, s.transform.position, Quaternion.identity, npcsParent);
                var enemy = go.GetComponent<EnemyController>();

                if (enemy != null)
                {
                    enemy.Initialize(turnManager, state, player.transform);
                    state.enemies.Add(enemy);
                }
                else
                {
                    Logger.LogError(name, "Enemy without enemyController");
                }
                state.spawns.Remove(s);
            }
        }

        private void SpawnHawks()
        {
            var hawkSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.hawkCount);

            foreach (var s in hawkSpawns)
            {
                var go = Instantiate(hawkPrefab, s.transform.position, Quaternion.identity, npcsParent);
                var enemy = go.GetComponent<EnemyController>();

                if (enemy != null)
                {
                    enemy.Initialize(turnManager, state, player.transform);
                    state.enemies.Add(enemy);
                }
                else
                {
                    Logger.LogError(name, "Enemy without enemyController");
                }
                state.spawns.Remove(s);
            }
        }

        private void SpawnCrocs()
        {
            var crocSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Water).ToList().PickRandomElements(state.difficulty.crocsCount);

            foreach (var s in crocSpawns)
            {
                var go = Instantiate(crocPrefab, s.transform.position, Quaternion.identity, npcsParent);
                var enemy = go.GetComponent<EnemyController>();

                if (enemy != null)
                {
                    enemy.Initialize(turnManager, state, player.transform);
                    state.enemies.Add(enemy);
                }
                else
                {
                    Logger.LogError(name, "Enemy without enemyController");
                }
                state.spawns.Remove(s);
            }
        }

        private void SpawnCrabs()
        {
            var crabSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Water).ToList().PickRandomElements(state.difficulty.crabsCount);

            foreach (var s in crabSpawns)
            {
                var go = Instantiate(crabPrefab, s.transform.position, Quaternion.identity, npcsParent);
                var enemy = go.GetComponent<EnemyController>();

                if (enemy != null)
                {
                    enemy.Initialize(turnManager, state, player.transform);
                    state.enemies.Add(enemy);
                }
                else
                {
                    Logger.LogError(name, "Enemy without enemyController");
                }
                state.spawns.Remove(s);
            }
        }

        private void SpawnChicks()
        {
            var chickSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.chickCount);

            foreach (var s in chickSpawns)
            {
                Instantiate(chickPrefab, s.transform.position, Quaternion.identity, itemsParent);
                state.spawns.Remove(s);
            }
        }

        private void SpawnEggs()
        {
            var eggSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.eggCount);

            foreach (var s in eggSpawns)
            {
                Instantiate(eggPrefab, s.transform.position, Quaternion.identity, itemsParent);
                state.spawns.Remove(s);
            }
        }

        private void SpawnApples()
        {
            var appleSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.appleCount);

            foreach (var s in appleSpawns)
            {
                Instantiate(applePrefab, s.transform.position, Quaternion.identity, itemsParent);
                state.spawns.Remove(s);
            }
        }

        private void SpawnMushrooms()
        {
            var mushroomSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.mushroomCount);
            foreach (var s in mushroomSpawns)
            {
                Instantiate(mushroomPrefab, s.transform.position, Quaternion.identity, itemsParent);
                state.spawns.Remove(s);
            }
        }

        private void SpawnBreads()
        {
            var breadSpawns = state.spawns.ToList().PickRandomElements(state.difficulty.breadCount);
            foreach (var s in breadSpawns)
            {
                Instantiate(breadPrefab, s.transform.position, Quaternion.identity, itemsParent);
                state.spawns.Remove(s);
            }
        }

        private void SpawnChips()
        {
            var chipSpawns = state.spawns.ToList().PickRandomElements(state.difficulty.chipCount);
            foreach (var s in chipSpawns)
            {
                Instantiate(chipPrefab, s.transform.position, Quaternion.identity, itemsParent);
                state.spawns.Remove(s);
            }
        }

        private void SpawnLettuces()
        {
            var lettuceSpawns = state.spawns.Where(s => s.spawnType == SpawnType.Ground).ToList().PickRandomElements(state.difficulty.lettuceCount);
            foreach (var s in lettuceSpawns)
            {
                Instantiate(lettucePrefab, s.transform.position, Quaternion.identity, itemsParent);
                state.spawns.Remove(s);
            }
        }

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


        void Update()
        {
            switch (state.currentState)
            {
                case GameStateEnum.PLAYING:
                    if (turnManager.PlayerTurnCompleted())
                    {
                        turnManager.ProcessTurn();

                        var hits = Physics2D.OverlapCircleAll(player.transform.position, state.difficulty.enemyRadius, enemyLayerMask);


                        foreach (var hit in hits)
                        {
                            if (hit.gameObject != null)
                            {
                                var enemy = hit.gameObject.GetComponent<EnemyController>();
                                enemy.UpdateTurn();
                            }
                        }
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
            gameOverDeadPresenter.Repaint();
            gameOverSuccessPresenter.Repaint();
            difficultyPresenter.Repaint();
            shopPresenter.Repaint();
            cutscenePresenter.Repaint();
        }

        public void SetCurrentDifficulty(int difficulty)
        {
            state.difficulty = difficulties[difficulty];
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

        public void SetDifficulty()
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
            InitializeLevel();
            state.currentState = GameStateEnum.STARTCUTSCENE;
            state.started = true;
        }

        public void SetPlaying()
        {
            state.currentState = GameStateEnum.PLAYING;
        }


        public void SetShop()
        {
            state.currentState = GameStateEnum.SHOP;
        }

        public void SetGameOverDead()
        {
            state.currentState = GameStateEnum.GAMEOVERDEAD;
        }

        public void SetGameOverStarved()
        {
            state.currentState = GameStateEnum.GAMEOVERSTARVED;
        }

        public void StealLoaf()
        {
            loafCutscene.SetActive(false);
            loafCutscene2.SetActive(true);

            Logger.Log(name, "steal loaf");
        }

        public void StealSuzie()
        {
            suzieCutscene.SetActive(false);
            suzieCutscene2.SetActive(true);
            Logger.Log(name, "steal suzie");
        }

        public void GooseLeeLeave()
        {
            gooseleeCutscene.SetActive(false);
            crowCutscene.SetActive(false);
            suzieCutscene.SetActive(false);
            suzieCutscene2.SetActive(false);

            loafCutscene.SetActive(false);
            loafCutscene2.SetActive(false);
            suzieCutscene2.SetActive(false);
            Logger.Log(name, "steal away");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
