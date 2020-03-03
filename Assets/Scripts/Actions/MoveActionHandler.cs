using UnityEngine;
using System.Linq;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class MoveActionHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask colliderLayerMask;
        private Status status;


        public int distance = 1;

        private void Start()
        {
            status = GetComponent<Status>();
        }

        public void Handle(Action action)
        {
            var hits = Physics2D.RaycastAll(transform.position, action.direction, distance, colliderLayerMask);

            status.SapEnergy(1);

            // Check for collision with self
            if(hits.Any(h => h.collider.gameObject != this.gameObject))
            {
                CoreGame.instance.AddActionMessage(action.source.name + " was blocked " + ((int)transform.position.x).ToString() + "," + ((int)transform.position.y).ToString());
            }
            else
            {
                transform.Translate((action.direction * distance), Space.World);
                CoreGame.instance.AddActionMessage(action.source.name + " moved to " + ((int)transform.position.x).ToString() + "," + ((int)transform.position.y).ToString());
            }




            /*

            if (hit.collider != null)
            {

            }
            else
            {

            }
            */
        }
    }
}
