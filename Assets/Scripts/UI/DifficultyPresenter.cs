using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class DifficultyPresenter : MonoBehaviour
    {
        private GameState state = null;


        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if (state.currentState == GameStateEnum.DIFFICULTY && !gameObject.activeInHierarchy)
            {
                Show(true);

            }
            else if (state.currentState != GameStateEnum.DIFFICULTY && gameObject.activeInHierarchy)
            {
                Show(false);
            }
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        public void EasyEvent()
        {
            Logger.Log(name, "EasyEvent");
            CoreGame.instance.SetCurrentDifficulty(0);
            CoreGame.instance.StartGame();
        }

        public void MediumEvent()
        {
            Logger.Log(name, "MediumEvent");
            CoreGame.instance.SetCurrentDifficulty(1);
            CoreGame.instance.StartGame();
        }

        public void HardEvent()
        {
            Logger.Log(name, "HardEvent");
            CoreGame.instance.SetCurrentDifficulty(2);
            CoreGame.instance.StartGame();

        }
    }
}
