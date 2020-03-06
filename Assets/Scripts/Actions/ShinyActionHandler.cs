using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class ShinyActionHandler : MonoBehaviour
    {
        private Status status;

        private void Start()
        {
            
            status = GetComponent<Status>();
        }

        public void Handle(Action action)
        {
            if (status.dead)
            {
                CoreGame.instance.AddActionMessage(status.character + " is dead");
                return;
            }

            status.distractedByShinies = true;
            Inventory inv = action.source.gameObject.GetComponent<Inventory>();
            inv.DropItem("Green Shiny", 1);
            inv.DropItem("Yellow Shiny", 1);
            inv.DropItem("Red Shiny", 1);
            inv.DropItem("Blue Shiny", 1);
            CoreGame.instance.AddActionMessage(status.character + " is distracted by" + action.sourceName);
            
            
        }
    }
}
