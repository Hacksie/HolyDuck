using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class QuackActionHandler : MonoBehaviour
    {
        private Status status;
        private Inventory inventory;
        private NPCController npcController;
        private EnemyController enemyController;

        private void Start()
        {
            status = GetComponent<Status>();
            inventory = GetComponent<Inventory>();
            npcController = GetComponent<NPCController>();
            enemyController = GetComponent<EnemyController>();

        }

        public void Handle(Action action)
        {
            status.SapEnergy(1);
            CoreGame.instance.AddActionMessage(action.sourceName + " quacks at " + status.character);
            if (npcController != null)
            {
                CoreGame.instance.AddActionMessage(status.character + " is unimpressed");
            }
            else if (enemyController != null)
            {
                status.stunned = true;
                status.stunnedCounter = 1;
            }
            //CoreGame.instance.AddActionMessage(action.sourceName + " quacks! " + status.character + " for " + damage + "(" + action.damage + "-" + status.defense + ")!");
            /*
            var damage = Mathf.Max(action.damage - status.defense, 0);

            CoreGame.instance.AddActionMessage(action.sourceName + " bites " + status.character + " for " + damage + "(" +action.damage + "-" + status.defense + ")!");
            status.AddHealth(-damage);
            */
        }
    }
}
