using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class ShopPresenter : MonoBehaviour
    {
        private GameState state = null;

        [SerializeField] private Button attackBuyButton;
        [SerializeField] private Button defenseBuyButton;
        [SerializeField] private Button initiativeBuyButton;
        [SerializeField] private Button appleBuyButton;
        [SerializeField] private Button mushroomBuyButton;
        [SerializeField] private Button breadBuyButton;


        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if (state.currentState == GameStateEnum.SHOP && !gameObject.activeInHierarchy)
            {
                Show(true);

            }
            else if (state.currentState != GameStateEnum.SHOP && gameObject.activeInHierarchy)
            {
                Show(false);
            }
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        private void RepaintButtons()
        {
            if(state.playerInventory.ItemCount("Chick") < 10)
            {
                attackBuyButton.interactable = false;
                defenseBuyButton.interactable = false;
                initiativeBuyButton.interactable = false;
            }
            if (state.playerInventory.ItemCount("Egg") < 1)
            {
                breadBuyButton.interactable = false;
            }
            if (state.playerInventory.ItemCount("Egg") < 10)
            {
                appleBuyButton.interactable = false;
                mushroomBuyButton.interactable = false;
            }
        }

        public void DoneEvent()
        {
            CoreGame.instance.ResumeGame();
        }

    }
}
