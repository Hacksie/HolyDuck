using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(Status))]
    public class Crab : MonoBehaviour
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
            if(enemyController.IsVisible() && enemyController.DistanceToPlayer() > 3)
            {
                enemyController.SubmergeEvent();
            }
            else if (!enemyController.IsVisible() && enemyController.DistanceToPlayer() <= 3)
            {
                enemyController.EmergeEvent();
            }
            else if (enemyController.DistanceToPlayer() <= 1)
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
