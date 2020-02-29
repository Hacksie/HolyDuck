using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HackedDesign
{
    public class CoreGame : MonoBehaviour
    {
        private Input.IInputController inputController;

        [Header("Test Flags")]
        [SerializeField]
        private RuntimePlatform testPlatform = RuntimePlatform.WindowsEditor;
        [SerializeField]
        private bool testPlatformFlag = false;

        [Header("Game Objects")]
        public TurnManager turnManager;
        public PlayerController player;


        
        

        // Start is called before the first frame update
        void Start()
        {
            Initialization();
        }



        void Initialization()
        {
            SetPlatformInput();
            player.Initialize(turnManager);
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
            // Process updates
            //Logger.Log(this.name, "Game turn:", gameturn.ToString());

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
