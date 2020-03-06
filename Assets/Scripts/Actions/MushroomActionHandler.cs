using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(Status))]
    public class MushroomActionHandler : MonoBehaviour
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
            if (status.dead)
            {
                CoreGame.instance.AddActionMessage(status.character + " is dead");
                return;
            }

            if (inventory.ConsumeItem("Mushroom", 1))
            {
                CoreGame.instance.AddActionMessage(status.character + " eats a magic mushroom");
                status.AddHealth(100);
                status.AddEnergy(100);
                // Any other magic mushroom effects?
            }
            else
            {
                CoreGame.instance.AddActionMessage(status.character + " has no magic mushrooms to eat");
            }
        }
    }
}
