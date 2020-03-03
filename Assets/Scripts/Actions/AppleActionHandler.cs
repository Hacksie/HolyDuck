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
                CoreGame.instance.AddActionMessage(name + " eats an apple");
            }
            else
            {
                CoreGame.instance.AddActionMessage(name + " has no apples to eat");
            }
        }
    }
}
