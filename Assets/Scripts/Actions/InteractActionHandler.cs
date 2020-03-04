using UnityEngine;

namespace HackedDesign
{
    public class InteractActionHandler : MonoBehaviour
    {
        private Status status;



        public int distance = 1;

        private void Start()
        {
            status = GetComponent<Status>();
        }

        public void Handle(Action action)
        {
            CoreGame.instance.AddActionMessage(action.sourceName + " interacts with " + status.character);
            CoreGame.instance.SetShop();
            
        }
    }
}
