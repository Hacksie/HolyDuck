using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(Status))]
    public class FinalBoss : MonoBehaviour
    {
        private Status status;
        private EnemyController enemyController;
        [SerializeField] GameObject loaf;
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
            CoreGame.instance.AddActionMessage(status.character + " dropped " + loaf.name);
            loaf.transform.position = transform.position;
            loaf.SetActive(true);
            CoreGame.instance.SetEndCutscene();
        }
    }
}
