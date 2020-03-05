using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class GameOverDeadPresenter : MonoBehaviour
    {
        private GameState state = null;
        //[SerializeField] Button quitButton = null;

        private void Start()
        {
            //if (quitButton == null) Logger.LogError(name, "quitButton not set");
        }

        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if(state.currentState == GameStateEnum.GAMEOVERDEAD && !gameObject.activeInHierarchy)
            {
                Show(true);
                
            }
            else if(state.currentState != GameStateEnum.GAMEOVERDEAD && gameObject.activeInHierarchy)
            {
                Show(false);
            }
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        public void QuitEvent()
        {
            Logger.Log(name, "Quitting");
            CoreGame.instance.SetOver();
        }

    }
}
