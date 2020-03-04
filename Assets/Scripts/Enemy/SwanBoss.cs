using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(Status))]
    public class SwanBoss : MonoBehaviour
    {
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
    }
}
