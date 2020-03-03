using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(Status))]
    public class Snake : MonoBehaviour
    {
        private Status status;
        private EnemyController enemyController;
        // Start is called before the first frame update
        void Start()
        {
            enemyController = GetComponent<EnemyController>();
            status = GetComponent<Status>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Behaviour()
        {
            //CoreGame.instance.AddActionMessage(name + " distance " + enemyController.DistanceToPlayer());
            if(enemyController.DistanceToPlayer()<= 1)
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
