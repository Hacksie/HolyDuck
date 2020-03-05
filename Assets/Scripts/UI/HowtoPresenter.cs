using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class HowtoPresenter : MonoBehaviour
    {
        private GameState state = null;

        private void Start()
        {

        }

        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if(state.currentState == GameStateEnum.HOWTO && !gameObject.activeInHierarchy)
            {
                Show(true);
                
            }
            else if(state.currentState != GameStateEnum.HOWTO && gameObject.activeInHierarchy)
            {
                Show(false);
            }
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        public void ReturnEvent()
        {
            Logger.Log(name, "ReturnEvent");
            CoreGame.instance.SetMenu();
        }
    }
}
