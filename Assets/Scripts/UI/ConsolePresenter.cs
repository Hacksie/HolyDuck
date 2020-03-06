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
        private GameState state = null;
        [SerializeField] private Text console = null;

        private void Start()
        {
            if (console == null) Logger.LogError(name, "console text is null");
        }

        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if (state.currentState == GameStateEnum.PLAYING || state.currentState == GameStateEnum.SHOP)
            {
                if (!gameObject.activeInHierarchy)
                {
                    Show(true);
                }

                RepaintText();
            }
            else if ((state.currentState != GameStateEnum.PLAYING && state.currentState != GameStateEnum.SHOP) && gameObject.activeInHierarchy)
            {
                Show(false);
            }
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        private void RepaintText()
        {
            
            var messages = state.actions.Take(10).ToArray();

            StringBuilder sb = new StringBuilder();

            //console.text = "";
            for(int i=(messages.Length - 1); i>=0;i--)
            {
                sb.AppendLine(messages[i]);
                    //console.text += messages[i] + "\n";
            }

            console.text =sb.ToString();
        }
    }
}
