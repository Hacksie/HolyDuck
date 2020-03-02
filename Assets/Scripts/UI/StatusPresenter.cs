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
        [SerializeField] private Text applesText = null;
        [SerializeField] private Text mushroomsText = null;
        [SerializeField] private Text attackText = null;
        [SerializeField] private Text defenseText = null;
        


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
        }

        public void Initialize(GameState state, Inventory inventory)
        {
            this.state = state;
            this.inventory = inventory;
            
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
            attackText.text = state.maxAttack.ToString() + "!";
            defenseText.text = state.defense.ToString() + "#";

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

            if (inventory.inventory.ContainsKey("Mushroom"))
            {
                mushroomsText.text = inventory.inventory["Mushroom"].ToString();
            }
            else
            {
                mushroomsText.text = "0";
            }

            if (inventory.inventory.ContainsKey("Apple"))
            {
                applesText.text = inventory.inventory["Apple"].ToString();
            }
            else
            {
                applesText.text = "0";
            }
        }
    }
}
