using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(Status))]
    public class AppleActionHandler : MonoBehaviour
    {
        private Inventory inventory;
        private Status status;

        private void Start()
        {
            inventory = GetComponent<Inventory>();
            status = GetComponent<Status>();
        }

        public void Handle(Action action)
        {
            if(inventory.ConsumeItem("Apple", 1))
            {
                CoreGame.instance.AddActionMessage(status.character + " eats an apple");
                status.AddHealth(50);
            }
            else
            {
                CoreGame.instance.AddActionMessage(status.character + " has no apples to eat");
            }
        }
    }
}
