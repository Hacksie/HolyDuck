using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class StatusPresenter : MonoBehaviour
    {
        private GameState state = null;
        private Inventory inventory = null;

        [SerializeField] private Image healthBar = null;
        [SerializeField] private Image energyBar = null;
        [SerializeField] private Text chicksText = null;
        [SerializeField] private Text eggsText = null;
        [SerializeField] private Text stonesText = null;
        [SerializeField] private Text fruitsText = null;


        private void Start()
        {
            if (healthBar == null) Logger.LogError(name, "healthBar is null");
            if (energyBar == null) Logger.LogError(name, "energyBar is null");
            if (chicksText == null) Logger.LogError(name, "chicksText is null");
            if (eggsText == null) Logger.LogError(name, "eggsText is null");
            if (stonesText == null) Logger.LogError(name, "stonesText is null");
            if (fruitsText == null) Logger.LogError(name, "fruitsText is null");
        }

        public void Initialize(GameState state, Inventory inventory)
        {
            this.state = state;
            this.inventory = inventory;
            
        }

        public void Repaint()
        {
            if (state.currentState == GameStateEnum.PLAYING && !gameObject.activeInHierarchy)
            {
                Show(true);
                RepaintText();
            }
            else if (state.currentState != GameStateEnum.PLAYING && gameObject.activeInHierarchy)
            {
                Show(false);
            }
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        public void RepaintText()
        {
            if (state.maxHealth > 0)
            {
                healthBar.fillAmount = (float)state.health / state.maxHealth;
            }

            if (state.maxEnergy > 0)
            {
                energyBar.fillAmount = (float)state.energy / state.maxEnergy;
            }

            chicksText.text = state.chicksSaved.ToString();

            if (inventory.inventory.ContainsKey("Egg"))
            {
                eggsText.text = inventory.inventory["Egg"].ToString();
            }
            else
            {
                eggsText.text = "0";
            }

            if (inventory.inventory.ContainsKey("Stone"))
            {
                stonesText.text = inventory.inventory["Stone"].ToString();
            }
            else
            {
                stonesText.text = "0";
            }

            if (inventory.inventory.ContainsKey("Fruit"))
            {
                fruitsText.text = inventory.inventory["Fruit"].ToString();
            }
            else
            {
                fruitsText.text = "0";
            }
        }

        public void StartEvent()
        {
            Logger.Log(name, "StartEvent");
            CoreGame.instance.StartGame();
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
            Application.Quit();
        }

        public void ResumeEvent()
        {
            Logger.Log(name, "ResumeEvent");
        }

    }
}
