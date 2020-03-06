using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class EndCutscenePresenter : MonoBehaviour
    {
        private GameState state = null;
        [SerializeField] Text speaker = null;
        [SerializeField] Text text = null;


        [SerializeField] public List<Cutscene> cutscenes = new List<Cutscene>();

        private void Start()
        {
            if (speaker == null) Logger.LogError(name, "speaker not set");
            if (text == null) Logger.LogError(name, "text not set");
        }


        public void Initialize(GameState state)
        {
            this.state = state;
        }

        public void Repaint()
        {
            if (state.currentState == GameStateEnum.ENDCUTSCENE && !gameObject.activeInHierarchy)
            {

                Show(true);
                RepaintText();


            }
            else if (state.currentState != GameStateEnum.ENDCUTSCENE && gameObject.activeInHierarchy)
            {
                Show(false);

            }
        }

        public void RepaintText()
        {
            speaker.text = cutscenes[state.endcutscene].speaker;
            text.text = cutscenes[state.endcutscene].text;
        }

        private void Show(bool flag)
        {
            gameObject.SetActive(flag);
        }

        public void NextEvent()
        {
            //Logger.Log(name, "Quitting");
            cutscenes[state.endcutscene].nextEvent.Invoke();
            state.endcutscene++;
            
            if (state.endcutscene >= cutscenes.Count())
            {
                CoreGame.instance.SetOver(); 
            }
            else
            {
                RepaintText();
            }

        }

    }
}
