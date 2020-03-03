using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    [RequireComponent(typeof(Status))]
    public class Rescue : MonoBehaviour
    {
        private Status status;

        private void Start()
        {
            status = GetComponent<Status>();
        }

        public void PickupChick()
        {
            CoreGame.instance.AddActionMessage(name + " rescued a chick!");
            status.SaveChick(); 
        }
    }
}
