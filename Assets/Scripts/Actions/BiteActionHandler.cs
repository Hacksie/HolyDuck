using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class BiteActionHandler : MonoBehaviour
    {
        private Status status;

        private void Start()
        {
            status = GetComponent<Status>();
        }

        public void Handle(Action action)
        {
            var damage = Mathf.Max(action.damage - status.defense, 0);

            CoreGame.instance.AddActionMessage(action.source.name + " bites " + name + " for " + damage + "(" +action.damage + "-" + status.defense + ")!");
            status.TakeDamage(damage);
            
        }
    }
}
