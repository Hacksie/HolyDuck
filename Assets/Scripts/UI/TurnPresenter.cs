using UnityEngine;
using UnityEngine.UI;

namespace HackedDesign
{
    public class TurnPresenter : MonoBehaviour
    {
        private GameState state = null;
        
        [SerializeField] Text turnText = null;


        private void Start()
        {
            if (turnText == null) Logger.LogError(name, "turnText is not set");
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
            turnText.text = state.turn.ToString();
        }
    }
}
