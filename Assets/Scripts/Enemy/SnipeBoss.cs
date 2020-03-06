using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(Status))]
    public class SnipeBoss : MonoBehaviour
    {
        [SerializeField] GameObject shiny;
        private Status status;
        private EnemyController enemyController;
        // Start is called before the first frame update
        void Start()
        {
            enemyController = GetComponent<EnemyController>();
            status = GetComponent<Status>();
        }

        public void Behaviour()
        {
            if (enemyController.DistanceToPlayer() <= 1)
            {
                enemyController.BiteEvent();
            }
            else
            {
                enemyController.MoveTowardPlayerEvent();
            }
        }

        public void Kill()
        {
            CoreGame.instance.AddActionMessage(status.character + " dropped " + shiny.name);
            shiny.transform.position = transform.position;
            shiny.SetActive(true);
            Logger.Log(name, "Killed Snipe");
        }
    }
}
