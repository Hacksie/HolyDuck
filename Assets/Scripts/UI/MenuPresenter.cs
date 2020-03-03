using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class MenuPresenter : MonoBehaviour
    {
        private GameState state = null;
        [SerializeField] Button resumeButton = null;

        private void Start()
        {
            if (resumeButton == null) Logger.LogError(name, "resumeButton not set");
        }

        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if(state.currentState == GameStateEnum.MENU && !gameObject.activeInHierarchy)
            {
                resumeButton.interactable = state.started;
                Show(true);
                
            }
            else if(state.currentState != GameStateEnum.MENU && gameObject.activeInHierarchy)
            {
                Show(false);
            }
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        public void StartEvent()
        {
            Logger.Log(name, "StartEvent");
            CoreGame.instance.SetDifficulty();
            //CoreGame.instance.StartGame();
        }

        public void OptionsEvent()
        {
            Logger.Log(name, "OptionsEvent");
            CoreGame.instance.SetOptions();
        }

        public void CreditsEvent()
        {
            Logger.Log(name, "CreditsEvent");
            CoreGame.instance.SetCredits();
            
        }

        public void QuitEvent()
        {
            Logger.Log(name, "Quitting");
            CoreGame.instance.Quit();
        }

        public void ResumeEvent()
        {
            Logger.Log(name, "ResumeEvent");
        }

    }
}
