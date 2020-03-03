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
        //private Inventory inventory = null;

        [SerializeField] private Image healthBar = null;
        [SerializeField] private Image energyBar = null;
        [SerializeField] private Text chicksText = null;
        [SerializeField] private Text eggsText = null;
        [SerializeField] private Text applesText = null;
        [SerializeField] private Text mushroomsText = null;
        [SerializeField] private Text attackText = null;
        [SerializeField] private Text defenseText = null;
        [SerializeField] private Text initiativeText = null;

        private void Start()
        {
            if (healthBar == null) Logger.LogError(name, "healthBar is null");
            if (energyBar == null) Logger.LogError(name, "energyBar is null");
            if (chicksText == null) Logger.LogError(name, "chicksText is null");
            if (eggsText == null) Logger.LogError(name, "eggsText is null");
            if (mushroomsText == null) Logger.LogError(name, "mushroomsText is null");
            if (applesText == null) Logger.LogError(name, "applesText is null");
            if (attackText == null) Logger.LogError(name, "attackText is null");
            if (defenseText == null) Logger.LogError(name, "defenseText is null");
            if (initiativeText == null) Logger.LogError(name, "initiativeText is null");
        }

        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if (state.currentState == GameStateEnum.PLAYING)
            {
                if (!gameObject.activeInHierarchy)
                {
                    Show(true);
                }
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
            attackText.text = state.playerStatus.maxAttack.ToString() + "!";
            defenseText.text = state.playerStatus.defense.ToString() + "#";
            initiativeText.text = state.playerStatus.initiative.ToString() + "^";

            if (state.playerStatus.maxHealth > 0)
            {
                healthBar.fillAmount = (float)state.playerStatus.health / state.playerStatus.maxHealth;
            }

            if (state.playerStatus.maxEnergy > 0)
            {
                energyBar.fillAmount = (float)state.playerStatus.energy / state.playerStatus.maxEnergy;
            }

            chicksText.text = state.playerStatus.chicksSaved.ToString();

            if (state.playerInventory.inventory.ContainsKey("Egg"))
            {
                eggsText.text = state.playerInventory.inventory["Egg"].ToString();
            }
            else
            {
                eggsText.text = "0";
            }

            if (state.playerInventory.inventory.ContainsKey("Mushroom"))
            {
                mushroomsText.text = state.playerInventory.inventory["Mushroom"].ToString();
            }
            else
            {
                mushroomsText.text = "0";
            }

            if (state.playerInventory.inventory.ContainsKey("Apple"))
            {
                applesText.text = state.playerInventory.inventory["Apple"].ToString();
            }
            else
            {
                applesText.text = "0";
            }
        }
    }
}
