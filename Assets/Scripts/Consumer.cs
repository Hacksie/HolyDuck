using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class Consumer : MonoBehaviour
    {
        private Status status;

        private void Start()
        {
            status = GetComponent<Status>();
        }

        public void PickupBread()
        {
            CoreGame.instance.AddActionMessage(status.character + " ate some bread");
            status.EatBread();
            //CoreGame.instance.SaveChick();
        }

        public void PickupChip()
        {
            CoreGame.instance.AddActionMessage(status.character + " ate a chip");
            status.EatChip();
        }
    }
}
