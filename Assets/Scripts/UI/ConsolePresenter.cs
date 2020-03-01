using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class ConsolePresenter : MonoBehaviour
    {
        private TurnManager turnManager;
        private GameState state = null;

        private void Start()
        {

        }

        public void Initialize(GameState state, TurnManager turnManager)
        {
            this.state = state;
            this.turnManager = turnManager;
        }

        public void Repaint()
        {
            /*
            if (state.currentState == GameStateEnum.PLAYING && !gameObject.activeInHierarchy)
            {
                Show(true);

            }
            else if (state.currentState != GameStateEnum.PLAYING && gameObject.activeInHierarchy)
            {
                Show(false);
            }*/
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }



    }
}
