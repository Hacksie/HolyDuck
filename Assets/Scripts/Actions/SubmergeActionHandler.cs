using UnityEngine;
using System.Linq;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class SubmergeActionHandler : MonoBehaviour
    {
        private Status status;
        private EnemyController enemyController;
        


        public int distance = 1;

        private void Start()
        {
            status = GetComponent<Status>();
            enemyController = GetComponent<EnemyController>();
        }

        public void Handle(Action action)
        {

            if(action.action == ActionTypes.Submerge)
            {
                if (enemyController.IsVisible())
                {
                    CoreGame.instance.AddActionMessage(status.character + " submerged!");
                    enemyController.SetVisible(false);
                }
                else
                {
                    CoreGame.instance.AddActionMessage(status.character + " is already submerged!");
                }
            }
            else if (action.action == ActionTypes.Emerge)
            {
                if (!enemyController.IsVisible())
                {
                    CoreGame.instance.AddActionMessage(status.character + " emerged!");
                    enemyController.SetVisible(true);
                }
                else
                {
                    CoreGame.instance.AddActionMessage(status.character + " is already emerged!");
                }
            }


        }
    }
}
