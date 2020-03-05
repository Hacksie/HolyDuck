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
            if (state.currentState == GameStateEnum.SHOP)
            {
                if (!gameObject.activeInHierarchy)
                {
                    Show(true);
                }
                RepaintButtons();
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
            
            attackBuyButton.interactable = state.playerInventory.ItemCount("Chick") >= 10;
            defenseBuyButton.interactable = state.playerInventory.ItemCount("Chick") >= 10;
            initiativeBuyButton.interactable = state.playerInventory.ItemCount("Chick") >= 10 && state.playerStatus.initiative > 1;
            breadBuyButton.interactable = state.playerInventory.ItemCount("Egg") >= 1;
            appleBuyButton.interactable = state.playerInventory.ItemCount("Egg") >= 10;
            mushroomBuyButton.interactable = state.playerInventory.ItemCount("Egg") >= 22;
        }

        public void DoneEvent()
        {
            CoreGame.instance.ResumeGame();
        }

        public void AttackBuyEvent()
        {
            if(state.playerInventory.ConsumeItem("Chick", 10))
            {
                state.playerStatus.maxAttack += 3;
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " bought +3 attack");
            }
            else
            {
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " tried to buy +3 attack but failed");
            }
        }

        public void DefenseBuyEvent()
        {
            Logger.Log(name, "defensebuyevent");
            if (state.playerInventory.ConsumeItem("Chick", 10))
            {
                state.playerStatus.defense += 1;
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " bought +1 defense");
            }
            else
            {
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " tried to buy +1 defense but failed");
            }
        }

        public void InitiativeBuyEvent()
        {
            Logger.Log(name, "initiativebuyevent");
            if (state.playerStatus.initiative > 1 && state.playerInventory.ConsumeItem("Chick", 10))
            {
                state.playerStatus.initiative -= 1;
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " bought +1 initiative");
            }
            else
            {
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " tried to buy +1 initiatve but failed");
            }
        }

        public void BreadBuyEvent()
        {
            Logger.Log(name, "breadbuyevent");
            if (state.playerInventory.ConsumeItem("Egg", 1))
            {
                state.playerStatus.EatBread();
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " ate some bread");
            } 
            else
            {
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " failed to buy bread");
            }
        }

        public void AppleBuyEvent()
        {
            Logger.Log(name, "applebuyevent");
            if (state.playerInventory.ConsumeItem("Egg", 10))
            {
                state.playerInventory.PickupItem("Apple", 1);
            }
            else
            {
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " failed to buy an apple");
            }
        }

        public void MushroomBuyEvent()
        {
            Logger.Log(name, "mushroombuyevent");
            if (state.playerInventory.ConsumeItem("Egg", 20))
            {
                state.playerInventory.PickupItem("Mushroom", 1);
            }
            else
            {
                CoreGame.instance.AddActionMessage(state.playerStatus.character + " failed to buy a mushroom");
            }
        }

    }
}
